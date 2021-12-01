using Audacia.Quest.Core;
using Audacia.Quest.Core.Asset;
using Blazor.Extensions.Canvas.Canvas2D;

namespace Audacia.Quest
{
    public class BlazorGameContext : IGameContext
    {
        private readonly Canvas2DContext _context;

        public List<BlazorAsset> Assets { get; set; } = new List<BlazorAsset>();

        public BlazorGameContext(Canvas2DContext context)
        {
            _context = context;
        }

        public void LoadContent(List<Sprite> sprites)
        {
            Assets = sprites.Select(r => new BlazorAsset
            {
                Source = r.ImageSource,
                Sprite = r
            }).ToList();
        }

        public bool ContentLoaded()
        {
            return Assets.All(a => a.Loaded);
        }

        public async Task Draw(Core.Components.IComponent component)
        {
            var asset = Assets.FirstOrDefault(a => a.Source == component.Sprite?.ImageSource);

            if (asset != null && component.Sprite != null)
            {
                await _context.SaveAsync();

                await _context.TranslateAsync(component.Transform.Position.X, component.Transform.Position.Y);
                await _context.ScaleAsync(component.Transform.Scale.X, component.Transform.Scale.Y);
                await _context.RotateAsync(component.Transform.Rotation);

                await _context.DrawImageAsync(
                   asset.Ref,
                   component.Sprite.CurrentFrame.X, component.Sprite.CurrentFrame.Y,
                   component.Sprite.CurrentFrame.Width,
                   component.Sprite.CurrentFrame.Height,
                   component.Sprite.Origin.X, component.Sprite.Origin.Y,
                   component.Sprite.Width,
                   component.Sprite.Height);

                await _context.RestoreAsync();
            }
        }
    }
}

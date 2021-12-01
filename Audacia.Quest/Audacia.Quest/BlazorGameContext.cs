using Audacia.Quest.Core;
using Audacia.Quest.Core.Asset;
using Audacia.Quest.Core.Renderer;
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
                //await _context.RotateAsync(component.Transform.Rotation);

                await _context.DrawImageAsync(
                    asset.Ref,
                    component.Sprite.Origin.X, component.Sprite.Origin.Y,
                    component.Sprite.Width,
                    component.Sprite.Height);

                //if (component.Renderer is SpriteRenderer)
                //{
                //    await _context.DrawImageAsync(
                //        asset.Ref,
                //        component.Renderer.Origin.X, component.Renderer.Origin.Y,
                //        component.Renderer.Width,
                //        component.Renderer.Height);
                //}
                //else if (component.Renderer is SpriteSheetRenderer spriteSheet)
                //{
                //    var frame = spriteSheet.GetCurrentFrame();

                //    await _context.DrawImageAsync(
                //       asset.Ref,
                //       frame.X, frame.Y,
                //       frame.Width,
                //       frame.Height,
                //       component.Renderer.Origin.X, component.Renderer.Origin.Y,
                //       frame.Width,
                //       frame.Height);

                //    spriteSheet.NextFrame();
                //}

                await _context.RestoreAsync();
            }
        }
    }
}

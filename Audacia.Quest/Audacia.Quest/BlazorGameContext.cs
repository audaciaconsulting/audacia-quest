using Audacia.Quest.Core;
using Audacia.Quest.Core.Renderer;
using Blazor.Extensions.Canvas.Canvas2D;

namespace Audacia.Quest
{
    public class BlazorGameContext : IGameContext
    {
        private readonly Canvas2DContext _context;

        public List<BlazorAsset> Assets { get; set; } = new List<BlazorAsset>();
        public delegate Task OnAssetInitialized();
        public event OnAssetInitialized OnAssetInitializedHandeler;

        public BlazorGameContext(Canvas2DContext context)
        {
            _context = context;
        }

        public void LoadContent(List<Core.Components.IComponent> components)
        {
            var renderable = components.Where(c => c.Renderer != null);

            Assets = renderable.Select(r => new BlazorAsset
            {
                Id = r.Id,
                Renderer = r.Renderer
            }).ToList();

            OnAssetInitializedHandeler?.Invoke();
        }

        public async Task Draw(Core.Components.IComponent component)
        {
            var asset = Assets.FirstOrDefault(a => a.Id == component.Id);

            if (asset != null && component.Renderer != null)
            {
                await _context.SaveAsync();

                await _context.TranslateAsync(component.Transform.Position.X, component.Transform.Position.Y);
                await _context.ScaleAsync(component.Transform.Scale.X, component.Transform.Scale.Y);
                //await _context.RotateAsync(component.Transform.Rotation);

                if (component.Renderer is SpriteRenderer)
                {
                    await _context.DrawImageAsync(
                        asset.Ref,
                        component.Renderer.Origin.X, component.Renderer.Origin.Y,
                        component.Renderer.Width,
                        component.Renderer.Height);
                }
                else if (component.Renderer is SpriteSheetRenderer spriteSheet)
                {
                    var frame = spriteSheet.GetCurrentFrame();

                    await _context.DrawImageAsync(
                       asset.Ref,
                       frame.X, frame.Y,
                       frame.Width,
                       frame.Height,
                       component.Renderer.Origin.X, component.Renderer.Origin.Y,
                       frame.Width,
                       frame.Height);

                    spriteSheet.NextFrame();
                }

                await _context.RestoreAsync();
            }
        }
    }
}

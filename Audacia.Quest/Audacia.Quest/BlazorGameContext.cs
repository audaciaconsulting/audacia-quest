using Audacia.Quest.Core;
using Blazor.Extensions.Canvas.Canvas2D;
using MudBlazor;
using System.Numerics;

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
                await _context.DrawImageAsync(
                    asset.Ref,
                    component.Transform.Position.X,
                    component.Transform.Position.Y,
                    component.Renderer.Width * component.Transform.Scale.X,
                    component.Renderer.Height * component.Transform.Scale.Y);
            }
        }
    }
}

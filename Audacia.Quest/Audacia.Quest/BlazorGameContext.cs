using Audacia.Quest.Core;
using Blazor.Extensions.Canvas.Canvas2D;

namespace Audacia.Quest
{
    public class BlazorGameContext : IGameContext
    {
        public List<BlazorAsset> Assets { get; set; } = new List<BlazorAsset>();

        private readonly Canvas2DContext _context;

        public BlazorGameContext(Canvas2DContext context)
        {
            _context = context;
        }

        public void AddAsset(string assetSource)
        {
            BlazorAsset blazorAsset = new()
            {
                Source = assetSource,
            };

            Assets.Add(blazorAsset);
        }

        public void ClearAssets()
        {
            Assets.Clear();
        }

        public async Task Draw()
        {
            foreach (var asset in Assets)
            {
                await _context.DrawImageAsync(asset.Ref, 0, 0, 100, 100);
            }
        }
    }
}

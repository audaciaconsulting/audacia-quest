using Audacia.Quest.Core;
using Blazor.Extensions.Canvas.Canvas2D;

namespace Audacia.Quest
{
    public class BlazorGameContext : IGameContext
    {
        private readonly Canvas2DContext _context;

        public BlazorGameContext(Canvas2DContext context)
        {
            _context = context;
        }

        public void Draw(Asset asset)
        {
            throw new NotImplementedException();
        }
    }
}

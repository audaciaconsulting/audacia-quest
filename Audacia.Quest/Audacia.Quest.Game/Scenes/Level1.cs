using Audacia.Quest.Core;
using Audacia.Quest.Core.Core;
using Audacia.Quest.Core.Events;
using Audacia.Quest.Core.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audacia.Quest
{
    public class Level1 : IScene
    {
        private readonly IGameContext _context;

        public Level1(IGameContext context)
        {
            _context = context;
        }

        public void Init()
        {
        }

        public void LoadContent()
        {
        }

        public void ContentLoaded()
        {
        }

        public void Update()
        {
        }

        public void Draw()
        {
            _context.Draw();
        }
    }
}

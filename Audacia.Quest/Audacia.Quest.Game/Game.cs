using Audacia.Quest.Core;
using Audacia.Quest.Core.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audacia.Quest
{
    public class Game
    {
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; } = DateTime.Now;

        public Game()
        {

        }

        public void Init()
        {
        }

        public void LoadContent()
        {

        }

        public void Update()
        {
            End = DateTime.Now;
            Time.DeltaTime = End.Ticks - Start.Ticks;

            // Do Some Stuff

            Start = End;
        }

        public void Draw()
        {

        }
    }
}

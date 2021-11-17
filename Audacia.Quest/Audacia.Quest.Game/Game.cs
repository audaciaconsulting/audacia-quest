using Audacia.Quest.Core;
using Audacia.Quest.Core.Events;
using Audacia.Quest.Core.Params;

namespace Audacia.Quest
{
    public class Game
    {
        private readonly IGameContext _conext;

        public Game(IGameContext conext)
        {
            _conext = conext;
        }

        public void Init()
        {
        }

        public void LoadContent()
        {
            _conext.AddAsset("assets/fox.png");
        }

        public void ContentLoaded()
        {

        }

        public void Update()
        {
        }

        public void Draw()
        {
            _conext.Draw();
        }
    }
}

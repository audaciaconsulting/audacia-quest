using Audacia.Quest.Core;
using Audacia.Quest.Core.Asset;
using Audacia.Quest.Core.Scene;
using Audacia.Quest.Scenes;

namespace Audacia.Quest
{
    public class Game : BaseGame
    {
        public Game(IGameContext conext) : base(conext)
        {
        }

        public override void Init()
        {
            SceneManager.Add(new MainMenu(Context));
        }
    }
}

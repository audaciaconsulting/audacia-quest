using Audacia.Quest.Core;
using Audacia.Quest.Core.Core;
using Audacia.Quest.Core.Events;
using Audacia.Quest.Core.Params;

namespace Audacia.Quest
{
    public class Game
    {
        private readonly IGameContext _context;

        public Game(IGameContext conext)
        {
            _context = conext;
        }

        public void Init()
        {
            SceneManager.Add(new MainMenu(_context));
            SceneManager.Add(new Level1(_context));
        }

        public void ContentLoaded()
        {
            SceneManager.GetCurrentScene().ContentLoaded();
        }

        public bool Update()
        {
            var reload = SceneManager.Load();
            SceneManager.GetCurrentScene().Update();

            return reload;
        }

        public void Draw()
        {
            SceneManager.GetCurrentScene().Draw();
        }
    }
}

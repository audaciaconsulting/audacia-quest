using Audacia.Quest.Core;
using Audacia.Quest.Core.Scene;
using Audacia.Quest.Scenes;

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

using Audacia.Quest.Core;
using Audacia.Quest.Core.Asset;
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

        public void ContentLoaded()
        {
            SceneManager.Init();
        }

        public bool Update()
        {
            var reload = SceneManager.Load();

            if (reload)
            {
                _context.LoadContent(AssetResolver.GetAll());
                Time.Start();
            }

            SceneManager.GetCurrentScene().Update();

            Time.Update();

            return reload;
        }

        public void Draw()
        {
            SceneManager.GetCurrentScene().Draw();
        }
    }
}

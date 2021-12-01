using Audacia.Quest.Core.Asset;
using Audacia.Quest.Core.Scene;

namespace Audacia.Quest.Core
{
    public abstract class BaseGame : IGame
    {
        protected readonly IGameContext Context;

        public BaseGame(IGameContext conext)
        {
            Context = conext;
        }

        public abstract void Init();

        public void ContentLoaded()
        {
            SceneManager.Init();
        }

        public bool Update()
        {
            var reload = SceneManager.Load();

            if (reload)
            {
                Context.LoadContent(AssetResolver.GetAll());
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

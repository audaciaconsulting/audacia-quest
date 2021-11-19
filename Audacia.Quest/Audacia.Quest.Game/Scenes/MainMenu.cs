using Audacia.Quest.Core;
using Audacia.Quest.Core.Core;
using Audacia.Quest.Core.Events;
using Audacia.Quest.Core.Params;

namespace Audacia.Quest
{
    public class MainMenu : IScene
    {
        private readonly IGameContext _context;

        public MainMenu(IGameContext context)
        {
            _context = context;
            EventsCollection.Subscribe<Keyboard>(EventConstants.KEY_DOWN, SwitchScene);
        }
        public void SwitchScene(Keyboard key)
        {
            SceneManager.SetCurrentScene(1);
        }

        public void Init()
        {
        }

        public void LoadContent()
        {
            _context.ClearAssets();
            _context.AddAsset("assets/fox.png");
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

using Audacia.Quest.Components;
using Audacia.Quest.Core;
using Audacia.Quest.Core.Scene;

namespace Audacia.Quest.Scenes
{
    public class MainMenu : BaseScene
    {
        public MainMenu(IGameContext context) : base(context)
        {
        }

        public override void Init()
        {
            AddComponent(new FoxComponent());
            AddComponent(new WizardComponent());
        }
    }
}

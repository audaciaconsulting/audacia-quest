using Audacia.Quest.Components;
using Audacia.Quest.Core;
using Audacia.Quest.Core.Asset;
using Audacia.Quest.Core.Scene;

namespace Audacia.Quest.Scenes
{
    public class MainMenu : BaseScene
    {
        private Sprite _fox { get; set; }
        private Sprite _magicianIdleSpritesheet { get; set; }

        public MainMenu(IGameContext context) : base(context)
        {
        }

        public override void LoadContent()
        {
            _fox = AssetResolver.AddSprite("assets/fox.png");
            _magicianIdleSpritesheet = AssetResolver.AddSprite("assets/Idle.png");

        }

        public override void Init()
        {
            AddComponent(new FoxComponent()
                .WithRenderer(_fox));

            AddComponent(new WizardComponent()
                .WithRenderer(_magicianIdleSpritesheet));
        }
    }
}

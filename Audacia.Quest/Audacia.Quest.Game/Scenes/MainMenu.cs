using Audacia.Quest.Components;
using Audacia.Quest.Core;
using Audacia.Quest.Core.Asset;
using Audacia.Quest.Core.Components.Shared;
using Audacia.Quest.Core.Scene;

namespace Audacia.Quest.Scenes
{
    public class MainMenu : BaseScene
    {
        private Sprite _fox { get; set; }
        private Sprite _wizardIdleSpritesheet { get; set; }
        private Sprite _wizardAttackSpritesheet { get; set; }

        public MainMenu(IGameContext context) : base(context)
        {
        }

        public override void LoadContent()
        {
            _fox = AssetResolver.AddSprite("assets/fox.png");
            _wizardIdleSpritesheet = AssetResolver.AddSprite("assets/Idle.png");
            _wizardAttackSpritesheet = AssetResolver.AddSprite("assets/Attack1.png");
        }

        public override void Init()
        {
            AddComponent(new FoxComponent()
                .WithRenderer(_fox));

            var wizardIdleAnimation = new AnimationComponent(_wizardIdleSpritesheet, 250, 250, 8);
            var wizardAttackAnimation = new AnimationComponent(_wizardAttackSpritesheet, 250, 250, 8);
            AddComponent(new WizardComponent()
                .WithComponent(wizardIdleAnimation)
                .WithComponent(wizardAttackAnimation));
        }
    }
}

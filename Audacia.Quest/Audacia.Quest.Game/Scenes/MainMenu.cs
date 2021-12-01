using Audacia.Quest.Components;
using Audacia.Quest.Core;
using Audacia.Quest.Core.Asset;
using Audacia.Quest.Core.Scene;

namespace Audacia.Quest.Scenes
{
    public class MainMenu : BaseScene
    {
        private Sprite _fox { get; set; }
        private Sprite _wizardIdleSpritesheet { get; set; }

        public MainMenu(IGameContext context) : base(context)
        {
        }

        public override void LoadContent()
        {
            _fox = AssetResolver.AddSprite("assets/fox.png");
            _wizardIdleSpritesheet = AssetResolver.AddSprite("assets/Idle.png");
        }

        public override void Init()
        {
            var fox1 = new FoxComponent().WithRenderer(_fox);
            fox1.Transform.Position = new System.Numerics.Vector2(150, 150);

            var fox2 = new FoxComponent().WithRenderer(_fox);
            fox2.Transform.Position = new System.Numerics.Vector2(150, 400);
            fox2.Transform.Rotation = 0.5f;

            AddComponent(fox1);
            AddComponent(fox2);

            AddComponent(new WizardComponent()
                .WithRenderer(_wizardIdleSpritesheet));
        }
    }
}

using Audacia.Quest.Core;
using Audacia.Quest.Core.Components;
using Audacia.Quest.Core.Components.Shared;
using Audacia.Quest.Core.Events;
using Audacia.Quest.Core.Params;
using System.Numerics;

namespace Audacia.Quest.Components
{
    public class WizardComponent : BaseComponent
    {
        private AnimationComponent idle;
        private AnimationComponent attack;

        public override void Init()
        {
            Transform.Position = new Vector2(400, 100);

            var anims = GetComponents<AnimationComponent>();

            idle = anims[0];
            attack = anims[1];

            attack.Enabled = false;
            attack.AnimationCompletedHandler += AttackComplete;

            EventsCollection.Subscribe<Keyboard>(EventConstants.KEY_UP, Attack);
        }

        public override void Update()
        {
        }

        private void AttackComplete()
        {
            idle.Enabled = true;
            attack.Enabled = false;
        }

        private void Attack(Keyboard keyboard)
        {
            if (idle.Enabled)
            {
                idle.Enabled = false;
                attack.Enabled = true;
            }
            else
            {
                attack.ResetAnimation();
            }
        }
    }
}

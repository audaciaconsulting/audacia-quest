using Audacia.Quest.Core.Asset;
using Audacia.Quest.Core.Components;
using System.Numerics;

namespace Audacia.Quest.Components
{
    public class WizardComponent : BaseComponent
    {
        public override void Init()
        {
            Transform.Position = new Vector2(400, 100);
        }

        public override void Update()
        {
        }
    }
}

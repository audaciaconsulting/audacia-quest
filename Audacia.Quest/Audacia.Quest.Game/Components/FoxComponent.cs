using Audacia.Quest.Core.Asset;
using Audacia.Quest.Core.Components;
using System.Numerics;

namespace Audacia.Quest.Components
{
    public class FoxComponent : BaseComponent
    {
        public override void Init()
        {
            Transform.Scale = new Vector2(0.1f, 0.1f);
        }

        public override void Update()
        {
        }
    }
}

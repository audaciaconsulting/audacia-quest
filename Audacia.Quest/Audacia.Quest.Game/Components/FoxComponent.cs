using Audacia.Quest.Core.Components;
using Audacia.Quest.Core.Renderer;
using System.Numerics;

namespace Audacia.Quest.Components
{
    public class FoxComponent : BaseComponent
    {
        public override void Init()
        {
            Renderer = new SpriteRenderer("assets/fox.png");
            Transform.Scale = new Vector2(0.1f, 0.1f);
        }

        public override void Update()
        {
        }
    }
}

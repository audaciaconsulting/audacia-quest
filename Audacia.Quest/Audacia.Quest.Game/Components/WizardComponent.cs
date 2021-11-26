using Audacia.Quest.Core.Components;
using Audacia.Quest.Core.Renderer;
using System.Numerics;

namespace Audacia.Quest.Components
{
    public class WizardComponent : BaseComponent
    {
        public override void Init()
        {
            Renderer = new SpriteSheetRenderer("assets/Idle.png", new Frame[8]
            {
                new Frame { X = 0, Y = 0, Width = 250, Height = 250 },
                new Frame { X = 250, Y = 0, Width = 250, Height = 250 },
                new Frame { X = 500, Y = 0, Width = 250, Height = 250 },
                new Frame { X = 750, Y = 0, Width = 250, Height = 250 },
                new Frame { X = 1000, Y = 0, Width = 250, Height = 250 },
                new Frame { X = 1250, Y = 0, Width = 250, Height = 250 },
                new Frame { X = 1500, Y = 0, Width = 250, Height = 250 },
                new Frame { X = 1750, Y = 0, Width = 250, Height = 250 }
            }, 8);
            Transform.Position = new Vector2(200, 0);
        }

        public override void Update()
        {
            //Transform.MoveX(1);
        }
    }
}

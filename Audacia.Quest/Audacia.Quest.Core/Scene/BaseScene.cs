using Audacia.Quest.Core.Asset;
using Audacia.Quest.Core.Components;

namespace Audacia.Quest.Core.Scene
{
    public abstract class BaseScene : IScene
    {
        private readonly IGameContext _context;
        private List<IComponent> Components { get; set; } = new List<IComponent>();

        public BaseScene(IGameContext context)
        {
            _context = context;
        }

        public void AddComponent(IComponent component)
        {
            Components.AddRange(DepthFirstTraversal(component));
        }

        public abstract void LoadContent();
        public abstract void Init();

        public void Reset()
        {
            Components.Clear();
            AssetResolver.Clear();
        }

        public void Update()
        {
            foreach (var component in Components)
            {
                if (component.Enabled)
                {
                    component.Update();
                }
            }
        }

        public void Draw()
        {
            foreach (var component in Components)
            {
                if (component.Enabled && component.Sprite != null)
                {
                    _context.Draw(component);
                }
            }
        }

        private IEnumerable<IComponent> DepthFirstTraversal(IComponent node)
        {
            var nodes = new Stack<IComponent>();
            nodes.Push(node);

            while (nodes.Count > 0)
            {
                var n = nodes.Pop();
                n.Init();
                yield return n;

                foreach (var child in n.Components)
                {
                    nodes.Push(child.Value);
                }
            }
        }
    }
}

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

        public abstract void Init();

        public void LoadContent()
        {
            _context.LoadContent(Components);
        }

        public void Reset()
        {
            Components.Clear();
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
                if (component.Enabled && component.Renderer != null)
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

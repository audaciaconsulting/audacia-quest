using Audacia.Quest.Core.Renderer;

namespace Audacia.Quest.Core.Components
{
    public abstract class BaseComponent : IComponent
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool Enabled { get; set; } = true;
        public Transform Transform { get; set; } = new Transform();
        public IComponent Parent { get; set; }
        public IDictionary<string, IComponent> Components { get; set; } = new Dictionary<string, IComponent>();
        public SpriteRenderer? Renderer { get; set; } = null;

        public void AddComponent(IComponent component)
        {
            if (component == null)
            {
                return;
            }

            component.Parent = Parent;
            var type = component.GetType();
            Components.Add(type.Name, component);
        }

        public TComponent? GetComponent<TComponent>()
            where TComponent : IComponent
        {
            var name = typeof(TComponent).Name;
            if (Components.ContainsKey(name))
            {
                return (TComponent)Components[name];
            }

            return default;
        }

        public abstract void Init();
        public abstract void Update();
    }
}

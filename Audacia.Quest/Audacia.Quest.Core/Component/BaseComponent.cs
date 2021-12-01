using Audacia.Quest.Core.Asset;

namespace Audacia.Quest.Core.Components
{
    public abstract class BaseComponent : IComponent
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool Enabled { get; set; } = true;
        public Transform Transform { get; set; } = new Transform();
        public IComponent Parent { get; set; }
        public IDictionary<string, IComponent> Components { get; set; } = new Dictionary<string, IComponent>();
        public Sprite Sprite { get; set; }

        public IComponent WithRenderer(Sprite sprite)
        {
            Sprite = sprite;
            return this;
        }

        public void AddComponent(IComponent component)
        {
            if (component == null)
            {
                return;
            }

            component.Parent = this;
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

        public void Loaded()
        {
            if(Sprite != null)
            {
                Sprite.CurrentFrame.X = 0;
                Sprite.CurrentFrame.Y = 0;
                Sprite.CurrentFrame.Width = Sprite.Width;
                Sprite.CurrentFrame.Height = Sprite.Height;
            }
        }

        public abstract void Init();
        public abstract void Update();
    }
}

using Audacia.Quest.Core.Asset;

namespace Audacia.Quest.Core.Components
{
    public abstract class BaseComponent : IComponent
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Transform Transform { get; set; } = new Transform();
        public IComponent Parent { get; set; }
        public List<ComponentMap> Components { get; set; } = new List<ComponentMap>();
        public Sprite Sprite { get; set; }

        private bool _enabled = true;

        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                var oldValue = _enabled;
                _enabled = value;

                if (_enabled && oldValue != _enabled)
                {
                    Init();
                }
            }
        }

        public IComponent WithRenderer(Sprite sprite)
        {
            Sprite = sprite;
            return this;
        }

        public IComponent WithComponent(IComponent component, bool enabled = true)
        {
            component.Enabled = enabled;
            AddComponent(component);
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
            Components.Add(new ComponentMap
            {
                Name = type.Name,
                Component = component
            });
        }

        public TComponent? GetComponent<TComponent>()
            where TComponent : IComponent
        {
            var name = typeof(TComponent).Name;

            var component = Components.FirstOrDefault(x => x.Name == nameof(TComponent));
            if (component != null)
            {
                return (TComponent)component.Component;
            }

            return default;
        }

        public IList<TComponent> GetComponents<TComponent>()
            where TComponent : IComponent
        {
            var name = typeof(TComponent).Name;

            return Components
                .Where(x => x.Name == name)
                .Select(c => (TComponent)c.Component)
                .ToList();
        }

        public void Loaded()
        {
            if (Sprite != null)
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

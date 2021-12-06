using Audacia.Quest.Core.Asset;

namespace Audacia.Quest.Core.Components
{
    public interface IComponent
    {
        Guid Id { get; set; }

        bool Enabled { get; set; }
        Transform Transform { get; set; }
        IComponent Parent { get; set; }
        List<ComponentMap> Components { get; set; }
        Sprite Sprite { get; set; }

        IComponent WithComponent(IComponent component, bool enabled = true);
        IComponent WithRenderer(Sprite sprite);
        void AddComponent(IComponent component);
        TComponent? GetComponent<TComponent>() where TComponent : IComponent;
        List<TComponent> GetComponents<TComponent>() where TComponent : IComponent;
        void Loaded();
        void Init();
        void Update();
    }
}

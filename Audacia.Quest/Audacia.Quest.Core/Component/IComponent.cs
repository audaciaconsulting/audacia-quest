using Audacia.Quest.Core.Renderer;

namespace Audacia.Quest.Core.Components
{
    public interface IComponent
    {
        Guid Id { get; set; }

        bool Enabled { get; set; }
        Transform Transform { get; set; }
        IComponent Parent { get; set; }
        IDictionary<string, IComponent> Components { get; set; }
        SpriteRenderer? Renderer { get; set; }

        void AddComponent(IComponent component);
        TComponent? GetComponent<TComponent>() where TComponent : IComponent;
        void Init();
        void Update();
    }
}

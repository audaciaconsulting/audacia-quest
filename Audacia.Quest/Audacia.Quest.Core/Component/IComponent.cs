using Audacia.Quest.Core.Asset;
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
        Sprite Sprite { get; set; }

        IComponent WithRenderer(Sprite sprite);
        void AddComponent(IComponent component);
        TComponent? GetComponent<TComponent>() where TComponent : IComponent;
        void Init();
        void Update();
    }
}

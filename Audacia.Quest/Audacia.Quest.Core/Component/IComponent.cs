namespace Audacia.Quest.Core.Core
{
    public interface IComponent
    {
        bool Enabled { get; set; }
        Transform Transform { get; set; }
        IComponent Parent { get; set; }
        IDictionary<string, IComponent> Components { get; set; }

        void AddComponent(IComponent component);
        TComponent? GetComponent<TComponent>() where TComponent : IComponent;
        void Init();
        void Update();
    }
}

using Audacia.Quest.Core.Components;

namespace Audacia.Quest.Core
{
    public interface IGameContext
    {
        void LoadContent(List<IComponent> components);

        Task Draw(IComponent component);
    }
}

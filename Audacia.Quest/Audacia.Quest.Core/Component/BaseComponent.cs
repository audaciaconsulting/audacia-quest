using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audacia.Quest.Core.Core
{
    public class BaseComponent : IComponent
    {
        public Transform Transform { get; set; }
        public IComponent Parent { get; set; }
        public IDictionary<string, IComponent> Components { get; set; } = new Dictionary<string, IComponent>();

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

        public IComponent GetComponent(string name)
        {
            if (Components.ContainsKey(name))
            {
                return Components[name];
            }

            return null;
        }
    }
}

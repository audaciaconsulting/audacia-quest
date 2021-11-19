using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audacia.Quest.Core.Core
{
    public interface IComponent
    {
        Transform Transform { get; set; }
        IComponent Parent { get; set; }
        IDictionary<string, IComponent> Components { get; set; }

        void AddComponent(IComponent component);
        IComponent GetComponent(string name);
    }
}

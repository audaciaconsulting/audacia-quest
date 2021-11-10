using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audacia.Quest.Core
{
    public delegate void PerformEvent<TParam>(TParam param);

    public interface IEvent<TParam>
    {
        void PerformEvent(TParam param);

        void Subscribe(PerformEvent<TParam> method);
    }
}

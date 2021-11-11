using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audacia.Quest.Core.Events
{
    public class BaseEvent<T> : IEvent<T>
    {
        private PerformEvent<T> _performEvent { get; set; }

        public void PerformEvent(T param)
        {
            _performEvent?.Invoke(param);
        }

        public void Subscribe(PerformEvent<T> method)
        {
            _performEvent += method;
        }

        public void Unsubscribe(PerformEvent<T> method)
        {
            if (_performEvent != null)
            {
                _performEvent -= method;
            }
        }
    }
}

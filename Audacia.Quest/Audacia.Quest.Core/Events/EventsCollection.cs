namespace Audacia.Quest.Core
{
    public class EventsCollection
    {
        private static IDictionary<string, object> AvailableEvents { get; set; } = new Dictionary<string, object>();

        public static void Add<T>(string name, IEvent<T> e)
        {
            if (!AvailableEvents.ContainsKey(name))
            {
                AvailableEvents.Add(name, e);
            }
        }

        public static void PerformEvent<T>(string name, T param)
        {
            if (AvailableEvents.ContainsKey(name))
            {
                var e = (IEvent<T>)AvailableEvents[name];
                e.PerformEvent(param);
            }
        }

        public static void Subscribe<T>(string name, PerformEvent<T> method)
        {
            if (AvailableEvents.ContainsKey(name))
            {
                var e = (IEvent<T>)AvailableEvents[name];
                e.Subscribe(method);
            }
        }

        public static void Unsubscribe<T>(string name, PerformEvent<T> method)
        {
            if (AvailableEvents.ContainsKey(name))
            {
                var e = (IEvent<T>)AvailableEvents[name];
                e.Unsubscribe(method);
            }
        }
    }
}

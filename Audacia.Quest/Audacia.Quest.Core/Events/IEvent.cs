namespace Audacia.Quest.Core
{
    public delegate void PerformEvent<TParam>(TParam param);

    public interface IEvent<TParam>
    {
        void PerformEvent(TParam param);

        void Subscribe(PerformEvent<TParam> method);

        void Unsubscribe(PerformEvent<TParam> method);
    }
}

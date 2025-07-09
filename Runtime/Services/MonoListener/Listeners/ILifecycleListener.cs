namespace PopupsManagement.Runtime.Services.MonoListener
{
    public interface ILifecycleListener<T> where T : struct
    {
        void OnEvent(in T data);
    }
}
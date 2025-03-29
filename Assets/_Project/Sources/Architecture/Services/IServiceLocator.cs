namespace Sources.Architecture.Services
{
    public interface IServiceLocator
    {
        T Register<T>(T newService);

        void Unregister<T>();

        T Get<T>();
    }
}
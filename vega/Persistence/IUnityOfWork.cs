using System.Threading.Tasks;

namespace vega.Persistence
{
    public interface IUnityOfWork
    {
        Task CompleteAsync();
    }
}
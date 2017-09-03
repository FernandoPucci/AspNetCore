using System.Threading.Tasks;

namespace vega.Core
{    public interface IUnityOfWork
    {
        Task CompleteAsync();
    }
}
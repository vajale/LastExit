using System.Threading.Tasks;
using Something.Scripts.Architecture.Services.ServiceLocator;

namespace Something.Scripts.Architecture.Services
{
    public interface IGameFactory : IService
    {
        
        void CreateEntity();
    }
}
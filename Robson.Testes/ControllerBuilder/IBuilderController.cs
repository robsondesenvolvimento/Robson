using System.Threading.Tasks;

namespace Robson.Testes.ControllerBuilder
{
    public interface IBuilderController<T>
    {
        Task<T> BuildController();
    }
}

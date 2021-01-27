using Robson.Services.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Robson.WebApplication.Services
{
    public interface ICarreiraService
    {
        Task<IEnumerable<CarreiraViewModel>> GetCarreiras();
        Task<CarreiraViewModel> GetCarreira(int id);
    }
}

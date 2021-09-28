using HiringAPI.Models;
using System.Threading.Tasks;

namespace HiringAPI.Services
{
    public interface ILogRequests
    {
        Task LogHiringRequestAsync(GetHiringResponse response);
    }
}
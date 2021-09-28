using HiringAPI.Models;
using System.Threading.Tasks;

namespace HiringAPI.Services
{
    public interface IHireEmployees
    {
        Task<GetHiringResponse> HireAsync(PostHiringRequest request);
    }
}
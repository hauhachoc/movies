using System;
using System.Threading.Tasks;
using movies.Models;
using movies.Models.Response;

namespace movies.Data
{
    public interface IRestService
    {
		Task<FilmsResponse> GetFilmsItemAsync(string page, string per_page);

		Task<BaseResponse> RegisterItemAsync(BaseUser item);

		Task<BaseResponse> LoginItemAsync(string email, string pw); 

        Task<BaseRes> ForgotPwItemAsync(string email);
	}
}

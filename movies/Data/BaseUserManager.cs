using System;
using System.Threading.Tasks;
using movies.Models;
using movies.Models.Response;

namespace movies.Data
{
    public class BaseUserManager
    {
        IRestService restService;
        public BaseUserManager(IRestService service)
        {
            restService = service; 
        }
		public Task<FilmsResponse> GetFilmsTasksAsync(string page, string per_page)
		{
			return restService.GetFilmsItemAsync(page, per_page);
		}

		public Task<BaseResponse> LoginTaskAsync(string email, string pw)
		{
			return restService.LoginItemAsync(email, pw);
		}

		public Task<BaseResponse> RegisterTaskAsync(BaseUser item)
		{
			return restService.RegisterItemAsync(item);
		}

		public Task<BaseRes> ForgotPwTaskAsync(string email)
		{
			return restService.ForgotPwItemAsync(email);
		}
	}
}

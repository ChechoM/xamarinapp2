using AppParqueadero.Data.Api;
using AppParqueadero.Data.Models.Dto;
using AppParqueadero.Resx;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppParqueadero.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountApi _accountApi;
        private readonly IAppUserSettingService _appUserSettingService;

        public AccountService(IAccountApi accountApi, IAppUserSettingService appUserSettingService)
        {
            _accountApi = accountApi;
            _appUserSettingService = appUserSettingService;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            try
            {
                var response = await _accountApi.LoginAsync(userName, password);

                if (response == null || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    
                    await Application.Current.MainPage.DisplayAlert(AppResources.LoginPageInvalidLoginTitle,
                                            AppResources.LoginPageInvalidLoginMessage, AppResources.OkText);
                    return false;
                }
                else
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<UserDto>(stringResponse);

                    if (user != null)
                    {
                        _appUserSettingService.UserName = user.UserName;
                        _appUserSettingService.UserToken = user.Token;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return false;
        }
    }
}

using Xamarin.Essentials;

namespace AppParqueadero.Services
{
    public class AppUserSettingService : IAppUserSettingService
    {
        private const string USERNAME_KEY = "UserNameKey";
        private const string IDUSER_KEY = "UserIdKey";
        private const string TOKEN_KEY = "TokenKey";

        public string UserName
        {
            get
            {
                return Preferences.Get(USERNAME_KEY, "");
            }
            set
            {
                Preferences.Set(USERNAME_KEY, value);
            }
        }

        public string IdUser
        {
            get
            {
                return Preferences.Get(IDUSER_KEY, "");
            }
            set
            {
                Preferences.Set(IDUSER_KEY, value);
            }
        }

        public string UserToken
        {
            get
            {
                return Preferences.Get(TOKEN_KEY, "");
            }
            set
            {
                Preferences.Set(TOKEN_KEY, value);
            }
        }


        public void Clear()
        {
            Preferences.Clear();
        }
    }
}

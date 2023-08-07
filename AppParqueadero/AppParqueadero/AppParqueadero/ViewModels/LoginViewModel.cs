using AppParqueadero.Views;
using AppParqueadero.ViewModels;
using Xamarin.Forms;

namespace AppParqueadero.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private bool _showMessage;
        private string _welcomeMessage;
        private Color _messageColor;

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }
        public Color MessageColor
        {
            get => _messageColor;
            set
            {
                if (_messageColor != value)
                {
                    _messageColor = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool ShowMessage
        {
            get => _showMessage;
            set
            {
                if (_showMessage != value)
                {
                    _showMessage = value;
                    OnPropertyChanged();
                }
            }
        }
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                if (_welcomeMessage != value)
                {
                    _welcomeMessage = value;
                    OnPropertyChanged();
                }
            }
        }
        public Command LoginCommand { get; }

        public string UserName { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if (ValidateFiels())
            {
                //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                if (Username == "smontoya" && Password == "1234")
                {
                    WelcomeMessage = "Inicio de sesión exitoso, " + "¡Bienvenido! " + Username + "!";
                    MessageColor = Color.Green;
                    await Shell.Current.GoToAsync($"//{nameof(ClientPage)}");
                }
                else
                {
                    ShowMessage = true;
                    MessageColor = Color.Red;
                    WelcomeMessage = "Usuario o contraseña incorrectos";
                }
            }

        }

        private bool ValidateFiels()
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
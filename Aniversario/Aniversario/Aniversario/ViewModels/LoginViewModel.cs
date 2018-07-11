namespace Aniversario.ViewModels
{
    using Aniversario.Views;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion
        #region Propierties
        public string Email
        {
            get { return this.email; }

            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }

            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }

            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }

            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion
        #region Constructors
        public LoginViewModel()
        {
            this.IsEnabled = true;
        }
        #endregion
        #region Commands
        public ICommand LoginCommand
        {
            get

            {

                return new RelayCommand(Login);

            }
        }



        private async void Login()

        {

            if (string.IsNullOrEmpty(this.Email))

            {

                await Application.Current.MainPage.DisplayAlert(

                    "Error",
                    "Debes ingresar un usuario, trata de adivinar",
                    "Aceptar"
                    );

                return;

            }



            if (string.IsNullOrEmpty(this.Password))

            {

                await Application.Current.MainPage.DisplayAlert(

                    "Error",
                    "Debes ingresar un password, trata de adivinar",
                    "Aceptar"
                    );

                return;

            }
            this.IsRunning = true;
            this.IsEnabled = false;
            if (this.Email != "bbelena.gutierrez@gmail.com")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Este no es el usuario, Pista: un Email",
                    "Aceptar");
                this.Email = string.Empty;
                return;

            }
            if (this.Password != "Culiche")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Este no es el password, Pista: ¿Cuál fue uno de los primeros apodos que te puse? (inicia mayuscula)",
                    "Aceptar");
                this.Password = string.Empty;
                return;

            }

            this.IsRunning = false;
            this.IsEnabled = true;

            await Application.Current.MainPage.DisplayAlert(
                    "Lo lograste!!!",
                    "Esto es con mucho amor, y es una versión Beta, mejorará con el pasar del tiempo.",
                    "Aceptar");
            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Palabras = new PalabrasViewModels();
            await Application.Current.MainPage.Navigation.PushAsync(new PalabrasPage());
        }
        #endregion
    }
}

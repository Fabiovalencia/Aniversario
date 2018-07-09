using System;
using System.Collections.Generic;
using System.Text;


namespace Aniversario.ViewModels
{
    using System.Windows.Input;
    public class LoginViewModel
    {
        #region Propierties
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public bool IsRunning
        {
            get;
            set;
        }
        #endregion
        #region Commands
        public ICommand MyProperty { get; set; }
        #endregion
    }
}

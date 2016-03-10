using System.ComponentModel;

namespace Exile.Models
{
    class LoginViewModel
    {
        private string _email = string.Empty;//Properties.Settings.Default.AccountEmail;
        private string _password;
        private int _id;

        public int Id { get; set;
            //get
            //{

            //}
            //set
            //{

            //}
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != null && _email == value) return;
                _email = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value != null && _password == value) return;
                _password = value;
            }
        }
    }
}

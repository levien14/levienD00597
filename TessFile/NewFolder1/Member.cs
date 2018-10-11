using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TessFile.NewFolder1
{
    class Member
    {
        private string _email;
        private string _password;
        private string _address;
        private string _phoneNumber;

        public string email { get => _email; set => _email = value; }
        public string password { get => _password; set => _password = value; }
        public string address { get => _address; set => _address = value; }
        public string phoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    }
}

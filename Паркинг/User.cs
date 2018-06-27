using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Паркинг
{
    public class User
    {
        public int id { get; private set; }
        public int parking { get; private set; }
        public string login { get; private set; }

        public User(int id, int parking, string login)
        {
            this.id = id;
            this.parking = parking;
            this.login = login;
        }
    }
}

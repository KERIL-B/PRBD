using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_exchange_postgres.Entities
{
     class Client : Object
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public int age { get; private set; }

        public Client(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }
    }
}

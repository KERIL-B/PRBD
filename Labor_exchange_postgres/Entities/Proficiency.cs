using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_exchange_postgres.Entities
{
    class Proficiency
    {
        public int id {  get; private set; }
        public string name {  get; private set; }

        public Proficiency(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}

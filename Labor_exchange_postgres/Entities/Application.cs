using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_exchange_postgres.Entities
{
    class dbApplication
    {
        public int id { get; private set; }
        public string comment { get; private set; }
        public int client_id { get; private set; }
        public string client { get; private set; }
        public string proficiency { get; private set; }

        public dbApplication(int id, string comment, int client_id, string client, string proficiency)
        {
            this.id = id;
            this.comment = comment;
            this.client = client;
            this.client_id = client_id;
            this.proficiency = proficiency;
        }
    }
}

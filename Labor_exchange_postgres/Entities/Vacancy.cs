using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_exchange_postgres.Entities
{
     class Vacancy
    {
        public int id { get; private set; }      
        public string proficiency { get; private set; }
        public string comment { get; private set; }
        public int company_id { get; private set; }
        public string company { get; private set; }


        public Vacancy(int id, string comment,int company_id, string company, string proficiency)
        {
            this.id = id;
            this.company_id = company_id;
            this.comment = comment;
            this.company = company;
            this.proficiency = proficiency;
        }
    }
}

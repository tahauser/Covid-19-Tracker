using System;
using System.Collections.Generic;

namespace Covid_19_Tracker.Entites
{
    public class CasPositif : Person
    {
        public TypeCasPositif Type { get; set; }
        public DateTime Date_Declaration { get; set; }
        public DateTime Date_Dernier_Contact { get; set; }
        public int Nombre_Contacts { get; set; }
        public IEnumerable<CasSuivi> casSuivis { get; set; }
    }
}

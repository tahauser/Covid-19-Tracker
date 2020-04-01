using System;
using System.Collections.Generic;

namespace Covid_19_Tracker.Entites
{
    public class CasSuivi : Person
    {
        public string Lien { get; set; }
        public DateTime DateDernierCreation { get; set; }
        public NiveauRisque NiveauRisque { get; set; }
        public DateTime DateFin { get; set; }
        public int NombreJours { get; set; }
        public bool Actif { get; set; }
        public CasPositif casPositif { get; set; }
        public IEnumerable<FicheSuivi> ficheSuivis { get; set; }
    }
}

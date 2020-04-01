using System;
using System.Collections.Generic;

namespace Covid_19_Tracker.Entites
{
    public class CasSuivi : Personne
    {
        public string Lien { get; set; }
        public DateTime DateDernierCreation { get; set; }
        public NiveauRisque NiveauRisque { get; set; }
        public DateTime DateFin { get; set; }
        public int NombreJours { get; set; }
        public bool Actif { get; set; }
        public CasPositif CasPositifParent { get; set; }
        public IEnumerable<FicheSuivi> FichesSuivi { get; set; }
    }
}

using System;
namespace Covid_19_Tracker.Entites
{
    public class Person
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CIN { get; set; }
        public Sexe Sex { get; set; }
        public string NumeroTel { get; set; }
        public Address address { get; set; }
    }
}

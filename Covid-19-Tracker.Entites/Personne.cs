namespace Covid_19_Tracker.Entites
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CIN { get; set; }
        public Sexe Sexe { get; set; }
        public string NumeroTel { get; set; }
        public Addresse Addresse { get; set; }
    }
}

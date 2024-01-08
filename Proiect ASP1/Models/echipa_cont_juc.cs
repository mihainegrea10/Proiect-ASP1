namespace Proiect_ASP.Models
{
    public class echipa_cont_juc
    {
        public Guid EchipaId { get; set; }
        public Echipa? Echipa { get; set; }
        public Guid JucatorId { get; set; }
        public Jucator Jucator { get; set; }

    }
}

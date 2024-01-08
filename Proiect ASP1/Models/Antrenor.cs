using Proiect_ASP.Models.Base;

namespace Proiect_ASP.Models
{
    public class Antrenor : BaseEntity
    {
        public string prenume { get; set; }
        public string nume_familie { get; set; }
        public DateTime? data_nastere { get; set; }
        public int trofee { get; set; }
        
        public Echipa Echipa { get; set; }
    }
}

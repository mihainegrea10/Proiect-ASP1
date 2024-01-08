using Proiect_ASP.Models;
using Proiect_ASP.Models.Base;

namespace Proiect_ASP1.Models
{
    public class Impresar : BaseEntity
    {
        public string prenume { get; set; }
        public string nume_familie { get; set; }
        public int jucatori_impresariati { get; set; }
        public ICollection<Jucator> jucators{ get; set; }
    }
}

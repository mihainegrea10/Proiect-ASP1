using Proiect_ASP.Models.Base;
using Proiect_ASP1.Models;
using System.ComponentModel.DataAnnotations;

namespace Proiect_ASP.Models
{
    public class Jucator:BaseEntity
    {
        public string prenume { get; set; }
        public string nume_familie { get; set; }
        public int aparitii { get; set; }

        public DateTime varsta { get; set; }
        public int goluri { get; set; }
        public Impresar? Impresar { get; set; }
        public Guid? ImpresarId { get; set; }

        
        public ICollection<echipa_cont_juc>? echipa_Cont_Jucs { get; set; }



    }
}

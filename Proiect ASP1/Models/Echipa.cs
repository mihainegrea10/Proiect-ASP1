using Proiect_ASP.Models.Base;

namespace Proiect_ASP.Models
{
    public class Echipa : BaseEntity
    {
        internal object echipa_cont_juc;

        public string Nume { get; set; }
        public string Localitate { get; set; }
        public DateTime Data_Infiintare { get; set; }
        public ICollection<echipa_cont_juc> echipa_Cont_Jucs { get; set; }
        public Antrenor Antrenor { get; set; }
        public Guid AntrenorId { get; set; }



    }
}

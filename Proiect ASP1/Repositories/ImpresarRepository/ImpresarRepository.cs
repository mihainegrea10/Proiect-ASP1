using Microsoft.EntityFrameworkCore;
using Proiect_ASP.Data;
using Proiect_ASP1.Models;
using System.Reflection.Metadata.Ecma335;

namespace Proiect_ASP1.Repositories.ImpresarRepository
{
    public class ImpresarRepository : GenericRepository.GenericRepository<Impresar>, IImpresarRepository
    {
        public ImpresarRepository(Context context) : base(context) { }
        public List<Impresar> GetAllWithInclude()
        {
            return _table.Include(x => x.jucators).ToList();
        }

        public List<Impresar> GetAllWithJoin()
        {
            var result = _table.Join(_context.jucators, impresar => impresar.Id, jucator => jucator.ImpresarId, (impresar, jucator) => new { impresar, jucator }).Select(obj => obj.impresar);

            return result.ToList();
        }
        public Impresar GetBynume_familie(string nume_familie)
        {
            return _table.FirstOrDefault(x => x.nume_familie.ToLower().Equals(nume_familie.ToLower()));
        }
    }
}

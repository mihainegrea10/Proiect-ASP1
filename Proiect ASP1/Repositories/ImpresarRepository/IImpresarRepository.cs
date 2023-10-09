using Proiect_ASP1.Models;
using Proiect_ASP1.Repositories.GenericRepository;

namespace Proiect_ASP1.Repositories.ImpresarRepository
{
    public interface IImpresarRepository:IGenericRepository<Impresar>
    {
        List<Impresar> GetAllWithInclude();
        List<Impresar> GetAllWithJoin();
        Impresar GetBynume_familie(string nume_familie);
    }
}

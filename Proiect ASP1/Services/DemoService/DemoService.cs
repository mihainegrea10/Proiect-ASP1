using Proiect_ASP1.Models;
using Proiect_ASP1.Models.DTOs;
using Proiect_ASP1.Repositories.ImpresarRepository;

namespace Proiect_ASP1.Services.DemoService
{
    public class DemoService : IDemoService
    {
        public IImpresarRepository _impresarRepository;
        public DemoService(IImpresarRepository impresarRepository)
        {
            _impresarRepository = impresarRepository;
        }
        public ImpresarResultDTO GetDataMappedBynume_familie(string nume_familie)
        {
            Impresar impresar = _impresarRepository.GetBynume_familie(nume_familie);
            ImpresarResultDTO result = new()
            {
                nume_familie = impresar.nume_familie,
                prenume = impresar.prenume,
                jucatori_impresariati = impresar.jucatori_impresariati,
                


        };
            return result;
        }
    }
}

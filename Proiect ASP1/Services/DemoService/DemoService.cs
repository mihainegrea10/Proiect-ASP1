using AutoMapper;
using Proiect_ASP1.Models;
using Proiect_ASP1.Models.DTOs;
using Proiect_ASP1.Repositories.ImpresarRepository;

namespace Proiect_ASP1.Services.DemoService
{
    public class DemoService : IDemoService
    {
        public IImpresarRepository _impresarRepository;
        private readonly IMapper _mapper;
        public DemoService(IImpresarRepository impresarRepository, IMapper mapper)
        {
            _impresarRepository = impresarRepository;
            _mapper = mapper;
        }
        public ImpresarResultDTO GetDataMappedBynume_familie(string nume_familie)
        {
            Impresar impresar = _impresarRepository.GetBynume_familie(nume_familie);
            /*ImpresarResultDTO result = new()
            {
                nume_familie = impresar.nume_familie,
                prenume = impresar.prenume,
                jucatori_impresariati = impresar.jucatori_impresariati,
                


        };*/
            ImpresarResultDTO result = _mapper.Map<ImpresarResultDTO>(impresar);
            return result;
        }
    }
}

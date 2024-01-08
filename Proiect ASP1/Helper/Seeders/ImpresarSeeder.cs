using Proiect_ASP.Data;
using Proiect_ASP.Models;
using Proiect_ASP1.Models;

namespace Proiect_ASP1.Helper.Seeders
{
    public class ImpresarSeeder
    {
        public readonly Context _context;

        public ImpresarSeeder(Context context)
        {
            _context = context;
        }
        public void SeedInitialImpresari()
        {
            if (!_context.impresars.Any())
            {
                var impresar1 = new Impresar
                {
                    prenume = "Paul",
                    nume_familie = "Mirea",
                    jucatori_impresariati=0
                };
                var impresar2 = new Impresar
                {
                    prenume = "Stanca",
                    nume_familie = "Razvan",
                    jucatori_impresariati = 0
                };

                impresar1.Id = Guid.NewGuid();
                impresar2.Id = Guid.NewGuid();
                _context.impresars.Add(impresar1);
                _context.impresars.Add(impresar2);
                _context.SaveChanges();


            }
        }
    }
}

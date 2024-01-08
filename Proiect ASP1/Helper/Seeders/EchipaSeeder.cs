using Proiect_ASP.Data;
using Proiect_ASP.Models;
using Proiect_ASP1.Models;

namespace Proiect_ASP1.Helper.Seeders
{
    public class EchipaSeeder
    {
        public readonly Context _context;

        public EchipaSeeder(Context context)
        {
            _context = context;
        }
        public void SeedInitialEchipai()
        {
            if (!_context.echipas.Any())
            {
                var echipa1 = new Echipa
                {
                    Nume = "Barcelona",
                    Localitate = "Barcelona"
                };
                var echipa2 = new Echipa
                {
                    Nume = "PSG",
                    Localitate = "Paris"
                };

                echipa1.Id = Guid.NewGuid();
                echipa2.Id = Guid.NewGuid();
                echipa1.AntrenorId = Guid.NewGuid();
                echipa2.AntrenorId = Guid.NewGuid();
                _context.echipas.Add(echipa1);
                _context.echipas.Add(echipa2);
                _context.SaveChanges();


            }
        }
    }
}

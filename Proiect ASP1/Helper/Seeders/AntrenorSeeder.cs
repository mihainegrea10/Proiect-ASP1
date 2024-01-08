using Microsoft.EntityFrameworkCore;
using Proiect_ASP.Data;
using Proiect_ASP.Models;

namespace Proiect_ASP1.Helper.Seeders
{
    public class AntrenorSeeder
    {
        public readonly Context _context;

        public AntrenorSeeder(Context context)
        {
            _context = context;
        }
        public void SeedInitialAntrenori()
        {
            if (!_context.antrenors.Any())
            {
                var antrenor1 = new Antrenor
                {
                    prenume = "Mihai",
                    nume_familie = "Negrea",
                    trofee = 3

                };
                var antrenor2 = new Antrenor
                {
                    prenume = "Andrei",
                    nume_familie = "Ion",
                    trofee = 5

                };
                _context.Add(antrenor1);
                _context.Add(antrenor2);
                _context.SaveChanges();
                
            }
        }
    }
}

using Proiect_ASP.Data;
using Proiect_ASP.Models;

namespace Proiect_ASP1.Helper.Seeders
{
    public class JucatorSeeder
    {
        public readonly Context _context;

        public JucatorSeeder(Context context)
        {
            _context = context;
        }
        
        public void SeedInitialJucatori()
        {
            if (!_context.jucators.Any())
            {
                var jucator1 = new Jucator
                {
                    prenume = "Hagi",
                    nume_familie = "Ionut",
                    aparitii = 120,
                    varsta = 27,
                    goluri = 31


                };
                var jucator2 = new Jucator
                {
                    prenume = "Marica",
                    nume_familie = "Andrei",
                    aparitii = 160,
                    varsta = 30,
                    goluri = 32


                };
                jucator1.Id = Guid.NewGuid();
                jucator2.Id = Guid.NewGuid();
                jucator1.ImpresarId = Guid.NewGuid();
                jucator2.ImpresarId= Guid.NewGuid();
                _context.jucators.Add(jucator1);
                _context.jucators.Add(jucator2);
                _context.SaveChanges();


            }
        }
    }
}

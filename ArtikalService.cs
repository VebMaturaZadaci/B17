using B17_Web_shop.Models;

namespace B17_Web_shop
{
    public class ArtikalService
    {
        private readonly string _filePath;

        public ArtikalService(IWebHostEnvironment webHostEnvironment)
        {
            _filePath = Path.Combine(webHostEnvironment.WebRootPath, "vebprodavnica.txt");
        }
        public List<Artikal> GetAllArtikli()
        {
            var artikli = new List<Artikal>();
            using (var reader = new StreamReader(_filePath))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine();
                    var artikal = new Artikal
                    {
                        Sifra = values.Substring(0, 5).Trim(),
                        Naziv = values.Substring(5, 24).Trim(),
                        Proizvodjac = values.Substring(30, 19).Trim(),
                        RAM = values.Substring(50, 4).Trim(),
                        TIP_CPU = values.Substring(55, 14).Trim(),
                        Kamera = values.Substring(70, 9).Trim(),
                        Ekran = float.Parse(values.Substring(80, 9).Trim()),
                        LokacijaSlika = values.Substring(90, 29).Trim(),
                        Cena = values.Substring(120, 10).Trim()
                    };
                    artikli.Add(artikal);
                }
            }
            return artikli;
        }

    }
}


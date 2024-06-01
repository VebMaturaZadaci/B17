using B17_Web_shop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace B17_Web_shop.Pages
{
    public class IndexModel : PageModel
    {
        string pom;
        public readonly IWebHostEnvironment _env;
        private readonly ILogger<IndexModel> _logger;
        private readonly ArtikalService _artikalService;
        public List<SelectListItem> Proizvodjacisl = new List<SelectListItem>();
        public List<SelectListItem> Ramsl = new List<SelectListItem>();
        public List<SelectListItem> Cpusl = new List<SelectListItem>();
        public List<SelectListItem> Kamerasl = new List<SelectListItem>();
        public List<SelectListItem> Ekransl = new List<SelectListItem>();
        [BindProperty]
        public string? proizvodjac { get; set; }
        [BindProperty]
        public string? ram { get; set; }
        [BindProperty]
        public string? cpu { get; set; }
        [BindProperty]
        public string? kamera { get; set; }
        [BindProperty]
        public string? ekran { get; set; }

        public List<Artikal> Artikli { get; set; }
        public List<Artikal> Artikalpom = new List<Artikal>();
        public IndexModel(ArtikalService artikalService, ILogger<IndexModel> logger, IWebHostEnvironment env)
        {
            _artikalService = artikalService;
            _logger = logger;
            _env = env;
        }
        public void OnGet()
        {
            Artikli = _artikalService.GetAllArtikli();
            Proizvodjacisl.Add(new SelectListItem("", ""));
            Ramsl.Add(new SelectListItem("", ""));
            Cpusl.Add(new SelectListItem("", ""));
            Kamerasl.Add(new SelectListItem("", ""));
            Ekransl.Add(new SelectListItem("", ""));

            foreach (var artikal in Artikli)
            {
                pom = artikal.LokacijaSlika;
                artikal.LokacijaSlika = Path.Combine(_env.WebRootPath, pom);

                if (Artikalpom.Count(x => x.Proizvodjac.Equals(artikal.Proizvodjac)) == 0)
                {
                    Proizvodjacisl.Add(new SelectListItem
                    {
                        Text = artikal.Proizvodjac,
                        Value = artikal.Proizvodjac
                    });
                }
                if (Artikalpom.Count(x => x.RAM.Equals(artikal.RAM)) == 0)
                {
                    Ramsl.Add(new SelectListItem
                    {
                        Text = artikal.RAM,
                        Value = artikal.RAM
                    });
                }
                if (Artikalpom.Count(x => x.TIP_CPU.Equals(artikal.TIP_CPU)) == 0)
                {
                    Cpusl.Add(new SelectListItem
                    {
                        Text = artikal.TIP_CPU,
                        Value = artikal.TIP_CPU
                    });
                }
                if (Artikalpom.Count(x => x.Kamera.Equals(artikal.Kamera)) == 0)
                {
                    Kamerasl.Add(new SelectListItem
                    {
                        Text = artikal.Kamera,
                        Value = artikal.Kamera
                    });
                }
                if (Artikalpom.Count(x => x.Ekran.Equals(artikal.Ekran)) == 0)
                {
                    Ekransl.Add(new SelectListItem
                    {
                        Text = artikal.Ekran.ToString(),
                        Value = artikal.Ekran.ToString()
                    });
                }
                Artikalpom.Add(new Artikal
                {
                    Proizvodjac = artikal.Proizvodjac,
                    RAM = artikal.RAM,
                    TIP_CPU = artikal.TIP_CPU,
                    Kamera = artikal.Kamera,
                    Ekran= artikal.Ekran,
                });

            }
        }
        public IActionResult OnPost()
        {
            Artikli = _artikalService.GetAllArtikli();
            Proizvodjacisl.Add(new SelectListItem("", ""));
            Ramsl.Add(new SelectListItem("", ""));
            Cpusl.Add(new SelectListItem("", ""));
            Kamerasl.Add(new SelectListItem("", ""));
            Ekransl.Add(new SelectListItem("", ""));

            foreach (var artikal in Artikli)
            {
                if (Artikalpom.Count(x => x.Proizvodjac.Equals(artikal.Proizvodjac)) == 0)
                {
                    Proizvodjacisl.Add(new SelectListItem
                    {
                        Text = artikal.Proizvodjac,
                        Value = artikal.Proizvodjac
                    });
                }
                if (Artikalpom.Count(x => x.RAM.Equals(artikal.RAM)) == 0)
                {
                    Ramsl.Add(new SelectListItem
                    {
                        Text = artikal.RAM,
                        Value = artikal.RAM
                    });
                }
                if (Artikalpom.Count(x => x.TIP_CPU.Equals(artikal.TIP_CPU)) == 0)
                {
                    Cpusl.Add(new SelectListItem
                    {
                        Text = artikal.TIP_CPU,
                        Value = artikal.TIP_CPU
                    });
                }
                if (Artikalpom.Count(x => x.Kamera.Equals(artikal.Kamera)) == 0)
                {
                    Kamerasl.Add(new SelectListItem
                    {
                        Text = artikal.Kamera,
                        Value = artikal.Kamera
                    });
                }
                if (Artikalpom.Count(x => x.Ekran.Equals(artikal.Ekran)) == 0)
                {
                    Ekransl.Add(new SelectListItem
                    {
                        Text = artikal.Ekran.ToString(),
                        Value = artikal.Ekran.ToString()
                    });
                }
                Artikalpom.Add(new Artikal
                {
                    Proizvodjac = artikal.Proizvodjac,
                    RAM = artikal.RAM,
                    TIP_CPU = artikal.TIP_CPU,
                    Kamera = artikal.Kamera,
                    Ekran = artikal.Ekran,
                });
            }
            if (proizvodjac != null)
            {
                Artikli.RemoveAll(x => !x.Proizvodjac.Contains(proizvodjac));
            }
            if (ram != null)
            {
                Artikli.RemoveAll(x => !x.RAM.Contains(ram));
            }
            if (cpu != null)
            {
                Artikli.RemoveAll(x => !x.TIP_CPU.Contains(cpu));
            }
            if (kamera != null)
            {
                Artikli.RemoveAll(x => !x.Kamera.Contains(kamera));
            }
            if (ekran != null)
            {
                Artikli.RemoveAll(x => !x.Ekran.ToString().Equals(ekran));
            }
            return Page();
        }
    }
}
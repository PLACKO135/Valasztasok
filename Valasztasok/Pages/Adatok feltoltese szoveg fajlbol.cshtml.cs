using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Valasztasok.Models;

namespace Valasztasok.Pages
{
    public class Adatok_feltoltese_szoveg_fajlbolModel : PageModel
    {
        public IWebHostEnvironment Environment { get; set; }
        public Valasztas_db_Context Context { get; set; }
        public Adatok_feltoltese_szoveg_fajlbolModel(IWebHostEnvironment webHostEnvironment, Valasztas_db_Context valasztas_Db_Context)
        {
            Context = valasztas_Db_Context;
            Environment = webHostEnvironment;
        }
        [BindProperty]
        public IFormFile UploadFile { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var UploadFilePath = Path.Combine(Environment.ContentRootPath, "uploads", UploadFile.FileName);

            using (var stream = new FileStream(UploadFilePath, FileMode.Create))
            {
                await UploadFile.CopyToAsync(stream);
            }

            StreamReader sr = new(UploadFilePath);
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var elemek = line.Split(" ");
                Jelolt ujJelolt = new Jelolt();
                Part ujPart = new Part();
                if (!Context.Partok.Select(x => x.Rovid_nev).Contains(elemek[4]))
                {
                    ujPart = new();
                    ujPart.Rovid_nev = elemek[4];
                    Context.Partok.Add(ujPart);
                }
                else
                {
                    ujPart= Context.Partok.Where(x => x.Rovid_nev == elemek[4]).First();
                }
                ujJelolt.Kerulet = int.Parse(elemek[0]);
                ujJelolt.Szavazatszam = int.Parse(elemek[1]);
                ujJelolt.Nev = elemek[2] + " " + elemek[3];
                ujPart.Rovid_nev = elemek[4];
                Context.Jeloltek.Add(ujJelolt);
                Context.Partok.Add(ujPart);
            }
            sr.Close();
            return Page();
        }
    }
}

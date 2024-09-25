using System.ComponentModel.DataAnnotations;

namespace Valasztasok.Models
{
    public class Part
    {
        [Key]
        public string Rovid_nev { get; set; }
        public int? Teljes_nev { get; set; }
        public ICollection<Jelolt> Jeloltek { get; set; }


    }
}

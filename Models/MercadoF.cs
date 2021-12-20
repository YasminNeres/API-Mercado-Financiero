using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoFinanciero.Models
{
    public class MercadoF
    {
        [Key]
        public string Nombre { get; set; }
        public decimal Ultimo  { get; set; }
        public decimal  Max { get; set; }
    }
}
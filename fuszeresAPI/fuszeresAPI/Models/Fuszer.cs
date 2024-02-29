using System.ComponentModel.DataAnnotations;

namespace fuszeresAPI.Models
{
    public class Fuszer
    {
        [Key]
        public string Fkod { get; set; }
        public string Fuszernev { get; set; }
        public int Egysegar { get; set; }
    }
}

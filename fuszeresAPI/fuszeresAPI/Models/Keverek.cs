using System.ComponentModel.DataAnnotations;

namespace fuszeresAPI.Models
{
    public class Keverek
    {
        [Key]
        public string Kkod { get; set; }
        public string Kevereknev { get; set; }
    }
}

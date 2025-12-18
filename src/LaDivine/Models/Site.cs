using System.ComponentModel.DataAnnotations;

namespace LaDivine.Models
{
    public class Site
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
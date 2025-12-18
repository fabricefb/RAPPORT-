using System.ComponentModel.DataAnnotations;

namespace LaDivine.Models
{
    public class Employe
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Poste { get; set; }
        public Guid SiteId { get; set; }
        public Site Site { get; set; }
    }
}
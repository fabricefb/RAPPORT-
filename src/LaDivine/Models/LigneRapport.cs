using System.ComponentModel.DataAnnotations;

namespace LaDivine.Models
{
    public class LigneRapport
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RapportJournalierId { get; set; }
        public RapportJournalier Rapport { get; set; }
        public Guid EmployeId { get; set; }
        public TimeSpan? HeureEntree { get; set; }
        public TimeSpan? Pause { get; set; }
        public TimeSpan? HeureSortie { get; set; }
        public decimal HeuresSupplementaires { get; set; }
        public string Remarque { get; set; }
    }
}
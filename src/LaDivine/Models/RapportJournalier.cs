using System.ComponentModel.DataAnnotations;

namespace LaDivine.Models
{
    public class RapportJournalier
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SiteId { get; set; }
        public Site Site { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastModifiedUtc { get; set; }
        public string Status { get; set; } // Draft / Sent / Conflicted
        public ICollection<LigneRapport> Lignes { get; set; } = new List<LigneRapport>();
        public ICollection<IndicateurJournalier> Indicateurs { get; set; } = new List<IndicateurJournalier>();
    }
}
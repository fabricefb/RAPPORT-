using System.ComponentModel.DataAnnotations;

namespace LaDivine.Models
{
    public class IndicateurJournalier
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RapportJournalierId { get; set; }
        public RapportJournalier Rapport { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
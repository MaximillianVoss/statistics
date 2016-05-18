namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_rapportrader
    {
        [Key]
        public long rapportradID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? rapportradDatum { get; set; }

        [StringLength(20)]
        public string rapportradStart { get; set; }

        [StringLength(20)]
        public string rapportradSlut { get; set; }

        public string rapportradKommentar { get; set; }

        public bool rapportradLunch { get; set; }

        public long? personalID { get; set; }

        [StringLength(20)]
        public string rapportradLunchStart { get; set; }

        [StringLength(20)]
        public string rapportradLunchSlut { get; set; }

        public long? periodID { get; set; }

        [StringLength(10)]
        public string rapportradPeriodStart { get; set; }

        [StringLength(10)]
        public string rapportradPeriodSlut { get; set; }

        public decimal? rapportradDebitering { get; set; }

        public decimal? rapportradLonegrund { get; set; }

        [StringLength(50)]
        public string rapportradKod { get; set; }

        public long? rapportinfoID { get; set; }

        public long? uppdragsID { get; set; }

        [StringLength(100)]
        public string rapportradNamn { get; set; }

        public long? rapporthuvudID { get; set; }

        [StringLength(50)]
        public string rapportradPeriodNamn { get; set; }

        [StringLength(100)]
        public string uppdragsNamn { get; set; }

        [StringLength(50)]
        public string rapportradReferens { get; set; }

        [Required]
        [StringLength(255)]
        public string rapportradRadinfoFaktura { get; set; }
    }
}

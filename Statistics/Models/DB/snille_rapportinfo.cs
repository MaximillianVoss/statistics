namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_rapportinfo
    {
        [Key]
        public long rapportinfoID { get; set; }

        [StringLength(50)]
        public string rapportinfoNamn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? rapportinfoStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? rapportinfoSlut { get; set; }

        public long? uppdragsID { get; set; }

        public short? rapportinfoTyp { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? rapportinfoSkapad { get; set; }

        [StringLength(50)]
        public string uppdragsNamn { get; set; }

        [StringLength(20)]
        public string uppdragsKod { get; set; }

        [StringLength(20)]
        public string uppdragsReferens { get; set; }

        public long? kundID { get; set; }

        public long? rapporthuvudID { get; set; }
    }
}

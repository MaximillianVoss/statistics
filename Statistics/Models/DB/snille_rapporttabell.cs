namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_rapporttabell
    {
        [Key]
        public long rapportID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? rapportDatum { get; set; }

        [StringLength(20)]
        public string rapportStart { get; set; }

        [StringLength(20)]
        public string rapportSlut { get; set; }

        public string rapportKommentar { get; set; }

        public bool rapportLunch { get; set; }

        public bool rapportHelg { get; set; }

        public bool rapportOvertid { get; set; }

        public long? personalID { get; set; }

        [StringLength(20)]
        public string uppdragsID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? rapporterad { get; set; }

        [StringLength(20)]
        public string rapportLunchStart { get; set; }

        [StringLength(20)]
        public string rapportLunchSlut { get; set; }

        public short? rapportGodkand { get; set; }

        public string rapportAdminKommentar { get; set; }

        [StringLength(50)]
        public string rapportKommentator { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime rapportGodkandTimestamp { get; set; }
    }
}

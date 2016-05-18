namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_kundtabell
    {
        [Key]
        public long kundID { get; set; }

        [StringLength(80)]
        public string kundNamn { get; set; }

        public short inaktiv { get; set; }

        [Required]
        [StringLength(100)]
        public string snilleReferens { get; set; }

        [Required]
        [StringLength(100)]
        public string kundEgetID { get; set; }

        [Required]
        [StringLength(45)]
        public string kundOrgnr { get; set; }

        [Required]
        [StringLength(255)]
        public string kundGata { get; set; }

        [Required]
        [StringLength(255)]
        public string kundBox { get; set; }

        [Required]
        [StringLength(45)]
        public string kundPostnummer { get; set; }

        [Required]
        [StringLength(255)]
        public string kundOrt { get; set; }

        [Required]
        [StringLength(255)]
        public string kundFullstandigtNamn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime senastUppdaterad { get; set; }

        public short rapporttyp { get; set; }
    }
}

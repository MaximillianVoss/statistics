namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_uppdragstabell
    {
        [Key]
        public long uppdragsID { get; set; }

        [StringLength(20)]
        public string uppdragsKod { get; set; }

        [StringLength(50)]
        public string uppdragsNamn { get; set; }

        [StringLength(20)]
        public string uppdragsReferens { get; set; }

        public long? kundID { get; set; }

        public short inaktiv { get; set; }

        public short global { get; set; }

        public short taMedDatum { get; set; }

        [Required]
        [StringLength(20)]
        public string uppdragsBeskrivning { get; set; }

        [Required]
        [StringLength(255)]
        public string radinfoFaktura { get; set; }
    }
}

namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_rapporthuvud
    {
        [Key]
        public long rapporthuvudID { get; set; }

        [Required]
        [StringLength(100)]
        public string rapporthuvudNamn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? rapporthuvudStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? rapporthuvudSlut { get; set; }

        public long? kundID { get; set; }

        public short? rapporthuvudTyp { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? rapporthuvudSkapad { get; set; }

        [StringLength(100)]
        public string kundNamn { get; set; }

        [Required]
        [StringLength(100)]
        public string rapporthuvudOrdernummer { get; set; }
    }
}

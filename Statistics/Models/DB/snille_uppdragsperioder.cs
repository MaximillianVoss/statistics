namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_uppdragsperioder
    {
        [Key]
        public long periodID { get; set; }

        [StringLength(20)]
        public string periodStart { get; set; }

        [StringLength(20)]
        public string periodSlut { get; set; }

        public decimal? periodDebitering { get; set; }

        public decimal? periodLonegrund { get; set; }

        public long uppdragsID { get; set; }

        public long? personalID { get; set; }

        public bool periodHelg { get; set; }

        public bool periodOvertid { get; set; }

        [StringLength(50)]
        public string periodKod { get; set; }

        [Required]
        [StringLength(50)]
        public string loneartID { get; set; }

        public bool franvaro { get; set; }
    }
}

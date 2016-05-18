namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_orttabell
    {
        [Key]
        public int ortID { get; set; }

        [StringLength(50)]
        public string ortNamn { get; set; }
    }
}

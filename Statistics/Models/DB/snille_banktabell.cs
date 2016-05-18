namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_banktabell
    {
        [Key]
        public int bankID { get; set; }

        [StringLength(20)]
        public string bankNamn { get; set; }
    }
}

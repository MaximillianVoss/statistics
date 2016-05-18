namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_anvtabell
    {
        [Key]
        public long anvID { get; set; }

        [StringLength(20)]
        public string anvNamn { get; set; }

        [StringLength(40)]
        public string anvLosen { get; set; }

        public int? anvTyp { get; set; }

        public short? last { get; set; }
    }
}

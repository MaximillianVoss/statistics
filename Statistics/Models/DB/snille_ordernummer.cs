namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_ordernummer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ordernummer { get; set; }

        public long? orderID { get; set; }
    }
}

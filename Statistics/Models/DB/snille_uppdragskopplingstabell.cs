namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_uppdragskopplingstabell
    {
        [Key]
        public long kopplingsID { get; set; }

        public long? uppdragsID { get; set; }

        public long? personalID { get; set; }

        public short roll { get; set; }
    }
}

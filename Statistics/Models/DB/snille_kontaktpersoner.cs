namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_kontaktpersoner
    {
        [Key]
        public long kontaktID { get; set; }

        [StringLength(80)]
        public string kontaktNamn { get; set; }

        [StringLength(50)]
        public string kontaktEmail1 { get; set; }

        [StringLength(50)]
        public string kontaktEmail2 { get; set; }

        [StringLength(50)]
        public string kontaktTelefon1 { get; set; }

        [StringLength(50)]
        public string kontakttelfon2 { get; set; }

        public string kontaktKommentar { get; set; }

        public long? kundID { get; set; }

        public bool referens { get; set; }
    }
}

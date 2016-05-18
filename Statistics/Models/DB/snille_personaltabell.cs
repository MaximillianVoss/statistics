namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_personaltabell
    {
        [Key]
        public long personalID { get; set; }

        [StringLength(20)]
        public string personalFornamn { get; set; }

        [StringLength(20)]
        public string personalEfternamn { get; set; }

        [StringLength(50)]
        public string personalAdressrad1 { get; set; }

        [StringLength(50)]
        public string personalAdressrad2 { get; set; }

        public long? personalPostnummer { get; set; }

        [StringLength(20)]
        public string personalPostort { get; set; }

        public long? personalPersonnummer { get; set; }

        [StringLength(20)]
        public string personalLonekonto { get; set; }

        [StringLength(50)]
        public string personalBank { get; set; }

        [Column(TypeName = "date")]
        public DateTime? personalAnstallningsdatum { get; set; }

        [StringLength(20)]
        public string personalTelefonHem { get; set; }

        [StringLength(20)]
        public string personalTelefonJobb { get; set; }

        [StringLength(20)]
        public string personalTelefonMobil { get; set; }

        [StringLength(50)]
        public string personalEmail { get; set; }

        public long anvID { get; set; }

        public short? personalHarManadslon { get; set; }

        public decimal? personalLon { get; set; }

        public short personalTyp { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime senastAndrad { get; set; }

        [Required]
        [StringLength(50)]
        public string personalAnstID { get; set; }
    }
}

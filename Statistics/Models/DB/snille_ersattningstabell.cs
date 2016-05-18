namespace Statistics.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class snille_ersattningstabell
    {
        [Key]
        public long ersattningsID { get; set; }

        public short? ersattningsTyp { get; set; }

        [StringLength(255)]
        public string ersattningsKommentar { get; set; }

        [StringLength(255)]
        public string ersattningsKommentar2 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ersattningsDatum { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ersattningsDatum2 { get; set; }

        public double? ersattningsAntal { get; set; }

        public double? ersattningsKostnadInkl { get; set; }

        public double? ersattningsKostnadExkl { get; set; }

        public short? ersattningsDebiteraVidare { get; set; }

        public long? ersattningsKopplaTillKund { get; set; }

        [StringLength(50)]
        public string ersattningsProjektnummer { get; set; }

        public long? ersattningsProjektID { get; set; }

        public short? ersattningsPaLon { get; set; }

        public short? ersattningsGodkand { get; set; }

        public long? personalID { get; set; }

        public long? uppdragsID { get; set; }

        public double? ersattningHeldagBelopp { get; set; }

        public double? ersattningHeldagAntal { get; set; }

        public double? ersattningHalvdagBelopp { get; set; }

        public double? ersattningHalvdagAntal { get; set; }

        public double? ersattningNattBelopp { get; set; }

        public double? ersattningNattAntal { get; set; }

        public double? ersattningFruBelopp { get; set; }

        public double? ersattningFruAntal { get; set; }

        public double? ersattningLunchBelopp { get; set; }

        public double? ersattningLunchAntal { get; set; }

        public double? ersattningMiddagBelopp { get; set; }

        public double? ersattningMiddagAntal { get; set; }

        public double? ersattningFruLuMiBelopp { get; set; }

        public double? ersattningFruLuMiAntal { get; set; }

        public short? ersattningsTraktamenteSverige { get; set; }

        [StringLength(255)]
        public string ersattningsAdminkommentar { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ersattningsGodkandTimestamp { get; set; }
    }
}

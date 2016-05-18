namespace Statistics.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Tables : DbContext
    {
        public Tables()
            : base("name=Tables")
        {
        }

        public virtual DbSet<snille_anvtabell> snille_anvtabell { get; set; }
        public virtual DbSet<snille_banktabell> snille_banktabell { get; set; }
        public virtual DbSet<snille_ersattningstabell> snille_ersattningstabell { get; set; }
        public virtual DbSet<snille_kontaktpersoner> snille_kontaktpersoner { get; set; }
        public virtual DbSet<snille_kundtabell> snille_kundtabell { get; set; }
        public virtual DbSet<snille_ordernummer> snille_ordernummer { get; set; }
        public virtual DbSet<snille_orttabell> snille_orttabell { get; set; }
        public virtual DbSet<snille_personaltabell> snille_personaltabell { get; set; }
        public virtual DbSet<snille_rapporthuvud> snille_rapporthuvud { get; set; }
        public virtual DbSet<snille_rapportinfo> snille_rapportinfo { get; set; }
        public virtual DbSet<snille_rapportrader> snille_rapportrader { get; set; }
        public virtual DbSet<snille_rapporttabell> snille_rapporttabell { get; set; }
        public virtual DbSet<snille_uppdragskopplingstabell> snille_uppdragskopplingstabell { get; set; }
        public virtual DbSet<snille_uppdragsperioder> snille_uppdragsperioder { get; set; }
        public virtual DbSet<snille_uppdragstabell> snille_uppdragstabell { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<snille_anvtabell>()
                .Property(e => e.anvNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_anvtabell>()
                .Property(e => e.anvLosen)
                .IsUnicode(false);

            modelBuilder.Entity<snille_banktabell>()
                .Property(e => e.bankNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_ersattningstabell>()
                .Property(e => e.ersattningsKommentar)
                .IsUnicode(false);

            modelBuilder.Entity<snille_ersattningstabell>()
                .Property(e => e.ersattningsKommentar2)
                .IsUnicode(false);

            modelBuilder.Entity<snille_ersattningstabell>()
                .Property(e => e.ersattningsProjektnummer)
                .IsUnicode(false);

            modelBuilder.Entity<snille_ersattningstabell>()
                .Property(e => e.ersattningsAdminkommentar)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kontaktpersoner>()
                .Property(e => e.kontaktNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kontaktpersoner>()
                .Property(e => e.kontaktEmail1)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kontaktpersoner>()
                .Property(e => e.kontaktEmail2)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kontaktpersoner>()
                .Property(e => e.kontaktTelefon1)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kontaktpersoner>()
                .Property(e => e.kontakttelfon2)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kontaktpersoner>()
                .Property(e => e.kontaktKommentar)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kundtabell>()
                .Property(e => e.kundNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kundtabell>()
                .Property(e => e.snilleReferens)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kundtabell>()
                .Property(e => e.kundEgetID)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kundtabell>()
                .Property(e => e.kundOrgnr)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kundtabell>()
                .Property(e => e.kundGata)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kundtabell>()
                .Property(e => e.kundBox)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kundtabell>()
                .Property(e => e.kundPostnummer)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kundtabell>()
                .Property(e => e.kundOrt)
                .IsUnicode(false);

            modelBuilder.Entity<snille_kundtabell>()
                .Property(e => e.kundFullstandigtNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_orttabell>()
                .Property(e => e.ortNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalFornamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalEfternamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalAdressrad1)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalAdressrad2)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalPostort)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalLonekonto)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalBank)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalTelefonHem)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalTelefonJobb)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalTelefonMobil)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalEmail)
                .IsUnicode(false);

            modelBuilder.Entity<snille_personaltabell>()
                .Property(e => e.personalAnstID)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapporthuvud>()
                .Property(e => e.rapporthuvudNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapporthuvud>()
                .Property(e => e.kundNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapporthuvud>()
                .Property(e => e.rapporthuvudOrdernummer)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportinfo>()
                .Property(e => e.rapportinfoNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportinfo>()
                .Property(e => e.uppdragsNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportinfo>()
                .Property(e => e.uppdragsKod)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportinfo>()
                .Property(e => e.uppdragsReferens)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradStart)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradSlut)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradKommentar)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradLunchStart)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradLunchSlut)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradPeriodStart)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradPeriodSlut)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradKod)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradPeriodNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.uppdragsNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradReferens)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapportrader>()
                .Property(e => e.rapportradRadinfoFaktura)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapporttabell>()
                .Property(e => e.rapportStart)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapporttabell>()
                .Property(e => e.rapportSlut)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapporttabell>()
                .Property(e => e.rapportKommentar)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapporttabell>()
                .Property(e => e.uppdragsID)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapporttabell>()
                .Property(e => e.rapportLunchStart)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapporttabell>()
                .Property(e => e.rapportLunchSlut)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapporttabell>()
                .Property(e => e.rapportAdminKommentar)
                .IsUnicode(false);

            modelBuilder.Entity<snille_rapporttabell>()
                .Property(e => e.rapportKommentator)
                .IsUnicode(false);

            modelBuilder.Entity<snille_uppdragsperioder>()
                .Property(e => e.periodStart)
                .IsUnicode(false);

            modelBuilder.Entity<snille_uppdragsperioder>()
                .Property(e => e.periodSlut)
                .IsUnicode(false);

            modelBuilder.Entity<snille_uppdragsperioder>()
                .Property(e => e.periodKod)
                .IsUnicode(false);

            modelBuilder.Entity<snille_uppdragsperioder>()
                .Property(e => e.loneartID)
                .IsUnicode(false);

            modelBuilder.Entity<snille_uppdragstabell>()
                .Property(e => e.uppdragsKod)
                .IsUnicode(false);

            modelBuilder.Entity<snille_uppdragstabell>()
                .Property(e => e.uppdragsNamn)
                .IsUnicode(false);

            modelBuilder.Entity<snille_uppdragstabell>()
                .Property(e => e.uppdragsReferens)
                .IsUnicode(false);

            modelBuilder.Entity<snille_uppdragstabell>()
                .Property(e => e.uppdragsBeskrivning)
                .IsUnicode(false);

            modelBuilder.Entity<snille_uppdragstabell>()
                .Property(e => e.radinfoFaktura)
                .IsUnicode(false);
        }
    }
}

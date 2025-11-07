using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cs_bdas2_web.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CivilZamestnanci> CivilZamestnancis { get; set; }

    public virtual DbSet<Dovolenky> Dovolenkies { get; set; }

    public virtual DbSet<Hodnosti> Hodnostis { get; set; }

    public virtual DbSet<Lide> Lides { get; set; }

    public virtual DbSet<LideSmazani> LideSmazanis { get; set; }

    public virtual DbSet<LideZajmy> LideZajmies { get; set; }

    public virtual DbSet<LogTable> LogTables { get; set; }

    public virtual DbSet<Lokality> Lokalities { get; set; }

    public virtual DbSet<Mise> Mises { get; set; }

    public virtual DbSet<Oddeleni> Oddelenis { get; set; }

    public virtual DbSet<Osoby> Osobies { get; set; }

    public virtual DbSet<Pohotovosti> Pohotovostis { get; set; }

    public virtual DbSet<Pozice> Pozices { get; set; }

    public virtual DbSet<Skoleni> Skolenis { get; set; }

    public virtual DbSet<Techniky> Technikies { get; set; }

    public virtual DbSet<Utvary> Utvaries { get; set; }

    public virtual DbSet<ViewVojaci> ViewVojacis { get; set; }

    public virtual DbSet<Vojaci> Vojacis { get; set; }

    public virtual DbSet<Vyznamenani> Vyznamenanis { get; set; }

    public virtual DbSet<Zajmy> Zajmies { get; set; }

    public virtual DbSet<Zbrane> Zbranes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseOracle("Name=ConnectionStrings:OracleConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ST72577")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<CivilZamestnanci>(entity =>
        {
            entity.HasKey(e => e.IdOsoba).HasName("CIVIL_ZAMESTNANEC_PK");

            entity.ToTable("CIVIL_ZAMESTNANCI");

            entity.Property(e => e.IdOsoba)
                .ValueGeneratedOnAdd()
                .HasComment("Tabulka civilní zaměstnanec  je informační centrum oledně každého civ. zaměstnance. V případě potřeby lze vyhledat jeho informace oddělení a pracovní pozic.i")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_OSOBA");
            entity.Property(e => e.IdOddeleni)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_ODDELENI");
            entity.Property(e => e.IdPozice)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_POZICE");

            entity.HasOne(d => d.IdOddeleniNavigation).WithMany(p => p.CivilZamestnancis)
                .HasForeignKey(d => d.IdOddeleni)
                .HasConstraintName("CIVIL_ZAMESTNANEC_ODDELENI_FK");

            entity.HasOne(d => d.IdOsobaNavigation).WithOne(p => p.CivilZamestnanci)
                .HasForeignKey<CivilZamestnanci>(d => d.IdOsoba)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CIVIL_ZAMESTNANEC_OSOBA_FK");

            entity.HasOne(d => d.IdPoziceNavigation).WithMany(p => p.CivilZamestnancis)
                .HasForeignKey(d => d.IdPozice)
                .HasConstraintName("CIVIL_ZAMESTNANEC_POZICE_FK");
        });

        modelBuilder.Entity<Dovolenky>(entity =>
        {
            entity.HasKey(e => e.IdDovolenka).HasName("DOVOLENKA_PK");

            entity.ToTable("DOVOLENKY");

            entity.Property(e => e.IdDovolenka)
                .HasComment("Dovolenka je možná pro každou osobu v databázi. Pokud je uznáno datum zahájení, tak datum ukončení později také.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_DOVOLENKA");
            entity.Property(e => e.DatumUkonceni)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_UKONCENI");
            entity.Property(e => e.DatumZahajeni)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_ZAHAJENI");
            entity.Property(e => e.Duvod)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DUVOD");
        });

        modelBuilder.Entity<Hodnosti>(entity =>
        {
            entity.HasKey(e => e.IdHodnost).HasName("HODNOST_PK");

            entity.ToTable("HODNOSTI");

            entity.Property(e => e.IdHodnost)
                .HasComment("Hodnost vojákovi dodává informaci o jeho hierarchické pozici.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_HODNOST");
            entity.Property(e => e.Nazev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAZEV");
        });

        modelBuilder.Entity<Lide>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00271144");

            entity.ToTable("LIDE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Adresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ADRESA");
            entity.Property(e => e.DatumNar)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("DATUM_NAR");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("EMAIL");
            entity.Property(e => e.Jmeno)
                .HasMaxLength(25)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("JMENO");
            entity.Property(e => e.Prijmeni)
                .HasMaxLength(25)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRIJMENI");
            entity.Property(e => e.RodCis)
                .HasPrecision(10)
                .ValueGeneratedOnAdd()
                .HasColumnName("ROD_CIS");
            entity.Property(e => e.Telefon)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("TELEFON");
            entity.Property(e => e.Validni)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(1)")
                .HasColumnName("VALIDNI");
        });

        modelBuilder.Entity<LideSmazani>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00271148");

            entity.ToTable("LIDE_SMAZANI");

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Adresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ADRESA");
            entity.Property(e => e.DatumNar)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_NAR");
            entity.Property(e => e.DatumSmazani)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_SMAZANI");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Jmeno)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("JMENO");
            entity.Property(e => e.Prijmeni)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PRIJMENI");
            entity.Property(e => e.RodCis)
                .HasPrecision(10)
                .HasColumnName("ROD_CIS");
            entity.Property(e => e.Telefon)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFON");
            entity.Property(e => e.Validni)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("VALIDNI");
        });

        modelBuilder.Entity<LideZajmy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LIDE_ZAJMY");

            entity.Property(e => e.IdLid)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_LID");
            entity.Property(e => e.IdZaj)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_ZAJ");
        });

        modelBuilder.Entity<LogTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LOG_TABLE");

            entity.Property(e => e.Cas)
                .HasPrecision(6)
                .HasColumnName("CAS");
            entity.Property(e => e.Operace)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERACE");
            entity.Property(e => e.Tabulka)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("TABULKA");
            entity.Property(e => e.Uzivatel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UZIVATEL");
        });

        modelBuilder.Entity<Lokality>(entity =>
        {
            entity.HasKey(e => e.IdLokalita).HasName("LOKALITA_PK");

            entity.ToTable("LOKALITY");

            entity.Property(e => e.IdLokalita)
                .HasComment("Lokalita je pro misi nezbytnou součástí. X a Y souřadnice jsou díky technologiím možné, a povinné udávat. Ulice, psč či obec jsou jen informační doplněk.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_LOKALITA");
            entity.Property(e => e.CisloPopisne)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CISLO_POPISNE");
            entity.Property(e => e.Obec)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OBEC");
            entity.Property(e => e.Psc)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PSC");
            entity.Property(e => e.SouradniceX)
                .HasColumnType("NUMBER")
                .HasColumnName("SOURADNICE_X");
            entity.Property(e => e.SouradniceY)
                .HasColumnType("NUMBER")
                .HasColumnName("SOURADNICE_Y");
            entity.Property(e => e.Ulice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ULICE");
        });

        modelBuilder.Entity<Mise>(entity =>
        {
            entity.HasKey(e => e.IdMise).HasName("MISE_PK");

            entity.ToTable("MISE");

            entity.HasIndex(e => e.Nazev, "MISE_NAZEV_UN").IsUnique();

            entity.Property(e => e.IdMise)
                .HasComment("Mise nemusí mít pro svoji existenci zadaný datum ani popis. Může zatím jít pouze o plánování.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_MISE");
            entity.Property(e => e.DatumUkonceni)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_UKONCENI");
            entity.Property(e => e.DatumZahajeni)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_ZAHAJENI");
            entity.Property(e => e.IdLokalita)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_LOKALITA");
            entity.Property(e => e.Nazev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAZEV");
            entity.Property(e => e.Popis)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("POPIS");

            entity.HasOne(d => d.IdLokalitaNavigation).WithMany(p => p.Mises)
                .HasForeignKey(d => d.IdLokalita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MISE_LOKALITA_FK");
        });

        modelBuilder.Entity<Oddeleni>(entity =>
        {
            entity.HasKey(e => e.IdOddeleni).HasName("ODDELENI_PK");

            entity.ToTable("ODDELENI");

            entity.Property(e => e.IdOddeleni)
                .HasComment("Oddělení je informace pro civilního zaměstnance.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_ODDELENI");
            entity.Property(e => e.Nazev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAZEV");
        });

        modelBuilder.Entity<Osoby>(entity =>
        {
            entity.HasKey(e => e.IdOsoba).HasName("OSOBA_PK");

            entity.ToTable("OSOBY");

            entity.HasIndex(e => e.Email, "OSOBA_EMAIL_UN").IsUnique();

            entity.HasIndex(e => e.RodneCislo, "OSOBA_RODNECISLO_UN").IsUnique();

            entity.HasIndex(e => e.Telefon, "OSOBA_TELEFON_UN").IsUnique();

            entity.Property(e => e.IdOsoba)
                .HasComment("Tabulka osoba  je informační centrum oledně každou osobu v databázi. Může jít i o vojáka nebo o civilního zaměstnance. Všechny osobní údaje zahrnuté jsou povinné.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_OSOBA");
            entity.Property(e => e.DatumNarozeni)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_NAROZENI");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IdDovolenka)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_DOVOLENKA");
            entity.Property(e => e.IdNadrizeny)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_NADRIZENY");
            entity.Property(e => e.IdUtvar)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_UTVAR");
            entity.Property(e => e.Jmeno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("JMENO");
            entity.Property(e => e.Prijmeni)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIJMENI");
            entity.Property(e => e.Prirazeni)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRIRAZENI");
            entity.Property(e => e.RodneCislo)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RODNE_CISLO");
            entity.Property(e => e.Telefon)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TELEFON");

            entity.HasOne(d => d.IdDovolenkaNavigation).WithMany(p => p.Osobies)
                .HasForeignKey(d => d.IdDovolenka)
                .HasConstraintName("OSOBA_DOVOLENKA_FK");

            entity.HasOne(d => d.IdNadrizenyNavigation).WithMany(p => p.InverseIdNadrizenyNavigation)
                .HasForeignKey(d => d.IdNadrizeny)
                .HasConstraintName("OSOBA_OSOBA_FK");

            entity.HasOne(d => d.IdUtvarNavigation).WithMany(p => p.Osobies)
                .HasForeignKey(d => d.IdUtvar)
                .HasConstraintName("OSOBA_UTVAR_FK");
        });

        modelBuilder.Entity<Pohotovosti>(entity =>
        {
            entity.HasKey(e => e.IdPohotovosti).HasName("POHOTOVOST_PK");

            entity.ToTable("POHOTOVOSTI");

            entity.Property(e => e.IdPohotovosti)
                .HasComment("Pohotovost uděluje vojákovy úroveň, ve které voják momentálně je. Popis je nezbytný dodatek pro zlepšení informace.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_POHOTOVOSTI");
            entity.Property(e => e.Popis)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("POPIS");
            entity.Property(e => e.Uroven)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("UROVEN");
        });

        modelBuilder.Entity<Pozice>(entity =>
        {
            entity.HasKey(e => e.IdPozice).HasName("POZICE_PK");

            entity.ToTable("POZICE");

            entity.Property(e => e.IdPozice)
                .HasComment("Pozice je informace pro civilního zaměstnance.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_POZICE");
            entity.Property(e => e.Nazev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAZEV");
        });

        modelBuilder.Entity<Skoleni>(entity =>
        {
            entity.HasKey(e => e.IdSkoleni).HasName("SKOLENI_PK");

            entity.ToTable("SKOLENI");

            entity.Property(e => e.IdSkoleni)
                .HasComment("Školení je pro vojáka nezbytné. Může být ale vytvořeno i bez přímého zahájení, tedy i bez aktuálních vojáků. Jakmile ale bude s dostatečným počtem zahájeno, ude muset býti i do nějaké doby ukončeno.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_SKOLENI");
            entity.Property(e => e.DatumUkonceni)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_UKONCENI");
            entity.Property(e => e.DatumZahajeni)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_ZAHAJENI");
            entity.Property(e => e.Nazev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAZEV");
            entity.Property(e => e.Poznamka)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("POZNAMKA");
        });

        modelBuilder.Entity<Techniky>(entity =>
        {
            entity.HasKey(e => e.IdTechnika).HasName("TECHNIKA_PK");

            entity.ToTable("TECHNIKY");

            entity.Property(e => e.IdTechnika)
                .HasComment("Technika musí mít datum výroby z důvodu bezpečí. Je také povinno býti uloženo v určitém útvaru.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_TECHNIKA");
            entity.Property(e => e.DatumVyroby)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_VYROBY");
            entity.Property(e => e.IdUtvar)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_UTVAR");
            entity.Property(e => e.Nazev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAZEV");

            entity.HasOne(d => d.IdUtvarNavigation).WithMany(p => p.Technikies)
                .HasForeignKey(d => d.IdUtvar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TECHNIKA_UTVAR_FK");
        });

        modelBuilder.Entity<Utvary>(entity =>
        {
            entity.HasKey(e => e.IdUtvar).HasName("UTVAR_PK");

            entity.ToTable("UTVARY");

            entity.HasIndex(e => e.Nazev, "UTVAR_NAZEV_UN").IsUnique();

            entity.Property(e => e.IdUtvar)
                .HasComment("Útvar nabízí útočiště jak pro osovy, tak i zbraně a techniku.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_UTVAR");
            entity.Property(e => e.Nazev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAZEV");
        });

        modelBuilder.Entity<ViewVojaci>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_VOJACI");

            entity.Property(e => e.Jmeno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("JMENO");
            entity.Property(e => e.Mise)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MISE");
            entity.Property(e => e.Prijmeni)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIJMENI");
        });

        modelBuilder.Entity<Vojaci>(entity =>
        {
            entity.HasKey(e => e.IdOsoba).HasName("VOJAK_PK");

            entity.ToTable("VOJACI");

            entity.Property(e => e.IdOsoba)
                .ValueGeneratedOnAdd()
                .HasComment("Tabulka voják je informační centrum oledně každého vojáka. V případě potřeby lze vyhledat jeho informace jako pohotovost, vyznamenání, jestli nemá aktuálně misi.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_OSOBA");
            entity.Property(e => e.IdHodnost)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_HODNOST");
            entity.Property(e => e.IdMise)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_MISE");
            entity.Property(e => e.IdPohotovost)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_POHOTOVOST");
            entity.Property(e => e.IdVyznamenani)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_VYZNAMENANI");

            entity.HasOne(d => d.IdHodnostNavigation).WithMany(p => p.Vojacis)
                .HasForeignKey(d => d.IdHodnost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VOJAK_HODNOST_FK");

            entity.HasOne(d => d.IdMiseNavigation).WithMany(p => p.Vojacis)
                .HasForeignKey(d => d.IdMise)
                .HasConstraintName("VOJAK_MISE_FK");

            entity.HasOne(d => d.IdOsobaNavigation).WithOne(p => p.Vojaci)
                .HasForeignKey<Vojaci>(d => d.IdOsoba)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VOJAK_OSOBA_FK");

            entity.HasOne(d => d.IdPohotovostNavigation).WithMany(p => p.Vojacis)
                .HasForeignKey(d => d.IdPohotovost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VOJAK_POHOTOVOST_FK");

            entity.HasOne(d => d.IdVyznamenaniNavigation).WithMany(p => p.Vojacis)
                .HasForeignKey(d => d.IdVyznamenani)
                .HasConstraintName("VOJAK_VYZNAMENANI_FK");

            entity.HasMany(d => d.IdSkolenis).WithMany(p => p.IdVojaks)
                .UsingEntity<Dictionary<string, object>>(
                    "Revize",
                    r => r.HasOne<Skoleni>().WithMany()
                        .HasForeignKey("IdSkoleni")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("RELATION_16_SKOLENI_FK"),
                    l => l.HasOne<Vojaci>().WithMany()
                        .HasForeignKey("IdVojak")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("RELATION_16_VOJAK_FK"),
                    j =>
                    {
                        j.HasKey("IdVojak", "IdSkoleni").HasName("REVIZE_PK");
                        j.ToTable("REVIZE", tb => tb.HasComment("Voják musí plnit nebo mít splněné alespoň jedno školění. Školení může být zatím vytvořeno bez potřebných zájemců."));
                        j.IndexerProperty<decimal>("IdVojak")
                            .HasColumnType("NUMBER(38)")
                            .HasColumnName("ID_VOJAK");
                        j.IndexerProperty<decimal>("IdSkoleni")
                            .HasColumnType("NUMBER(38)")
                            .HasColumnName("ID_SKOLENI");
                    });
        });

        modelBuilder.Entity<Vyznamenani>(entity =>
        {
            entity.HasKey(e => e.IdVyznamenani).HasName("VYZNAMENANI_PK");

            entity.ToTable("VYZNAMENANI");

            entity.Property(e => e.IdVyznamenani)
                .HasComment("Vyznamenání může být vojákovi uděleno za nějakou mimořádnou činnost. Pokud tomu tak je, je povinnost mít zaevidováno datum udělení. Poznámka může být pro dodatečnou informaci.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_VYZNAMENANI");
            entity.Property(e => e.DatumUdeleni)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_UDELENI");
            entity.Property(e => e.Nazev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAZEV");
            entity.Property(e => e.Poznamka)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("POZNAMKA");
        });

        modelBuilder.Entity<Zajmy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C00271149");

            entity.ToTable("ZAJMY");

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Zajem)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ZAJEM");
        });

        modelBuilder.Entity<Zbrane>(entity =>
        {
            entity.HasKey(e => e.IdZbran).HasName("ZBRAN_PK");

            entity.ToTable("ZBRANE");

            entity.Property(e => e.IdZbran)
                .HasComment("Technika musí mít datum výroby z důvodu bezpečí. Je také povinno býti uloženo v určitém útvaru.")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_ZBRAN");
            entity.Property(e => e.DatumVyroby)
                .HasColumnType("DATE")
                .HasColumnName("DATUM_VYROBY");
            entity.Property(e => e.IdUtvar)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_UTVAR");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.Nazev)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAZEV");

            entity.HasOne(d => d.IdUtvarNavigation).WithMany(p => p.Zbranes)
                .HasForeignKey(d => d.IdUtvar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ZBRAN_UTVAR_FK");
        });
        modelBuilder.HasSequence("LIDE_SEQ");
        modelBuilder.HasSequence("S_CIVIL_ZAMESTNANCI");
        modelBuilder.HasSequence("S_DOVOLENKY");
        modelBuilder.HasSequence("S_HODNOSTI");
        modelBuilder.HasSequence("S_LOKALITY");
        modelBuilder.HasSequence("S_MISE");
        modelBuilder.HasSequence("S_ODDELENI");
        modelBuilder.HasSequence("S_OSOBY");
        modelBuilder.HasSequence("S_POHOTOVOSTI");
        modelBuilder.HasSequence("S_POZICE");
        modelBuilder.HasSequence("S_REVIZE");
        modelBuilder.HasSequence("S_SKOLENI");
        modelBuilder.HasSequence("S_TECHNIKY");
        modelBuilder.HasSequence("S_UTVARY");
        modelBuilder.HasSequence("S_VOJACI");
        modelBuilder.HasSequence("S_VYZNAMENANI");
        modelBuilder.HasSequence("S_ZBRANE");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

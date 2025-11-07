using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Osoby
{
    /// <summary>
    /// Tabulka osoba  je informační centrum oledně každou osobu v databázi. Může jít i o vojáka nebo o civilního zaměstnance. Všechny osobní údaje zahrnuté jsou povinné.
    /// </summary>
    public decimal IdOsoba { get; set; }

    public string RodneCislo { get; set; } = null!;

    public string Jmeno { get; set; } = null!;

    public string Prijmeni { get; set; } = null!;

    public DateTime DatumNarozeni { get; set; }

    public string Telefon { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal? IdNadrizeny { get; set; }

    public decimal? IdDovolenka { get; set; }

    public decimal? IdUtvar { get; set; }

    public string? Prirazeni { get; set; }

    public virtual CivilZamestnanci? CivilZamestnanci { get; set; }

    public virtual Dovolenky? IdDovolenkaNavigation { get; set; }

    public virtual Osoby? IdNadrizenyNavigation { get; set; }

    public virtual Utvary? IdUtvarNavigation { get; set; }

    public virtual ICollection<Osoby> InverseIdNadrizenyNavigation { get; set; } = new List<Osoby>();

    public virtual Vojaci? Vojaci { get; set; }
}

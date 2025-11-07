using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Mise
{
    /// <summary>
    /// Mise nemusí mít pro svoji existenci zadaný datum ani popis. Může zatím jít pouze o plánování.
    /// </summary>
    public decimal IdMise { get; set; }

    public string Nazev { get; set; } = null!;

    public DateTime? DatumZahajeni { get; set; }

    public DateTime? DatumUkonceni { get; set; }

    public string? Popis { get; set; }

    public decimal IdLokalita { get; set; }

    public virtual Lokality IdLokalitaNavigation { get; set; } = null!;

    public virtual ICollection<Vojaci> Vojacis { get; set; } = new List<Vojaci>();
}

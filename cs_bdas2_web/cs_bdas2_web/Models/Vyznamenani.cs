using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Vyznamenani
{
    /// <summary>
    /// Vyznamenání může být vojákovi uděleno za nějakou mimořádnou činnost. Pokud tomu tak je, je povinnost mít zaevidováno datum udělení. Poznámka může být pro dodatečnou informaci.
    /// </summary>
    public decimal IdVyznamenani { get; set; }

    public string Nazev { get; set; } = null!;

    public DateTime DatumUdeleni { get; set; }

    public string? Poznamka { get; set; }

    public virtual ICollection<Vojaci> Vojacis { get; set; } = new List<Vojaci>();
}

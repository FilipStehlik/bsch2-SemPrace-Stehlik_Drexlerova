using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Pohotovosti
{
    /// <summary>
    /// Pohotovost uděluje vojákovy úroveň, ve které voják momentálně je. Popis je nezbytný dodatek pro zlepšení informace.
    /// </summary>
    public decimal IdPohotovosti { get; set; }

    public decimal Uroven { get; set; }

    public string? Popis { get; set; }

    public virtual ICollection<Vojaci> Vojacis { get; set; } = new List<Vojaci>();
}

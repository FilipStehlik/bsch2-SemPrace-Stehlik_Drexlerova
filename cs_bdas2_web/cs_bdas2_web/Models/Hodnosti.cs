using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Hodnosti
{
    /// <summary>
    /// Hodnost vojákovi dodává informaci o jeho hierarchické pozici.
    /// </summary>
    public decimal IdHodnost { get; set; }

    public string Nazev { get; set; } = null!;

    public virtual ICollection<Vojaci> Vojacis { get; set; } = new List<Vojaci>();
}

using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Utvary
{
    /// <summary>
    /// Útvar nabízí útočiště jak pro osovy, tak i zbraně a techniku.
    /// </summary>
    public decimal IdUtvar { get; set; }

    public string Nazev { get; set; } = null!;

    public virtual ICollection<Osoby> Osobies { get; set; } = new List<Osoby>();

    public virtual ICollection<Techniky> Technikies { get; set; } = new List<Techniky>();

    public virtual ICollection<Zbrane> Zbranes { get; set; } = new List<Zbrane>();
}

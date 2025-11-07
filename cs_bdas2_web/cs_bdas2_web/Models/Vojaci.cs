using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class Vojaci
{
    /// <summary>
    /// Tabulka voják je informační centrum oledně každého vojáka. V případě potřeby lze vyhledat jeho informace jako pohotovost, vyznamenání, jestli nemá aktuálně misi.
    /// </summary>
    public decimal IdOsoba { get; set; }

    public decimal IdHodnost { get; set; }

    public decimal? IdMise { get; set; }

    public decimal? IdVyznamenani { get; set; }

    public decimal IdPohotovost { get; set; }

    public virtual Hodnosti IdHodnostNavigation { get; set; } = null!;

    public virtual Mise? IdMiseNavigation { get; set; }

    public virtual Osoby IdOsobaNavigation { get; set; } = null!;

    public virtual Pohotovosti IdPohotovostNavigation { get; set; } = null!;

    public virtual Vyznamenani? IdVyznamenaniNavigation { get; set; }

    public virtual ICollection<Skoleni> IdSkolenis { get; set; } = new List<Skoleni>();
}

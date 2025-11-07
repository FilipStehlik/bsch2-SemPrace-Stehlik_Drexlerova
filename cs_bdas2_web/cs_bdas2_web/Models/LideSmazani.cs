using System;
using System.Collections.Generic;

namespace cs_bdas2_web.Models;

public partial class LideSmazani
{
    public decimal Id { get; set; }

    public string Jmeno { get; set; } = null!;

    public string Prijmeni { get; set; } = null!;

    public DateTime DatumNar { get; set; }

    public bool? Validni { get; set; }

    public string? Telefon { get; set; }

    public string? Adresa { get; set; }

    public string? Email { get; set; }

    public int? RodCis { get; set; }

    public DateTime? DatumSmazani { get; set; }
}

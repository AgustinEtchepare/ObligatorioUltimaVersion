using System;
using System.Collections.Generic;

namespace ObligatorioVer1.Models;

public partial class Clima
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public int Temperatura { get; set; }

    public string DescripcionClima { get; set; } = null!;
}

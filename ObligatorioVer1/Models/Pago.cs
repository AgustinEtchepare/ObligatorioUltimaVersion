using System;
using System.Collections.Generic;

namespace ObligatorioVer1.Models;

public partial class Pago
{
    public int Id { get; set; }

    public int ReservaId { get; set; }

    public int Monto { get; set; }

    public DateOnly FechaPago { get; set; }

    public string MetodoPago { get; set; } = null!;

    public virtual Reserva Reserva { get; set; } = null!;
}

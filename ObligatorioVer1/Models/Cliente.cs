using System;
using System.Collections.Generic;

namespace ObligatorioVer1.Models;


public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string TipoCliente { get; set; } = null!;

    public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}

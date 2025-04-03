using System;
using System.Collections.Generic;

public class Comanda
{
    public int ComandaId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime DataComanda { get; set; }
    public decimal PretTotal { get; set; }
    public string Status { get; set; }

    public ICollection<ComandaItem> ComandaItems { get; set; }
}

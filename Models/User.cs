using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class User
{
    public int UserId { get; set; }
    public string Nume { get; set; }
    public string Email { get; set; }
    public string Parola { get; set; }
    public string Adresa { get; set; }
    public string Telefon { get; set; }

    public ICollection<Comanda> Comenzi { get; set; }
    public ICollection<Contact> Contacte { get; set; }
    public Cos Cos { get; set; }
    public string? PozaProfil { get; set; } // numele fișierului, ex: "vlad.jpg"
    public string Rol { get; set; } = "User";
}

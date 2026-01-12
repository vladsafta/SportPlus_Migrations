using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required]
    public string Nume { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Parola { get; set; }

    public string Adresa { get; set; }

    public string Telefon { get; set; }

    // (opțional) pentru poza de profil
    public IFormFile? PozaProfil { get; set; }
}
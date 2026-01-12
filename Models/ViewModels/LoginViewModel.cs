using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required(ErrorMessage = "Emailul este obligatoriu")]
    [EmailAddress(ErrorMessage = "Format email invalid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Parola este obligatorie")]
    public string Parola { get; set; }
}
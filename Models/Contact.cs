using System;

public class Contact
{
    public int ContactId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Mesaj { get; set; }
    public DateTime DataMesaj { get; set; }
}

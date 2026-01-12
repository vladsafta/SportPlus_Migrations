public class Cos
{
    public int CosId { get; set; }
    public int? UserId { get; set; }
    public User User { get; set; }

    public ICollection<CosItem> CosItems { get; set; }
}

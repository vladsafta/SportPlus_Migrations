public class Categorie
{
    public int CategorieId { get; set; }
    public string Nume { get; set; }
    public ICollection<Produse>? Produse { get; set; }
}

public class Produse
{
    public int ProduseId { get; set; }
    public string Nume { get; set; }
    public string Descriere { get; set; }
    public decimal Pret { get; set; }
    public int Stoc { get; set; }

    public int? CategoryId { get; set; }
    public Categorie? Categorie { get; set; }

    public ICollection<ComandaItem>? ComandaItems { get; set; }
    public ICollection<CosItem>? CosItems { get; set; }
}

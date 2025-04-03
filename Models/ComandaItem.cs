public class ComandaItem
{
    public int ComandaItemId { get; set; }
    public int ComandaId { get; set; }
    public Comanda Comanda { get; set; }
    public int ProdusId { get; set; }
    public Produse Produs { get; set; }
    public int Cantitate { get; set; }
    public decimal Pret { get; set; }
}

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Produse> Produse { get; set; }
    public DbSet<Categorie> Categorii { get; set; }
    public DbSet<Comanda> Comenzi { get; set; }
    public DbSet<ComandaItem> ComandaItems { get; set; }
    public DbSet<Cos> Cos { get; set; }
    public DbSet<CosItem> CosItems { get; set; }
    public DbSet<Contact> Contacte { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relatie One-to-One User-Cos
        modelBuilder.Entity<User>()
            .HasOne(u => u.Cos)
            .WithOne(c => c.User)
            .HasForeignKey<Cos>(c => c.UserId);

        // Relatie One-to-Many Categorie-Produse
        modelBuilder.Entity<Produse>()
            .HasOne(p => p.Categorie)
            .WithMany(c => c.Produse)
            .HasForeignKey(p => p.CategoryId);
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BladeRunner2077.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<BladeRunner2077.Models.Producto> DataProducto {get; set; }
    public DbSet<BladeRunner2077.Models.Proforma> DataItemCarrito {get; set; }
    public DbSet<BladeRunner2077.Models.Pago> DataPago {get; set; }
    public DbSet<BladeRunner2077.Models.Pedido> DataPedido {get; set; }
    public DbSet<BladeRunner2077.Models.DetallePedido> DataDetallePedido {get; set; }
    public DbSet<BladeRunner2077.Models.Account> Accounts { get; set; }
}

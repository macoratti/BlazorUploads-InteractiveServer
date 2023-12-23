using BlazorUploads.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorUploads.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    { }
    public DbSet<ArquivoUpload> ArquivosUploads { get; set; }
}

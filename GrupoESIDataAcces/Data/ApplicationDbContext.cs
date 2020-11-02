using GrupoESIModels;
using GrupoESIModels.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GrupoESIDataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Service> ServiceModel { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Quotation> Quotation { get; set; }
        public DbSet<TaskModel> Task { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<EmployeeUser> Employee { get; set; }
        public DbSet<PredefinedTask> PredefinedTask { get; set; }
        public DbSet<PredefinedMaterial> PredefinedMaterial { get; set; }

    }
}

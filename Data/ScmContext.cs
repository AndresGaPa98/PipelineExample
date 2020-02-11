using IdentityServer4.EntityFramework.Options;
using Scm.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CargaDescarga;

namespace Scm.Data
{
    public class ScmContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public DbSet<Empleado> Empleados {get;set;}
        public DbSet<RegistroVale> RegistroVales {get;set;}
        public DbSet<Vale> Vale {get;set;}
        public DbSet<Retenciones> Retenciones { get; set;}
        public DbSet<Empresa> Empresa { get; set;}
        public DbSet<Factura> Factura { get; set;}
        public DbSet<RegistroFactura> RegistroFactura { get; set;}
        public ScmContext(DbContextOptions<ScmContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //put mappings database here
            builder.Entity<Empleado>(x=>{
                x.HasKey(x=>x.IdEmpleado);
                x.Property(x=>x.IdEmpleado).ValueGeneratedOnAdd();
                x.Property(x=>x.Nombre).HasMaxLength(200).IsRequired();
            });
            builder.Entity<RegistroVale>(x=>{
                x.HasKey(x=>x.IdRegistroVale);
                x.Property(x=>x.IdRegistroVale).ValueGeneratedOnAdd();
                x.Property(x=> x.MontoTotal).IsRequired();
                x.HasOne(x=>x.Empleado).WithMany().HasForeignKey(x=>x.IdEmpleado);
                x.HasOne(x=>x.Usuario).WithMany().HasForeignKey(x=>x.UsuarioId);
                x.HasMany(x=>x.Vales);
                
            });
            builder.Entity<Vale>(x=>{
                x.HasKey(x=>x.FolioVale);
                x.Property(x=>x.FolioVale).ValueGeneratedOnAdd();
                x.Property(x=>x.FechaExpedicionVale).IsRequired();
                x.HasOne(x=>x.Empresa).WithMany().HasForeignKey(x=>x.IdEmpresa);
                
            });
            builder.Entity<Retenciones>(x=>{
                x.HasKey(x=>x.Key);
                
            });
            builder.Entity<Empresa>(x=>{
                x.HasKey(x=>x.IdEmpresa);
                x.Property(x=>x.IdEmpresa).ValueGeneratedOnAdd();
                //x.Property(x=>x.IdEmpresa).ValueGeneratedOnAddOrUpdate();
                x.Property(x=>x.NombreEmpresa).HasMaxLength(100).IsRequired();                
                x.Property(x=>x.NombreEmpresa).IsRequired();
            });
            builder.Entity<Factura>(x=>{
                x.HasKey(x=>x.FolioFactura);
                x.Property(x=>x.IdEmpresa).ValueGeneratedOnAdd();
                x.Property(x=>x.Monto).IsRequired();
                x.Property(x=>x.Concepto).IsRequired();
                
                x.Property(x=>x.FechaExpedicion).IsRequired();
                x.Property(x=>x.StatusFactura).IsRequired();
                x.HasOne(x=>x.Empresa).WithMany().HasForeignKey(x=>x.IdEmpresa);
                x.HasMany(x=>x.Vales);
                
            
                
            });
            builder.Entity<RegistroFactura>(x=>{
                x.HasKey(x=>x.IdRegistroFactura);
                x.Property(x=>x.IdRegistroFactura).ValueGeneratedOnAdd();
                x.Property(x=>x.Fecha).IsRequired();
                x.Property(x=>x.TotalFactura).IsRequired();
                x.HasOne(x=>x.Empleado).WithMany().HasForeignKey(x=>x.IdEmpleado);
                x.HasOne(x=>x.Usuario).WithMany().HasForeignKey(x=>x.UsuarioId);
            });
            builder.Entity<Caja>(x=>{
                x.HasKey(x=>x.Idcaja);
                x.Property(x=>x.CantidadInicial).IsRequired();
                x.HasOne(x=>x.Usuario).WithMany().HasForeignKey(x=>x.UsuarioId);
                x.Property(x=>x.CantidadFinal).IsRequired();
                x.Property(x=>x.FechaApertuta).IsRequired();
                x.Property(x=>x.FechaCiere).IsRequired();
            
            });
            base.OnModelCreating(builder);
        }
    }
}
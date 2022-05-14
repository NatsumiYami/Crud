using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.Infrastructure;

namespace Conexion
{
    public class Registro : DbContext
    {
        public Registro()
            : base("name=Registro")
        {
        }


        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }

        public override int SaveChanges()
        {
            foreach (var Empleados in ChangeTracker.Entries()
                      .Where(p => p.State == EntityState.Deleted
                      && p.Entity is Registro))
            {
                Empleados.State = EntityState.Unchanged;
                Empleados.CurrentValues["banActivo"] = true;
            }
            return base.SaveChanges();
        }


    }

}

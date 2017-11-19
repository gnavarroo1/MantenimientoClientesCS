namespace MantenimientoClientesBOL.Models
{
    using System;
    using System.Data.Entity;
    using MySql.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Common;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class DataModel : DbContext
    {


        public DataModel()
            : base("name=DataModel")
        {
        }
        public DataModel(DbConnection existingConnection, bool contextOwnsConnection)
      : base(existingConnection, contextOwnsConnection)
        {

        }
        public virtual DbSet<Cliente> cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Dni)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Edad)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nivelestudios)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefono)
                .IsUnicode(false);
        }
    }
}

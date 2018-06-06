namespace Model
{
    using System.Data.Entity;

    public partial class FidelEntities : DbContext
    {
        public FidelEntities()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer<FidelEntities>(null);
        }

        public virtual DbSet<GRUPO_FAMILIAR> GRUPO_FAMILIAR { get; set; }
        public virtual DbSet<PARENTESCO> PARENTESCO { get; set; }
        public virtual DbSet<PERSONA> PERSONA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GRUPO_FAMILIAR>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<GRUPO_FAMILIAR>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<PARENTESCO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PARENTESCO>()
                .HasMany(e => e.GRUPO_FAMILIAR)
                .WithRequired(e => e.PARENTESCO)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.GRUPO_FAMILIAR)
                .WithRequired(e => e.PERSONA)
                .WillCascadeOnDelete(true);
        }
        
    }
}

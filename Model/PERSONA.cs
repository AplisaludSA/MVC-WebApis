namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cliente.PERSONA")]
    public partial class PERSONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSONA()
        {
            GRUPO_FAMILIAR = new HashSet<GRUPO_FAMILIAR>();
        }

        [Key]
        public long ID_PERSONA { get; set; }

        public long DOCUMENTO { get; set; }

        [Required]
        public string NOMBRE { get; set; }

        public string APELLIDO { get; set; }

        public DateTime? FECHA_NACIMIENTO { get; set; }

        [StringLength(100)]
        public string TELEFONO { get; set; }

        public Nullable<bool> Activo { get; set; } = true;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GRUPO_FAMILIAR> GRUPO_FAMILIAR { get; set; }
    }
}

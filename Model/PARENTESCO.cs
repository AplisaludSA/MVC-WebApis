namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cliente.PARENTESCO")]
    public partial class PARENTESCO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PARENTESCO()
        {
            GRUPO_FAMILIAR = new HashSet<GRUPO_FAMILIAR>();
        }

        [Key]
        public long ID_PARENTESCO { get; set; }

        [Required]
        public string NOMBRE { get; set; }

        public Nullable<bool> Activo { get; set; } = true;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GRUPO_FAMILIAR> GRUPO_FAMILIAR { get; set; }
    }
}

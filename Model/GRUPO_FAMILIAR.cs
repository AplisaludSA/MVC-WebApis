namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("cliente.GRUPO_FAMILIAR")]
    public  class GRUPO_FAMILIAR
    {
        [Key]
        public long ID_GRUPO_FAMILIAR { get; set; }

        public long ID_PARENTESCO { get; set; }

        public long ID_PERSONA { get; set; }

        public long DOCUMENTO { get; set; }

        [Required]
        public string NOMBRE { get; set; }

        public string APELLIDO { get; set; }

        public Nullable<bool> Activo { get; set; } = true;

        public virtual PARENTESCO PARENTESCO { get; set; }

        public virtual PERSONA PERSONA { get; set; }
    }
}

namespace Cloud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FileBase")]
    public partial class FileBase
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public byte[] binaryData { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual Userr Userr { get; set; }
    }
}

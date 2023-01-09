using System;
using System.ComponentModel.DataAnnotations;

namespace DominioBase
{
    public class EntidadBase
    {
        [Key]
        public long Id { get; set; }

        [Timestamp]
        public Byte[] RowVersion { get; set; }   // evita problemas de concurrencia
    }
}

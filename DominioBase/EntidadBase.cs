using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

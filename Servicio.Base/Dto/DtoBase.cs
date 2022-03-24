using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Base
{
    public class DtoBase
    {
        public long Id { get; set; }

        public Byte[] RowVersion { get; set; }
    }
}

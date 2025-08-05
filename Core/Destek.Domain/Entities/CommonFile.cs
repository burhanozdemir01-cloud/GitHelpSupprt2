using Destek.Domain.Entities.Common;
using Destek.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Domain.Entities
{
    public class CommonFile:BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public StorageType StorageType { get; set; }
     

        //[NotMapped]
        //public override DateTime? UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DTO.Base
{
    public abstract class EntityDto
    {       
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string ActionUser { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedDate { get; set; }
        public long? ModifiedDate { get; set; }
        public DateTime RecordDate { get; set; }
        public long? UserId { get; set; }
    }
}

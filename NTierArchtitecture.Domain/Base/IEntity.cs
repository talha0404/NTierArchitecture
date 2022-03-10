using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchtitecture.Domain.Base
{
    public interface IEntity
    {
        long Id { get; set; }

        Guid Guid { get; set; }

        string ActionUser { get; set; }

        long? UserId { get; set; }

        bool IsDeleted { get; set; }

        long CreatedDate { get; set; }

        long? ModifiedDate { get; set; }
    }
}

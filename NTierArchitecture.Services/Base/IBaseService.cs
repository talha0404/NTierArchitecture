using NTierArchtitecture.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Services.Base
{
    public interface IBaseService<T> where T : Entity
    {
    }
}

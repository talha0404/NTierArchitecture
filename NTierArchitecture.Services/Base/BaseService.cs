using NTierArchtitecture.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : Entity //Bize generic type'ı Entity olan bir class gelecek
    {        
    }
}

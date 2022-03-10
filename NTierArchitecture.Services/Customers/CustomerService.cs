using Microsoft.EntityFrameworkCore;
using NTierArchitecture.EFCore;
using NTierArchitecture.Services.Base;
using NTierArchtitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Services.Customers
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly NTierArchitectureDbContext _nTierArchitectureDbContext; //used Readonly  we can only assign value on constructors.

        public CustomerService(NTierArchitectureDbContext nTierArchitectureDbContext) : base(nTierArchitectureDbContext)
        {
            _nTierArchitectureDbContext = nTierArchitectureDbContext;
        }
    }
}

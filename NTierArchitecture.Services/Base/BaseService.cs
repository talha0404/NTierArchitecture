using Microsoft.EntityFrameworkCore;
using NTierArchitecture.EFCore;
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
        //Burada Base olarak tanımladığımız servisler bütün tablolarda ortak olarak kullanılabilecek Sql sorgularımızı yazabiliriz.
        //Temel 4 Crud işlemi bulunmaktadır.

        //We need to add Context Class to access our db from services. Due to that we are giving reference our EfCore solution to use dbcontext

        private readonly NTierArchitectureDbContext _nTierArchitectureDbContext; //used Readonly  we can only assign value on constructors.
        private readonly DbSet<T> _dbSet;

        public BaseService(NTierArchitectureDbContext nTierArchitectureDbContext, DbSet<T> dbSet)
        {
            _nTierArchitectureDbContext = nTierArchitectureDbContext;
            _dbSet = _nTierArchitectureDbContext.Set<T>();
        }
    }
}

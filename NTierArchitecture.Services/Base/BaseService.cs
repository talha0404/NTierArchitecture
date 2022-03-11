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
        //We need to add Context Class to access our db from services. Due to that we are giving reference our EfCore solution to use dbcontext
        //DBContext bize Database bağlantısının yönetimini, Modellerimiz ve database ilişkilerimizin yönetimi, Sorguların yönetimini, Değişikliklerin izlenebilmesini sağlar.
        //Projemizde bütün classlarda uyguladığımız Crud işlemlerini burada Common bir alanda Yazıyoruz.

        private readonly NTierArchitectureDbContext _nTierArchitectureDbContext; //used Readonly  we can only assign value on constructors.
        private readonly DbSet<T> _dbSet;  //This is abstract Class. It can't be new 

        public BaseService(NTierArchitectureDbContext nTierArchitectureDbContext)
        {
            _nTierArchitectureDbContext = nTierArchitectureDbContext;
            _dbSet = _nTierArchitectureDbContext.Set<T>(); // Burada Tipine göre veritabanımızdan tablomuzu Değişkende tutuyoruz.
        }

        public IQueryable<T> GetAllRecords()
        {
            //IQueryable veri tabanından verileri geniş kapsamlı sorgulamak için kullanılır. Bundan dolayı veri tabanı işlemlerinde queryable şeklinde geri döndürüyoruz.
            //DbSet Bizim tablomuzdur. Burada dinamik olarak tablo işlemlerimizi gerçekleştirebiliriz.

            IQueryable<T> query = _dbSet.AsNoTracking().Where(x => !x.IsDeleted);

            return query;
        }

        public IQueryable<T> GetAllRecords(Func<T, bool> predicate)
        {
            //IQueryable veri tabanından verileri geniş kapsamlı sorgulamak için kullanılır. Bundan dolayı veri tabanı işlemlerinde queryable şeklinde geri döndürüyoruz.
            //DbSet Bizim tablomuzdur. Burada dinamik olarak tablo işlemlerimizi gerçekleştirebiliriz.

            IQueryable<T> query = _dbSet.AsNoTracking()
                .Where(predicate)
                .Where(x => !x.IsDeleted)
                .AsQueryable();

            return query;
        }

        public T GetModel(Guid Id)
        {
            var entity = _dbSet.AsNoTracking().Where(x => string.Equals(x.Guid.ToString(), Id.ToString(), StringComparison.OrdinalIgnoreCase) && !x.IsDeleted).FirstOrDefault();
            return entity;
        }

        public T GetModel(Func<T, bool> predicate)
        {
            var entity = _dbSet.AsNoTracking()
                .Where(predicate)
                .Where(x => !x.IsDeleted)
                .FirstOrDefault();
            return entity;
        }

        //Just Only Saving entity
        public T Save(T entity)
        {
            try
            {
                if (entity.Id == 0)
                    _dbSet.Add(entity);
                else
                    _dbSet.Update(entity);

                _nTierArchitectureDbContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }

        //Database'e tek tek eklemek yerine liste olarak bütün listeyi eklemek istersek bu fonksiyonu kullanabiliriz.
        //Burada bulunan dataları tek tek güncellenecekmi yoksa eklenecekmi diye ayrımamız gerekmektedir. Bundan dolayı değişiklikleri farklı değişkenlerde tutuyoruz.
        public void SaveRange(List<T> listModel)
        {
            List<T> UpdateList = new List<T>();
            List<T> AddList = new List<T>();

            foreach (var entity in listModel)
            {
                if (entity.Id == 0)
                    AddList.Add(entity);
                else
                    UpdateList.Add(entity);
            }

            if (AddList.Count > 0)
                _dbSet.AddRange(AddList);

            if (UpdateList.Count > 0)
                _dbSet.UpdateRange(UpdateList);

            _nTierArchitectureDbContext.SaveChanges();
        }

        public bool Delete(Guid Id)
        {
            var entity = _dbSet.Where(x => string.Equals(x.Guid.ToString(), Id.ToString(), StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (object.Equals(entity, null)) return false;

            _dbSet.Remove(entity);
            return true;
        }

        public bool Passive(Guid Id)
        {
            var entity = _dbSet.Where(x => string.Equals(x.Guid.ToString(), Id.ToString(), StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (object.Equals(entity, null)) return false;

            entity.IsDeleted = true;

            _nTierArchitectureDbContext.SaveChanges();
            return true;
        }
    }
}

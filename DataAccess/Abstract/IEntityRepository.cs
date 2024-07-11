using Entity.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class , IEntity , new()
    {
        
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById();
        List<T> GetAll();
    }
}

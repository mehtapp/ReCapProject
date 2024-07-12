using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColourDal : IColourDal
    {
        public void Add(Colour entity)
        {
            using (RentACarContext rentACar = new RentACarContext())
            {


                var addedEntity = rentACar.Entry(entity);
                addedEntity.State = EntityState.Added;
                rentACar.SaveChanges();
            }
        }

        public void Delete(Colour entity)
        {
            using (RentACarContext rentACar = new RentACarContext())
            {
                var deletedEntity = rentACar.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                rentACar.SaveChanges();
            }
        }
        public void Update(Colour entity)
        {
            using (RentACarContext rentACar = new RentACarContext())
            {
                var updatedEntity = rentACar.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                rentACar.SaveChanges();
            }
        }
        public List<Colour> GetAll(Expression<Func<Colour, bool>> filter = null)
        {
            using (RentACarContext rentACar = new RentACarContext())
            {
                List<Colour> colors = filter == null ? rentACar.Colours.ToList() : rentACar.Colours.Where(filter).ToList();
                return colors;
            }
        }

        public Colour GetById(Expression<Func<Colour, bool>> filter)
        {
            using (RentACarContext rentACar = new RentACarContext())
            {
                return rentACar.Colours.Where(filter).First();
            }
        }

    }
}

using DataAccess.Abstract;
using Entity.Concrete;
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
                rentACar.Entry(entity);
                rentACar.SaveChanges();
            }
        }

        public void Delete(Colour entity)
        {
            throw new NotImplementedException();
        }
        public void Update(Colour entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

    }
}

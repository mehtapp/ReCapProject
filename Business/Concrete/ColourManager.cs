using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColourManager : IColourService
    {
        private readonly IColourDal _colourDal;
        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }
        public void AddColour(Colour colour)
        {
            _colourDal.Add(colour);
        }

        public List<Colour> GetColors()
        {
            return _colourDal.GetAll();
        }

        public Colour GetColourById(int id)
        {
            return _colourDal.GetById(c => c.Id == id);
        }

        public void RemoveColour(Colour colour)
        {
            _colourDal.Delete(colour);
        }

        public void UpdateColour(Colour colour)
        {
            _colourDal.Update(colour);
        }
    }
}

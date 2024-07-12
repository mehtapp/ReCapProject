using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColourService
    {
        void AddColour(Colour colour);
        void RemoveColour(Colour colour);
        void UpdateColour(Colour colour);
        List<Colour> GetColors();

        Colour GetColourById(int id);
    }
}

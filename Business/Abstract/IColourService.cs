using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColourService
    {
        IResult AddColour(Colour colour);
        IResult DeleteColour(Colour colour);
        IResult UpdateColour(Colour colour);
        IDataResult<List<Colour>> GetColors();

        IDataResult<Colour> GetColourById(int id);
    }
}

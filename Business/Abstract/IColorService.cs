using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        Result Add(Color color);
        Result Delete(Color color);
        Result Update(Color color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);

    }
}

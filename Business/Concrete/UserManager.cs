using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public Result Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("User eklendi.");
        }

        public Result Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("User silindi.");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Tum user'lar getirildi.");
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), "Istenilen User getirildi.");
        }

        public Result Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("User guncellendi.");
        }
    }
}

using Business.Abstarct;
using Business.Constants;
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

        public IResult Add(User user)
        {
            if (!(user.FirstName.Length > 1) || !(user.LastName.Length<2))
            {
                return new ErrorResult(Messages.InvalidRequest);
            }

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var getAll = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(getAll);
        }

        public IDataResult<User> GetById(int userId)
        {
            var selectedUser = _userDal.Get(user => user.Id == userId);
            return new SuccessDataResult<User>(selectedUser);
        }

        public IResult Update(User user)
        {
            var updatedUser = _userDal.Get(u => u.Id == user.Id);
            updatedUser.Email = user.Email;
            updatedUser.FirstName = user.FirstName;
            updatedUser.LastName = user.LastName;
            updatedUser.Password = user.Password;
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}

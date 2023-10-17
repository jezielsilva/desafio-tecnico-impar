using Impar.BackEnd.Evaluation.Model;
using Impar.BackEnd.Evaluation.Business.Interface;
using Impar.BackEnd.Evaluation.Repository.Interface;

namespace Impar.BackEnd.Evaluation.Business.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository userRepository;

        public UserBusiness(
            IUserRepository _userRepository) 
        {
            userRepository = _userRepository;
        }

        public List<User> getUsersStatusNotSent()
        {
            List<User> users = new List<User>();
            users = userRepository.getUsersStatusNotSent();
            return users;
        }

        public bool changeStatusUsers()
        {
            return userRepository.changeStatusUsers();
        }
    }
}

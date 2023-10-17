using Impar.BackEnd.Evaluation.Model;

namespace Impar.BackEnd.Evaluation.Repository.Interface
{
    public interface IUserRepository
    {
        List<User> getUsersStatusNotSent();

        bool changeStatusUsers();
    }
}

using Impar.BackEnd.Evaluation.Model;

namespace Impar.BackEnd.Evaluation.Business.Interface
{
    public interface IUserBusiness
    {
        List<User> getUsersStatusNotSent();
        bool changeStatusUsers();
    }
}

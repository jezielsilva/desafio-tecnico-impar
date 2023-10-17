using Impar.BackEnd.Evaluation.Model;

namespace Impar.BackEnd.Evaluation.Business.Interface
{
    public interface IMessagesBusiness
    {
        Task sendMensages(List<User> users);
    }
}

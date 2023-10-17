using Impar.BackEnd.Evaluation.Model;

namespace Impar.BackEnd.Evaluation.Repository.Interface
{
    public interface IMessageRepository
    {
        Task sendMensages(List<User> users);
    }
}

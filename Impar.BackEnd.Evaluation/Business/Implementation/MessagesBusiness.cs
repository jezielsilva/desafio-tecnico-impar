using Impar.BackEnd.Evaluation.Business.Interface;
using Impar.BackEnd.Evaluation.Model;
using Impar.BackEnd.Evaluation.Repository.Interface;

namespace Impar.BackEnd.Evaluation.Business.Implementation
{
    public class MessagesBusiness : IMessagesBusiness
    {
        private readonly IMessageRepository messageRepository;
        public MessagesBusiness(
            IMessageRepository _messageRepository)
        {
            messageRepository = _messageRepository;
        }

        public async Task sendMensages(List<User> users)
        {
           await messageRepository.sendMensages(users);
        }
    }
}

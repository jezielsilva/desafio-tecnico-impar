using Impar.BackEnd.Evaluation.Model;
using Impar.BackEnd.Evaluation.Repository.Context;
using Impar.BackEnd.Evaluation.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Impar.BackEnd.Evaluation.Repository.Implementation
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessagesDbContext _dbContext;
        public MessageRepository(MessagesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task sendMensages(List<User> users)
        {
            try
            {
                Parallel.ForEach(users, (user) =>
                {
                    var message = new Message
                    {
                        MessageContent = $"Esta é uma mensagem enviada para {user.Name} ({user.Email})",
                        SentAt = DateTime.UtcNow,
                        Subject = $"User: {user.Name}",
                        UserId = user.Id,
                    };

                    lock (_dbContext)
                    {
                        _dbContext.Messages.Add(message);
                    }
                });
                
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Algumas mensagens tiveram erro no envio!");
            }
        }
    }
}

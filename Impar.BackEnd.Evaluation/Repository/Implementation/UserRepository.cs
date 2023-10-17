using Impar.BackEnd.Evaluation.Model;
using Impar.BackEnd.Evaluation.Model.Enum;
using Impar.BackEnd.Evaluation.Repository.Context;
using Impar.BackEnd.Evaluation.Repository.Interface;

namespace Impar.BackEnd.Evaluation.Repository.Implementation
{

    public class UserRepository : IUserRepository
    {
        private readonly MessagesDbContext _dbContext;
        public UserRepository(
            MessagesDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public List<User> getUsersStatusNotSent()
        {
            var users = _dbContext.Users.Where(x => x.StatusMessage == (int)EStatusMensagem.NaoEnviado || x.StatusMessage == (int)EStatusMensagem.AguardandoEnvio).AsParallel().ToList();
            return users;
        }

        public bool changeStatusUsers()
        {
            try
            {
                List<int> usersId = _dbContext.Messages.Select(x => x.UserId).ToList();

                Parallel.ForEach(usersId, (userId) =>
                {
                    User user = getUser(userId);

                    if (user != null)
                    {
                        user.StatusMessage = (int)EStatusMensagem.Enviado;
                        _dbContext.Users.Update(user);
                    }
                });

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar alterar status dos usuários: {ex.Message}");
                return false;
            }
        }


        private User getUser(int id)
        {
            return _dbContext.Users.Find(id);
        }
    }
}

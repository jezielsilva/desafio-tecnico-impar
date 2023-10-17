using Microsoft.AspNetCore.Mvc;
using Impar.BackEnd.Evaluation.Model;
using Impar.BackEnd.Evaluation.Business.Interface;
using Impar.BackEnd.Evaluation.Repository.Context;

namespace Impar.BackEnd.Evaluation.Controllers
{
    [Route("Messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessagesDbContext _dbContext;
        private readonly IUserBusiness _userBusiness;
        private readonly IMessagesBusiness _messageBusiness;

        public MessagesController(MessagesDbContext ctx, IMessagesBusiness messagesBusiness, IUserBusiness userBusiness)
        {
            _dbContext = ctx;
            _messageBusiness = messagesBusiness;
            _userBusiness = userBusiness;
        }

        [HttpGet]
        [Route("status")]
        public IActionResult Status()
        {
            return Ok("Mostre o status do envio aqui");
        }


        [HttpPost]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage()
        {
            List<User> users = new List<User>();
            users = _userBusiness.getUsersStatusNotSent();
            var messages = _messageBusiness.sendMensages(users);
            Thread.Sleep(500);

            return Ok();
        }

        [HttpPost]
        [Route("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus()
        {
            _userBusiness.changeStatusUsers();
            return Ok();
        }
    }
}

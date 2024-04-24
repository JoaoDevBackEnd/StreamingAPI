using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Streaming.Data.Context;
using Streaming.Data.Entity;
using Streaming.Model;

namespace Streaming.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountControllers : ControllerBase
    {
        private DataContext _db;

        public AccountControllers(IConfiguration configuration)
        {
            _db = new DataContext(configuration);
        }
        #region Put
        /// <summary>
        /// CRIAR  uma conta
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Conta criada com sucesso</response>
        /// <response code="400">Já existe conta com esses dados</response>
        /// <response code="422">Dados inválidos</response>
        [HttpPost]
        public IActionResult Post (CreateAccountRequest model){
           //VALIDANDO OS DADOS 
           // VALIDANDO O EMAIL
            var user = _db.Users.FirstOrDefault(x => x.email == model.email);
            if (user != null)
            {
                return BadRequest("Já existe uma conta com este e-mail cadastrado.");
            }
            //VALIDANDO A DATA DE NASCIMENTO
            var minDate = DateTime.Today.AddYears(-18);
            if(model.dateBirth > minDate)
            {
                return BadRequest("É preciso ter mais de 18 anos para criar uma conta");
            }
            //VALIDANDO O NOME DE USUÁRIO
            var username=_db.Users.FirstOrDefault(x => x.username== model.username);
            if(username != null)
            {
                return BadRequest("O nome de perfil já está em uso solicite Outro");
            }
            //VALIDANDO O CPF
            var userCpf = _db.Users.FirstOrDefault(x => x.cpf == model.cpf);
            if (userCpf != null)
            {
                return BadRequest("O CPF informado já existe !!!");
            }

            var account = new users();
            account.name=model.name;
            account.username = model.username;
            account.password=model.password;
            account.email = model.email;
            account.datebirth = model.dateBirth;
            account.cpf = model.cpf;

            _db.Add(account);
            _db.SaveChanges();
            return Ok();
        }
        #endregion

    }
}

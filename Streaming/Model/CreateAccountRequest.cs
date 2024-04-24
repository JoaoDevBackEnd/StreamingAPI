using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Streaming.Model
{
    public class CreateAccountRequest
    {
        [Required]
        public string name { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="O NOME DE USÁRIO NÃO PODE PASSAR DE 10 CARACTER")]
        public string username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="EMAIL INVÁLIDO")]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string cpf { get; set; }
        [Required]
        [DisplayFormat(DataFormatString="yyyy/mm/dd")]
        public DateTime dateBirth { get; set; }
    }
}

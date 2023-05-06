using System.ComponentModel.DataAnnotations;

namespace College.Models
{
    public class CursosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o título do curso")]
        public string Titulo { get; set; }


        [Required(ErrorMessage = "Digite o nome do site que o curso está hóspedado")]
        public string Site { get; set; }


        [Required(ErrorMessage = "Digite a duração do curso")]
        
        public string Duracao { get; set; }


        [Required(ErrorMessage = "Coloque o link do curso")]
        [Url(ErrorMessage = "Link não valido")]
        public string Link { get; set;}


        public string Descricao { get; set;}
    }
}

/*
Nome: Kaik Persike Maiorquino
Prontuário: CB3029689

Nome: Luiz Gustavo Verissimo Monteiro
Prontuário: CB3030326
*/
using System.ComponentModel.DataAnnotations;

namespace Livraria.Core
{
    public class Livro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(150, ErrorMessage = "O título deve ter no máximo 150 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O autor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O autor deve ter no máximo 100 caracteres.")]
        public string Autor { get; set; } = string.Empty;

        public string? ISBN { get; set; }

        [AnoPublicacaoValido(
            ErrorMessage = "O ano de publicação deve estar entre 1450 e o ano atual."
        )]
        public int? AnoPublicacao { get; set; }

        [EnumDataType(typeof(StatusLeitura), ErrorMessage = "Status de leitura inválido.")]
        public StatusLeitura Status { get; set; } = StatusLeitura.ParaLer;
    }

}

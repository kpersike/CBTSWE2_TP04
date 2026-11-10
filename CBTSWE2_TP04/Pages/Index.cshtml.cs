/*
Nome: Kaik Persike Maiorquino
Prontuário: CB3029689

Nome: Luiz Gustavo Verissimo Monteiro
Prontuário: CB3030326
*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Livraria.Core;
using System.Net.Http.Json;

namespace CBTSWE2_TP04.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<Livro> Livros { get; set; } = new();

        [BindProperty]
        public Livro NovoLivro { get; set; } = new();

        [BindProperty]
        public Livro LivroEdicao { get; set; } = new();

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("LivrariaAPI");

            Livros = await httpClient.GetFromJsonAsync<List<Livro>>("api/Livros")
                     ?? new List<Livro>();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("LivrariaAPI");

            var resposta = await httpClient.PostAsJsonAsync(
                "api/Livros",
                NovoLivro
            );

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }

            ModelState.AddModelError(
                string.Empty,
                "Não foi possível cadastrar o livro."
            );

            await OnGetAsync();

            return Page();
        }


        public async Task<IActionResult> OnPostExcluirAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("LivrariaAPI");

            var resposta = await httpClient.DeleteAsync($"api/Livros/{id}");

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }

            ModelState.AddModelError(
                string.Empty,
                "Não foi possível excluir o livro."
            );

            await OnGetAsync();

            return Page();
        }


        public async Task<IActionResult> OnPostAtualizarAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("LivrariaAPI");

            var resposta = await httpClient.PutAsJsonAsync(
                $"api/Livros/{id}",
                LivroEdicao
            );

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }

            ModelState.AddModelError(
                string.Empty,
                "Não foi possível atualizar o livro."
            );

            await OnGetAsync();

            return Page();
        }


    }
}
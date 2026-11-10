/*
Nome: Kaik Persike Maiorquino
Prontuário: CB3029689

Nome: Luiz Gustavo Verissimo Monteiro
Prontuário: CB3030326
*/
using Livraria.API.Data;
using Microsoft.AspNetCore.Mvc;
using Livraria.Core;
using Microsoft.EntityFrameworkCore;

namespace Livraria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivrosController : ControllerBase
{
    private readonly LivrariaContext _context;

    public LivrosController(LivrariaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var livros = await _context.Livros.ToListAsync();

        return Ok(livros);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Livro livro)
    {
        _context.Livros.Add(livro);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTodos),
            new { id = livro.Id },
            livro
        );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(int id, Livro livro)
    {
        if (id != livro.Id)
        {
            return BadRequest("O ID da URL não corresponde ao ID do livro.");
        }

        var livroExistente = await _context.Livros.FindAsync(id);

        if (livroExistente == null)
        {
            return NotFound();
        }

        livroExistente.Titulo = livro.Titulo;
        livroExistente.Autor = livro.Autor;
        livroExistente.ISBN = livro.ISBN;
        livroExistente.AnoPublicacao = livro.AnoPublicacao;
        livroExistente.Status = livro.Status;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Excluir(int id)
    {
        var livro = await _context.Livros.FindAsync(id);

        if (livro == null)
        {
            return NotFound();
        }

        _context.Livros.Remove(livro);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
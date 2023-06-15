using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using BusinessLogic.Context;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ILogger<EventosController> _logger;

        public EventosController(ILogger<EventosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllEventos()
        {
            try
            {
                // Aqui você pode implementar a lógica para recuperar todos os eventos existentes
                // Exemplo: List<Evento> eventos = suaLógicaDeRecuperacao();

                // Supondo que
                // você tenha uma lista de eventos, você pode retorná-la como resposta
                var db = new EventosDBContext();
                var eventos = db.Eventos.Select(e=>new
                {
                    e.Categoria,
                    e.Descricao,
                    Organizador = new {
                        Nome = e.IdOrganizadorNavigation!.Nome ?? "sem organizador",
                        
                        Email = e.IdOrganizadorNavigation!.Email ?? "sem organizador"

                    }
                }).ToList();
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao recuperar os eventos.");
                return StatusCode(500, "Ocorreu um erro ao recuperar os eventos. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEventoById(int id)
        {
            try
            {
                // Aqui você pode implementar a lógica para recuperar um evento pelo ID
                // Exemplo: Evento evento = suaLógicaDeRecuperacaoPorId(id);

                // Supondo que você tenha encontrado o evento, você pode retorná-lo como resposta
                var evento = new Evento();
                if (evento != null)
                {
                    return Ok(evento);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao recuperar o evento.");
                return StatusCode(500, "Ocorreu um erro ao recuperar o evento. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CreateEvento([FromBody] EventoViewModel eventoViewModel)
        {
            try
            {
                // Aqui você pode implementar a lógica para criar um evento com base nos dados recebidos do ViewModel

                // Exemplo de criação de um novo evento
                var novoEvento = new Evento
                {
                    Nome = eventoViewModel.Nome,
                    Data = eventoViewModel.Data,
                    Hora = eventoViewModel.Hora,
                    Local = eventoViewModel.Local,
                    Descricao = eventoViewModel.Descricao,
                    Capacidademax = eventoViewModel.Capacidademax,
                    Categoria = eventoViewModel.Categoria,
                    IdOrganizador = eventoViewModel.Organizador
                };

                // Aqui você pode chamar a lógica de persistência ou qualquer outra ação necessária

                return Ok("Evento criado com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao criar o evento.");
                return StatusCode(500, "Ocorreu um erro ao criar o evento. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvento(int id, [FromBody] EventoViewModel eventoViewModel)
        {
            try
            {
                // Aqui você pode implementar a lógica para atualizar um evento com base no ID e nos dados recebidos do ViewModel

                // Exemplo de atualização de um evento existente
                var eventoExistente = new Evento(); // Suponha que você recuperou o evento existente pelo ID
                if (eventoExistente != null)
                {
                    eventoExistente.Nome = eventoViewModel.Nome;
                    eventoExistente.Data = eventoViewModel.Data;
                    eventoExistente.Hora = eventoViewModel.Hora;
                    eventoExistente.Local = eventoViewModel.Local;
                    eventoExistente.Descricao = eventoViewModel.Descricao;
                    eventoExistente.Capacidademax = eventoViewModel.Capacidademax;
                    eventoExistente.Categoria = eventoViewModel.Categoria;
                    eventoExistente.IdOrganizador = eventoViewModel.Organizador;

                    // Aqui você pode chamar a lógica de persistência ou qualquer outra ação necessária

                    return Ok("Evento atualizado com sucesso!");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar o evento.");
                return StatusCode(500, "Ocorreu um erro ao atualizar o evento. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvento(int id)
        {
            try
            {
                // Aqui você pode implementar a lógica para excluir um evento pelo ID

                // Exemplo de exclusão de um evento existente
                var eventoExistente = new Evento(); // Suponha que você recuperou o evento existente pelo ID
                if (eventoExistente != null)
                {
                    // Aqui você pode chamar a lógica de exclusão ou qualquer outra ação necessária

                    return Ok("Evento excluído com sucesso!");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao excluir o evento.");
                return StatusCode(500, "Ocorreu um erro ao excluir o evento. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
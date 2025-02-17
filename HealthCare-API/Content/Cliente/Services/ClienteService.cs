﻿using System.Collections;
using AutoMapper;
using HealthCare_API.Content.Cliente.DTO;
using HealthCare_API.Content.Cliente.Entity;
using HealthCare_API.Content.Cliente.Interfaces;
using HealthCare_API.Content.ProblemaSaude.DTO;
using HealthCare_API.Content.ProblemaSaude.Interfaces;
using HealthCare_API.Content.ProblemaSaude.ValueObject;

namespace HealthCare_API.Content.Cliente.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;
    private readonly IProblemaSaudeRepository _problemaSaudeRepository;
    private readonly IMapper _mapper;

    public ClienteService(IClienteRepository repository,IMapper mapper, IProblemaSaudeRepository problemaSaudeRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _problemaSaudeRepository = problemaSaudeRepository;
    }

    public void AddCliente(ClienteCreateDTO clientedto)
    {
        var cliente = _mapper.Map<Entity.Cliente>(clientedto);
        cliente.ProblemasDeSaude = clientedto.ProblemasDeSaudeIds
        .Select(id => _problemaSaudeRepository.GetProblemaByID(id))
        .Where(problema => problema != null)
        .ToList();

        _repository.AddCliente(cliente);
    }

    public void DeleteCliente(int id)
    {
        _repository.DeleteCliente(id);
    }

    public IEnumerable<ClienteDTO> GetAllClienteByGrauProblema(GrauEnum grau)
    {
        IEnumerable<Entity.Cliente> clientes = _repository.GetAllClienteByProblema(grau);
        IEnumerable<ClienteDTO> clientesDTO = clientes.Select(cliente => new ClienteDTO
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Nascimento = cliente.Nascimento,
            DataCriacao = cliente.DataCriacao,
            DataAtualizacao = cliente.DataAtualizacao,
            Peso = cliente.Peso,
            SexoCliente = cliente.SexoCliente,
            Altura = cliente.Altura,
            ProblemasDeSaude = cliente.ProblemasDeSaude?.Select(problema => new ProblemaSaudeDTO
            {
                Id = problema.Id,
                Nome = problema.Nome,
                Grau = problema.Grau
            }).ToList()
        }).ToList();

        return clientesDTO;
    }

    public IEnumerable<ClienteDTO> GetAllClientes()
    {
        IEnumerable<Entity.Cliente> clientes = _repository.GetAllClientes();
        IEnumerable<ClienteDTO> clientesDTO = clientes.Select(cliente => new ClienteDTO
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Nascimento = cliente.Nascimento,
            DataCriacao = cliente.DataCriacao,
            DataAtualizacao = cliente.DataAtualizacao,
            Peso = cliente.Peso,
            SexoCliente = cliente.SexoCliente,
            Altura = cliente.Altura,          
            ProblemasDeSaude = cliente.ProblemasDeSaude?.Select(problema => new ProblemaSaudeDTO
            {
                Id = problema.Id,
                Nome = problema.Nome,
                Grau = problema.Grau 
            }).ToList() 
        }).ToList(); 
        return clientesDTO;
    }

    public ClienteDTO GetClienteById(int id)
    {
        var cliente = _repository.GetClienteById(id);
        var clientedto = _mapper.Map<ClienteDTO>(cliente);
        return clientedto;
    }

    public decimal GetClienteProblemaScore(int id )
    {
        var idade = _repository.CalcularIdade(id);
        var cliente = GetClienteById(id);
        decimal somaDosGraus = cliente.ProblemasDeSaude.Sum(p => (int)p.Grau);
        decimal imc = cliente.Peso / (cliente.Altura * cliente.Altura);
        decimal SD = somaDosGraus;
        decimal e = -(-2.8m + SD); 
        decimal exponencial = (decimal)Math.Exp((double)e);
        decimal score = (1 / (1 + exponencial)) * 100;
        decimal scoreTotal = (imc >= 30 || idade > 60) ? score * 1.5m : score;

        return scoreTotal;
    }

    public List<ClienteScore> GetTop10ClientesMaisRisco()
    {
        var clientes = _repository.GetAllClientes();
        var ClientecomScore = new List<ClienteScore>();
        foreach (var cliente in clientes )
        {
            var idade = CalcularIdade(cliente.Nascimento);
            decimal somaDosGraus = cliente.ProblemasDeSaude.Sum(p => (int)p.Grau);
            decimal imc = cliente.Peso / (cliente.Altura * cliente.Altura);
            decimal sd = somaDosGraus;
            decimal e = -(-2.8m + sd);
            decimal exponencial = (decimal)Math.Exp((double)e);
            decimal score = (1 / (1 + exponencial)) * 100;
            decimal scoreTotal = (imc >= 30 || idade > 60) ? score * 1.5m : score;

                //switch com os classificadores de risco
            string riscoDeSaude = scoreTotal switch
            {
                >= 70 => "Alto",
                >= 40 and < 70 => "Médio",
                _ => "Baixo"
            };

            ClienteScore clienteScore = new ClienteScore();
            clienteScore.Nome = cliente.Nome;
            clienteScore.Idade = idade;
            clienteScore.Imc = imc;
            clienteScore.Risco = riscoDeSaude;
            clienteScore.Score = scoreTotal;
            
            ClientecomScore.Add(clienteScore);
        }
        return ClientecomScore.OrderByDescending(c => c.Score).Take(10)
            .ToList();

    }

    public void UpdateCliente(int id, ClienteCreateDTO clienteDto)
    {
        var cliente = _repository.GetClienteById(id);

        cliente.Nome = clienteDto.Nome;
        cliente.Altura = clienteDto.Altura;
        cliente.DataAtualizacao = clienteDto.DataAtualizacao;
        cliente.Nascimento = clienteDto.Nascimento;
        cliente.Peso = clienteDto.Peso;
        cliente.SexoCliente = clienteDto.SexoCliente;

        if (clienteDto.ProblemasDeSaudeIds != null && clienteDto.ProblemasDeSaudeIds.Any())
        {
            // Usando a mesma lógica do AddCliente
            cliente.ProblemasDeSaude = clienteDto.ProblemasDeSaudeIds
                .Select(id => _problemaSaudeRepository.GetProblemaByID(id)) // Busca o problema pelo ID
                .Where(problema => problema != null) // Filtra problemas nulos
                .ToList(); // Converte para lista
        }
        else
        {
            // Se não houver problemas de saúde, você pode limpar a lista ou manter os existentes
            cliente.ProblemasDeSaude.Clear();
        }

        // Atualiza o cliente no repositório
        _repository.UpdateCliente(cliente);

    }

    public int CalcularIdade(DateOnly dataNascimento)
    {
        var hoje = DateTime.Today;
        var dataNascimentoDateTime = dataNascimento.ToDateTime(TimeOnly.MinValue);
        var idade = hoje.Year - dataNascimentoDateTime.Year;
        if (dataNascimentoDateTime.Date > hoje.AddYears(-idade)) idade--;

        return idade;
    }

}

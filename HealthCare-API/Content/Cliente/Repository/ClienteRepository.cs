using System.Collections;
using HealthCare_API.Content.Cliente.Interfaces;
using HealthCare_API.Content.ProblemaSaude.ValueObject;
using HealthCare_API.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthCare_API.Content.Cliente.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }
    public Entity.Cliente GetClienteById(int id)
    {
        
            return _context.Clientes
                .Include(c => c.ProblemasDeSaude)
                .FirstOrDefault(c => c.Id == id);
        
    }

    public IEnumerable<Entity.Cliente> GetAllClientes()
    {
        var Listclientes = _context.Clientes.ToList();
         IEnumerable<Entity.Cliente> Clientes = Listclientes;
         return Clientes;
    }

    public IEnumerable<Entity.Cliente> GetAllClienteByProblema(GrauEnum grauprob)
    {
        var ListClientes = _context.Clientes?.Where(c => c.ProblemasDeSaude.Any(p => p.Grau == grauprob));
        IEnumerable<Entity.Cliente> Clientes = ListClientes;
        return Clientes;
    }

    public void AddCliente(Entity.Cliente cliente)
    {
        _context.Add(cliente);
        _context.SaveChanges();
    }

    public void UpdateCliente(Entity.Cliente cliente)
    {
        _context.Update(cliente);
        _context.SaveChanges();
        //bah meu queria logo é armoçar
    }

    public void DeleteCliente(int id)
    {
        var cliente = GetClienteById(id);
        _context.Remove(cliente);
        _context.SaveChanges();

        //talvez tenha uma forma mais direta de fazer isso, mas funfo ent tanto faz rsrs
    }

    public int CalcularIdade(int id)
    {
        var cliente = GetClienteById(id);
        var hoje = DateTime.Today;
        var idade = hoje.Year - cliente.Nascimento.Year;
        if (cliente.Nascimento.ToDateTime(new TimeOnly()) > hoje.AddYears(-idade))
        {
            idade--;
        }
        return idade;
    }
}

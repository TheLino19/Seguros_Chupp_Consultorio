


using DOMAIN.Entities;
using INFRASTRUCTURE.Persistence.Context;
using INFRASTRUCTURE.Persistence.Repository;
using INFRASTRUCTURE.Persistence.Repository.AsgAsegurado;
using INFRASTRUCTURE.Persistence.Repository.AsgCliente;
using INFRASTRUCTURE.Persistence.Repository.Seguros;

namespace INFRASTRUCTURE.Persistence.UnitOfWork;

public class UnitofWork : IUnitOfWork
{
    private readonly Schupp2024Context _context;
    public IAseguradoRepository Asegurado { get; }
    public IAsgClienteRepository Clientes { get; private set; }
    public ISegurosRepository Seguros { get; private set; }

    public UnitofWork(Schupp2024Context context)
    {
        _context = context;
        Clientes = new AsgClienteRepository(_context);
        Seguros = new SeguroRepository(_context);
    }
    public void Dispose()
    {
        this._context.Dispose();
    }

    public void SaveChanges()
    {
        this._context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        this._context.SaveChangesAsync();
    }
}
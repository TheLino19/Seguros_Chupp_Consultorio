using INFRASTRUCTURE.Persistence.Repository;
using INFRASTRUCTURE.Persistence.Repository.AsgAsegurado;
using INFRASTRUCTURE.Persistence.Repository.AsgCliente;
using INFRASTRUCTURE.Persistence.Repository.Seguros;

namespace INFRASTRUCTURE.Persistence.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    public IAseguradoRepository Asegurado { get; }
    public IAsgClienteRepository Clientes { get; }
    public ISegurosRepository Seguros { get; }

    void SaveChanges();
    Task SaveChangesAsync() ;
}
using System.Data;
using APPLICATION.Commons.Bases;
using APPLICATION.Dtos.Response;

namespace APPLICATION.Services.Excel;

public interface IExcelService
{
    DataTable LeerArchivoExcel(string ruta, int hoja);
    BaseResponse<List<ClienteRequestExcel>> EscribirArchivoExcel(String ruta);
}
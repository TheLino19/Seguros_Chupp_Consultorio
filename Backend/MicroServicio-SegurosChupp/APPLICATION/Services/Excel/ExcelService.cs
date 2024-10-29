using System.Data;
using APPLICATION.Commons.Bases;
using APPLICATION.Dtos.Response;
using ClosedXML.Excel;

namespace APPLICATION.Services.Excel;

public class ExcelService : IExcelService
{
    public DataTable LeerArchivoExcel(string rutaArchivo, int hojaNumero = 1)
    {
        var dataTable = new DataTable();

        using (var workbook = new XLWorkbook(rutaArchivo))
        {
            var worksheet = workbook.Worksheet(hojaNumero);
            var firstRow = true;
            var firstRowUsed = worksheet.FirstRowUsed();
            var lastRowUsed = worksheet.LastRowUsed();
            var firstColumnUsed = worksheet.FirstColumnUsed();
            var lastColumnUsed = worksheet.LastColumnUsed();

            // Agregar columnas
            foreach (var cell in firstRowUsed.Cells())
            {
                dataTable.Columns.Add(cell.Value.ToString());
            }

            // Agregar filas
            var rows = worksheet.Rows(firstRowUsed.RowNumber() + 1, lastRowUsed.RowNumber());
            foreach (var row in rows)
            {
                var dataRow = dataTable.NewRow();
                int columnIndex = 0;
                foreach (var cell in row.Cells(firstColumnUsed.ColumnNumber(), lastColumnUsed.ColumnNumber()))
                {
                    dataRow[columnIndex] = cell.Value;
                    columnIndex++;
                }
                dataTable.Rows.Add(dataRow);
            }
        }

        return dataTable;
    }

    public BaseResponse<List<ClienteRequestExcel>> EscribirArchivoExcel(string ruta)
    {
        BaseResponse<List<ClienteRequestExcel>> response = new BaseResponse<List<ClienteRequestExcel>>();
        List<Dictionary<String, Object>> resul = new List<Dictionary<string, object>>();

        try
        {
            var datosExcel = LeerArchivoExcel(ruta);

            foreach (DataRow fila in datosExcel.Rows)
            {
                Dictionary<String, Object> cliente = new Dictionary<string, object>();
                foreach (DataColumn columna in datosExcel.Columns)
                {
                    cliente.Add(columna.ColumnName, fila[columna]);
                    //Console.WriteLine($"{columna.ColumnName}: {fila[columna]}");
                }
                resul.Add(cliente);
            }

            if (resul.Count > 0)
            {
                response.IsSuccess = true;
                response.Data = ObtenerListaCliente(resul);
                response.Message = "Datos correctamente cargado";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No hay datos en el archivo";
            }

        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = "Ocurrio un error al procesar los datos";

        }

        return response;
    }
    
    public List<ClienteRequestExcel> ObtenerListaCliente(List<Dictionary<String, Object>> lst)
    {
        List<ClienteRequestExcel> resultado = new List<ClienteRequestExcel>();
        foreach (Dictionary<String, Object> item in lst)
        {
            resultado.Add(new ClienteRequestExcel(item));
        }
        return resultado;
    }
}
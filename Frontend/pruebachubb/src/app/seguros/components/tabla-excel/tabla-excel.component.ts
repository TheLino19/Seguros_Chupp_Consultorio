import { Component, Input } from '@angular/core';
import { ClienteExcel } from '../../interfaces/seguros-response';
import { ClienteServiceService } from '../../../cliente/services/cliente-service.service';
import { filtro } from '../../../cliente/interfaces/response/genericResponse';

@Component({
  selector: 'app-tabla-excel',
  templateUrl: './tabla-excel.component.html',
  styleUrl: './tabla-excel.component.css'
})
export class TablaExcelComponent {
  @Input() clienteExcel: ClienteExcel[] = [];
  cliente?:ClienteExcel;
  
  constructor(private _service: ClienteServiceService){}
  cargarClientes(){
    let filter : filtro={
      cedula:'',
      StateFilter:1,
      codigo:"",
    } ;
    this.clienteExcel =[];
    this._service.obtenerClientes(filter).subscribe({next:r=>{
      if(r.isSuccess == true){
        this.clienteExcel = r.data as ClienteExcel[];
      }
    }})
  }

  asignarSeguro(cliente :ClienteExcel){
    
    this.cliente = cliente;
  }
  
}

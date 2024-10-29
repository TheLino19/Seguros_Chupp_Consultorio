import { Component, Input } from '@angular/core';
import { ClienteResponse } from '../../interfaces/response/genericResponse';
import { Cliente, eliminarRequest } from '../../interfaces/cliente';
import { ClienteServiceService } from '../../services/cliente-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-tabla-clientes',
  templateUrl: './tabla-clientes.component.html',
  styleUrl: './tabla-clientes.component.css'
})
export class TablaClientesComponent {
  @Input() clientes?: ClienteResponse[] = [];
  cliente?: ClienteResponse;

  constructor(private _service: ClienteServiceService) { }

  eliminarCliente(cedula: string) {
    Swal.fire({
      title: "Are you sure",
      text: "No podras revertir esto!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Eliminar"
    }).then((result) => {
      if (result.isConfirmed) {
        let filter: eliminarRequest = {
          cedula: cedula
        };

        this._service.eliminarCliente(filter).subscribe({
          next: r => {
            if (r.isSuccess == true) {
              Swal.fire({
                title: "Eliminado",
                text: "Su archivo ha sido eliminado",
                icon: "success"
              });
            }
          }
        })
      }
    })

  }

  editarCliente(_t14: ClienteResponse) {
    throw new Error('Method not implemented.');
  }

}

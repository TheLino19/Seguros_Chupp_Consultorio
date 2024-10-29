import { Component, Input } from '@angular/core';
import { Seguro } from '../../../interfaces/seguros-response';
import Swal from 'sweetalert2';
import { SeguroService } from '../../../services/seguro.service';

@Component({
  selector: 'app-tabla-seguros',
  templateUrl: './tabla-seguros.component.html',
  styleUrl: './tabla-seguros.component.css'
})
export class TablaSegurosComponent {
  seguro?: Seguro ;
  @Input() seguros: Seguro[] = [];

  constructor(private _service: SeguroService ){

  }


eliminarSeguro(id: string) {
  console.log(id);
  Swal.fire({
    title: '¿Estás seguro?',
    text: 'Esta acción no se puede deshacer',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Sí, eliminar',
    cancelButtonText: 'Cancelar'
  }).then((result) => {
    if (result.isConfirmed) {
      // Si el usuario confirma la eliminación
      this._service.eliminarSeguro(id).subscribe({
        
        next: (r) => {
          Swal.fire({
            icon: 'success',
            title: r.message, // Mensaje de éxito proveniente del backend
            confirmButtonText: 'Aceptar'
          });
        }
      });
    }
  });
}

editarSeguro(seguro: Seguro) {
  this.seguro = seguro as Seguro;
}

 
}

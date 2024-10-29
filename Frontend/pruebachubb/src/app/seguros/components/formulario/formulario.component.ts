import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SeguroService } from '../../services/seguro.service';
import { Seguro, SeguroRequest } from '../../interfaces/seguros-response';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.css'
})
export class FormularioComponent  {
  @Input() seguro?: Seguro;
  clienteForm: FormGroup;

  constructor(private fb: FormBuilder, private _service: SeguroService) {
    this.clienteForm = this.fb.group({
      codigo_seguro: ['', Validators.required],
      suma_asegurada: ['', Validators.required],
      prima: ['', Validators.required],
      rango_edad_min: ['', Validators.required],
      rango_edad_max: ['', Validators.required],
      es_familiar: ['', Validators.required],
      limite_asegurados: ['', Validators.required],
      id_tipo_seguro: ['', Validators.required],

    });
    this.ngOnInit();
  }
  ngOnInit(): void {
    if (this.seguro) {
      this.clienteForm.patchValue({
        codigo_seguro: this.seguro.codigoSeguro, // Asigna el valor correcto aquí
      });
    }
  }

  onRegister() {
    if (this.clienteForm.valid) {

      const seguro: SeguroRequest = this.clienteForm.value as SeguroRequest;
      this._service.crearSeguro(seguro).subscribe({
        next: r => {
          
          Swal.fire({
            icon: 'success',
            title: r.message,
            confirmButtonText: 'Aceptar'
          });
        },
        error: error => {
          console.error('Error registering user', error);
        }

      });

    }

  }



  modificarSeguro() {
    if (this.clienteForm.valid) {
      console.log(this.clienteForm.value);
      const seguro: SeguroRequest = this.clienteForm.value as SeguroRequest;
      this._service.crearSeguro(seguro).subscribe({
        next: r => {
          
          Swal.fire({
            icon: 'success',
            title: r.message,
            confirmButtonText: 'Aceptar'
          });
        },
        error: error => {
          console.error('Error registering user', error);
        }

      });
    }
  }

}

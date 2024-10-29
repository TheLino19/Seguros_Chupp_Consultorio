import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SeguroService } from '../../services/seguro.service';
import { Seguro, SeguroRequest } from '../../interfaces/seguros-response';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.css'
})
export class FormularioComponent implements OnChanges {
  @Input() seguro?: Seguro;
  clienteForm: FormGroup;

  constructor(private fb: FormBuilder, private _service: SeguroService) {
    this.clienteForm = this.fb.group({
      CodigoSeguro: ['', Validators.required],
      SumaAsegurada: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      Prima: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      RangoEdadMin: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      RangoEdadMax: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      LimiteAsegurados: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      IdTipoSeguro: ['', Validators.required],
    });
    
    
  }
  ngOnInit(): void {
    if (this.seguro) {
      this.clienteForm.patchValue({
        codigo_seguro: this.seguro.codigoSeguro
      });
    }
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['seguro'] && this.seguro) {
      this.clienteForm.patchValue({
        CodigoSeguro: this.seguro.codigoSeguro,
        SumaAsegurada: this.seguro.sumaAsegurada,
        Prima: this.seguro.prima,
        RangoEdadMin: this.seguro.rangoEdadMin,
        RangoEdadMax: this.seguro.rangoEdadMax,
        LimiteAsegurados: this.seguro.limiteAsegurados,
        IdTipoSeguro: this.seguro.idTipoSeguro,
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
      this._service.modificarSeguro(seguro).subscribe({
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

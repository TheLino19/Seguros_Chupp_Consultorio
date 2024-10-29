import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ClienteExcel, segurosAsociado } from '../../interfaces/seguros-response';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteServiceService } from '../../../cliente/services/cliente-service.service';
import { filtro, ResponseSeguroEdad } from '../../../cliente/interfaces/response/genericResponse';
import { catchError, map, Observable, of } from 'rxjs';
import { SeguroService } from '../../services/seguro.service';

@Component({
  selector: 'app-formulario-asignar',
  templateUrl: './formulario-asignar.component.html',
  styleUrl: './formulario-asignar.component.css'
})
export class FormularioAsignarComponent implements OnChanges {
  isCedulaDisabled: boolean = false; 
  clienteForm: FormGroup;
  seguros: ResponseSeguroEdad[] = [];
  segurosDisponibles : string[] = [];
  segurosAsociados : segurosAsociado[] = [];
  @Input() clienteExcel?: ClienteExcel;
  constructor(private fb: FormBuilder, public _service: ClienteServiceService , public _serviceSeguro :SeguroService) {
    this.segurosDisponibles = _service.seguroSeleccionado;
    this.clienteForm = this.fb.group({
      cedula: ['', Validators.required],
      nombres: ['', Validators.required],
      telefono: ['', Validators.required],
      edad: ['', [Validators.required, Validators.min(0)]]
    });
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['clienteExcel'] && this.clienteExcel) {
      this.clienteForm.patchValue({
        cedula: this.clienteExcel.cedula,
        nombres: this.clienteExcel.nombres,
        telefono: this.clienteExcel.telefono,
        edad: this.clienteExcel.edad
      });
    }
    this.onInputChange();
    this.buscarCedula();
  }


  onRegister() {
    throw new Error('Method not implemented.');
  }


  onInputChange(): void {
    let filter : filtro={
      cedula:'',
      StateFilter:1,
      codigo:"",
     } ;
    this._serviceSeguro.obtenerSeguros(filter).subscribe({
      next: r => {
        this.seguros = [];
        if (r.isSuccess == true) {
          
          this.seguros = r.data.map((item: { idTipoSeguro: any; limiteAsegurados: any; }) => {
            return {
              Seguro: item.idTipoSeguro,
              Limite: item.limiteAsegurados
            } as ResponseSeguroEdad;
          });
        }
      }

    });
  }

  
buscarCedula(): void {
  this._serviceSeguro.obtenerSegurosAsociados(this.clienteForm.get('cedula')?.value).subscribe({
    next: r => {
      if (r.isSuccess == true) {
        this.segurosAsociados = [];
        this.segurosAsociados = r.data.map((item: { codigo: any; tipoSeguro: any; }) => {
          return {
            codigo: item.codigo,
            tipoSeguro: item.tipoSeguro
          } as segurosAsociado;
        });
      }
    }
  });
}

recibirSeguro(seguro: string) {
  this._service.seguroSeleccionado.push(seguro);
}
  
}

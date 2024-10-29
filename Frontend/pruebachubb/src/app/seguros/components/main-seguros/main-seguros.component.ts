import { Component } from '@angular/core';
import { Seguro, SeguroRequest } from '../../interfaces/seguros-response';
import { SeguroService } from '../../services/seguro.service';
import { MatDialog } from '@angular/material/dialog';
import { FormularioComponent } from '../formulario/formulario.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { filtro } from '../../../cliente/interfaces/response/genericResponse';

@Component({
  selector: 'app-main-seguros',
  templateUrl: './main-seguros.component.html',
  styleUrl: './main-seguros.component.css'
})
export class MainSegurosComponent {

  seguros: Seguro[] = [];
  clienteForm: FormGroup;constructor(private fb: FormBuilder,private _service: SeguroService, public dialog: MatDialog )
   {
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
    this.getSeguros();
  }
  

  getSeguros(){
    this.seguros = [];
    let filter : filtro={
      cedula:'',
      StateFilter:1,
      codigo:"",
     } ;
    this._service.obtenerSeguros(filter).subscribe({next:r=>{
      if(r.isSuccess == true){
        this.seguros = r.data as Seguro[];
      }
    }})
  }

  onRegister() {
    if (this.clienteForm.valid) {
      console.log(this.clienteForm.value);
      const seguro: SeguroRequest = this.clienteForm.value as SeguroRequest;
      this._service.crearSeguro(seguro).subscribe({next:r=>{
       
        Swal.fire({
          icon: 'success',
          title: r.message,
          confirmButtonText: 'Aceptar'
        });
      },
      error :error => {
        console.error('Error registering user', error);
      }
    
    });
    }
  }

  modificarSeguro() {
    if (this.clienteForm.valid) {
      console.log(this.clienteForm.value);
      const seguro: SeguroRequest = this.clienteForm.value as SeguroRequest;
      this._service.crearSeguro(seguro).subscribe({next:r=>{
        
        Swal.fire({
          icon: 'success',
          title: r.message,
          confirmButtonText: 'Aceptar'
        });
      },
      error :error => {
        console.error('Error registering user', error);
      }
    
    });
    }
  }

  
}


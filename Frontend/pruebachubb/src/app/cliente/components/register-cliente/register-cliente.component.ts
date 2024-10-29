import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteServiceService } from '../../services/cliente-service.service';
import { Cliente } from '../../interfaces/cliente';
import Swal from 'sweetalert2'; 
import { ClienteResponse, filtro, ResponseSeguroEdad } from '../../interfaces/response/genericResponse';


@Component({
  selector: 'app-register-cliente',
  templateUrl: './register-cliente.component.html',
  styleUrl: './register-cliente.component.css',
  
})
export class RegisterClienteComponent {

  clienteForm: FormGroup;
  buscar?:string
  
  clientes: ClienteResponse[] = [];

  constructor(private fb: FormBuilder,private _service: ClienteServiceService ) {
    this.clienteForm = this.fb.group({
      cedula: ['', Validators.required],
      nombres: ['', Validators.required],
      telefono: ['', Validators.required],
      FechaNacimiento: ['', [Validators.required]]
    });
    this.getClientes();
  }

  onRegister() {
    if (this.clienteForm.valid) {
      const cliente: Cliente = this.clienteForm.value as Cliente;
      this._service.registerCliente(cliente).subscribe({next:r=>{
        if(r.isSuccess===true){

          Swal.fire({
            icon: 'success',
            title :r.message,
            confirmButtonText: 'Aceptar'
          });
        }else{
          Swal.fire({
            icon: 'error',
            text: r.message,
            confirmButtonText: 'Aceptar'
          });
        }

        
      },
      error :error => {
        console.error('Error registering user', error);
      }
    
    });
    }
  }

  getClientes(){
    this.clientes = [];
    let filter : filtro={
    cedula:'',
    StateFilter:1,
    codigo:"",
   } ;


    this._service.obtenerClientes(filter).subscribe({next:r=>{
      if(r.isSuccess == true){
        this.clientes = r.data as ClienteResponse[];
      }
    }})
  }

  buscarCedula(){
    let text=this.buscar;
    let filter : filtro={
      cedula: text!,
      StateFilter:1,
      codigo:"",
     } ;
   this._service.obtenerClientes(filter).subscribe({next:r=>{
    if(r.isSuccess == true){
      this.clientes = r.data as ClienteResponse[];
    }
  }})
  }

  busquedaCed(event: any) {
    let filter : filtro={
      cedula: event.target.value!,
      StateFilter:1,
      codigo:"",
     } ;
   this._service.obtenerClientes(filter).subscribe({next:r=>{
    if(r.isSuccess == true){
      this.clientes = r.data as ClienteResponse[];
    }
  }})
  }
}


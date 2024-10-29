import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteRoutingModule } from './cliente-routing.module';
import { RegisterClienteComponent } from './components/register-cliente/register-cliente.component';

import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { SharedModule } from '../shared/shared.module';
import { TablaClientesComponent } from './components/tabla-clientes/tabla-clientes.component';
import { FormularioClienteComponent } from './components/formulario-cliente/formulario-cliente.component';









@NgModule({
  declarations: [
    RegisterClienteComponent,
    TablaClientesComponent,
    FormularioClienteComponent
    
  ],
  imports: [
    CommonModule,
    ClienteRoutingModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatMenuModule,
    MatMenuModule,
    MatButtonModule,
    SharedModule,
    FormsModule
    

    
  ]
})
export class ClienteModule { }

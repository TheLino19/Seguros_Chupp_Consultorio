import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SegurosRoutingModule } from './seguros-routing.module';
import { MainSegurosComponent } from './components/main-seguros/main-seguros.component';
import { TablaSegurosComponent } from './components/main-seguros/tabla-seguros/tabla-seguros.component';
import { FormularioComponent } from './components/formulario/formulario.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AsignarComponent } from './components/asignar/asignar.component';
import { TablaExcelComponent } from './components/tabla-excel/tabla-excel.component';
import { FormularioAsignarComponent } from './components/formulario-asignar/formulario-asignar.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
   
  
    MainSegurosComponent,
            TablaSegurosComponent,
            FormularioComponent,
            AsignarComponent,
            TablaExcelComponent,
            FormularioAsignarComponent
  ],
  imports: [
    CommonModule,
    SegurosRoutingModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class SegurosModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainSegurosComponent } from './components/main-seguros/main-seguros.component';
import { AsignarComponent } from './components/asignar/asignar.component';

const routes: Routes = [
  {path:'',component:MainSegurosComponent },
  {path:'asignar',component:AsignarComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SegurosRoutingModule { }

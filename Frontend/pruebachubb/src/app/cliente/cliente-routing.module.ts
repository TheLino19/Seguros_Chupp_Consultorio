import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterClienteComponent } from './components/register-cliente/register-cliente.component';

const routes: Routes = [
  {path:'',component:RegisterClienteComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteRoutingModule { }

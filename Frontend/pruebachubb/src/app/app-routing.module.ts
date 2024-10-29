import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:'',redirectTo:'cliente',pathMatch:'full'},
  {path:'cliente', loadChildren:()=>import("./cliente/cliente.module").then(m=>m.ClienteModule)},
  {path:'seguros', loadChildren:()=>import("./seguros/seguros.module").then(m=>m.SegurosModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

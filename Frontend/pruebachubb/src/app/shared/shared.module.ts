import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { CardSeguroComponent } from './components/card-seguro/card-seguro.component';
import { MenuBarComponent } from './components/menu-bar/menu-bar.component';



@NgModule({
  declarations: [
    CardSeguroComponent,
    MenuBarComponent,
    
  ],
  imports: [
    CommonModule,
    SharedRoutingModule
  ],
  exports:[
    CardSeguroComponent,
    MenuBarComponent,
    
  ]
})
export class SharedModule { }

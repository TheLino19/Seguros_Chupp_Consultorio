import { Component, EventEmitter, Input, OnChanges, OnDestroy, Output, output, SimpleChanges } from '@angular/core';
import { ResponseSeguroEdad } from '../../../cliente/interfaces/response/genericResponse';

@Component({
  selector: 'app-card-seguro',
  templateUrl: './card-seguro.component.html',
  styleUrl: './card-seguro.component.css'
})
export class CardSeguroComponent  {

  @Input() seguros: ResponseSeguroEdad[] = [];
  @Output() seguroSeleccionado: EventEmitter<string> = new EventEmitter();;
  
  enviarDatos(seguro:string) {
    this.seguroSeleccionado.emit(seguro);
  }

}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente, eliminarRequest } from '../interfaces/cliente';
import { filtro, GenericResponse } from '../interfaces/response/genericResponse';

@Injectable({
  providedIn: 'root'
})
export class ClienteServiceService {
  seguroSeleccionado: string[] = [];
  private apiUrl = 'https://localhost:7052/api/Cliente/'; 
  private apiUrlValidacion = 'http://localhost:5051/api/ValidacionControlller/'; 
  constructor(private http: HttpClient) { }

  registerCliente(cliente: Cliente): Observable<GenericResponse> {
    return this.http.post<GenericResponse>(`${this.apiUrl}RegisterCliente`, cliente);
  }
  seguroEdad(edad: number): Observable<GenericResponse> {
    return this.http.post<GenericResponse>(`${this.apiUrlValidacion}SeguroPorEdad`, edad);
  }
  
  obtenerClientes(baseFiltro:filtro): Observable<GenericResponse> {
    return this.http.post<GenericResponse>(`${this.apiUrl}ListarClientes`,baseFiltro);
  }

  eliminarCliente(request : eliminarRequest){
    return this.http.post<GenericResponse>(`${this.apiUrl}EliminarCliente`,request);
  }

  resetSeguroSeleccionado() {
    this.seguroSeleccionado = []; 
  }
  
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { filtro, GenericResponse } from '../../cliente/interfaces/response/genericResponse';
import { Observable } from 'rxjs';
import { SeguroRequest } from '../interfaces/seguros-response';

@Injectable({
  providedIn: 'root'
})
export class SeguroService {
  
  private apiUrl = 'https://localhost:7052/api/Seguro/'; 
  private excelUrl = 'https://localhost:7052/api/Cliente/';
  constructor(private http: HttpClient) { }

  obtenerSeguros(baseFiltro:filtro): Observable<GenericResponse> {
    return this.http.post<GenericResponse>(`${this.apiUrl}ListSeguros`, baseFiltro);
  }
  crearSeguro(seguro:SeguroRequest): Observable<GenericResponse> {
    return this.http.post<GenericResponse>(`${this.apiUrl}CrearSeguro`,seguro);
  }

  eliminarSeguro(id: number): Observable<GenericResponse> {
    return this.http.request<GenericResponse>('DELETE', `${this.apiUrl}eliminarSeguro`, {
      body: { id }, // El cuerpo donde se envía el ID
      observe: 'body' // Se asegura de que se observe el cuerpo de la respuesta
    });
  }

  modificarSeguro(seguro:SeguroRequest): Observable<GenericResponse> {
    return this.http.put<GenericResponse>(`${this.apiUrl}editarSeguro`,seguro);
  }

  obtenerExcel(path:string):Observable<GenericResponse>{
    return this.http.post<GenericResponse>(`${this.excelUrl}obtenerExcel`,{ ruta: path });
  }

  obtenerSegurosAsociados(cedula:string):Observable<GenericResponse>{
    return this.http.post<GenericResponse>(`${this.excelUrl}ListarSegurosAsociados`,{ cedula: cedula });
  }
  
  
}

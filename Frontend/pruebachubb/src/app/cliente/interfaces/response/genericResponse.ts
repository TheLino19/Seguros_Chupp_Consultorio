export interface GenericResponse {
    isSuccess: boolean;
    data: any;
    message: string;
    errors:any;
      
}

export interface ResponseSeguroEdad{
    Seguro: string,
    Limite:number
}

export interface ClienteResponse {
    cedula: string;
    nombres: string;
    edad: number;
    estado: boolean;
  }

export interface filtro{
    cedula: string ;
    StateFilter: number;
    codigo: string;
}
  

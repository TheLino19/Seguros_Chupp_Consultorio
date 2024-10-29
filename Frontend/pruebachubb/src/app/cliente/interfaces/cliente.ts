export interface Cliente {
    cedula: string;
    nombres: string;
    telefono: string;
    FechaNacimiento: Date;
      
}

export interface eliminarRequest{
    cedula : string;
}
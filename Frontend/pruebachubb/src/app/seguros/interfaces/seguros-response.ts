export interface Seguro {
    idSeguro: number;
    codigoSeguro: string;
    sumaAsegurada: number;
    prima: number;
    rangoEdadMin: number;
    rangoEdadMax: number;
    esFamiliar: string;
    limiteAsegurados: number;
    idTipoSeguro: string;
    idEstado: boolean;
  }
  
  export interface SeguroRequest {
    CodigoSeguro: string;
    SumaAsegurada: number;
    Prima: number;
    RangoEdadMin: number;
    RangoEdadMax: number;
    LimiteAsegurados: number;
    IdTipoSeguro: string;
  }

  export interface ClienteExcel {
    cedula: string;
    nombres: string;
    telefono: string;
    edad: number;
  }

  export interface segurosAsociado {
    codigo: string;
    tipoSeguro: string;
  }
  
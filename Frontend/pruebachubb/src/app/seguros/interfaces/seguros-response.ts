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
    codigo_seguro: string;
    suma_asegurada: number;
    prima: number;
    rango_edad_min: number;
    rango_edad_max: number;
    es_familiar: string;
    limite_asegurados: number;
    id_tipo_seguro: string;
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
  
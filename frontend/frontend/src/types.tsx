export interface Person {
    id: string; // Guid en C# se puede representar como una cadena en TypeScript
    run?: string; // '?' indica que el campo es opcional
    runBody: number;
    runDigit: string; // Asignamos un valor por defecto en TypeScript, ya que C# permite nulos
    fullName?: string;
    names: string;
    lastName: string;
    motherLastName?: string;
    email?: string;
    genderCode: number;
    birthDate?: string; // DateOnly se puede representar como una cadena en TypeScript
    regionCode?: number;
    cityCode?: number;
    communeCode: number;
    address?: string;
    phone?: number;
    observations?: string;
}

export interface Region {
    code: number;
    name: string
}

export interface City {
    code: number;
    name: string;
    regionCode: number
}

export interface Commune {
    code: number;
    name: string;
    regionCode: number;
    cityCode: number;
}
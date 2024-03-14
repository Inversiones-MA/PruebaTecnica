import React, { useState, useEffect } from 'react';
import axios from 'axios';

interface Persona {
    id: number;
    names: string;
    lastName: string;
    run: string;
    // Agrega más propiedades según tus necesidades
}

const GridPersons: React.FC = () => {
    const [personas, setPersonas] = useState<Persona[]>([]);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await axios.get<Persona[]>('https://localhost:7163/person');
            setPersonas(response.data);
            console.log(response.data);
        } catch (error) {
            console.error('Error al obtener datos:', error);
        }
    };

    return (
        <div className="container">
            <h2>Lista de Personas</h2>
            <div className="table-responsive">
                <table className="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>Apellido</th>
                            <th>Run</th>
                            <th>Acciones</th> {/* Agrega una columna para las acciones */}
                        </tr>
                    </thead>
                    <tbody>
                        {personas.map(persona => (
                            <tr key={persona.id}>
                                <td>{persona.names}</td>
                                <td>{persona.lastName}</td>
                                <td>{persona.run}</td>
                                <td>
                                    <button className="btn btn-primary mr-2">Editar</button>
                                    <button className="btn btn-danger">Eliminar</button>
                                </td> {/* Agrega botones en la última columna */}
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default GridPersons;

import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Person } from './types';

interface Props {
    personas: Person[]; // Definir el tipo de la variable personas como un array de tipo Person
}

const GridPersons: React.FC<Props> = ({ personas }) => { // Recibir personas como prop
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
                            <th>Acciones</th>
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
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default GridPersons;

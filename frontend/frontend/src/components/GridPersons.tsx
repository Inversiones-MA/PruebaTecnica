import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Person } from './types';

interface Props {
    personas: Person[];
    showForm: boolean;
    onEditClick: (id: string) => void;
    onDeleteClick: (id: string) => void;
}

const GridPersons: React.FC<Props> = ({ personas, showForm, onEditClick, onDeleteClick }) => { 
    return (
        <div className="container">
            <h2>Lista de Personas</h2>
            <div className="table-responsive">
                <table className="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>R.U.N.</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        {personas.map(persona => (
                            <tr key={persona.id}>
                                <td>{persona.names + ' ' + persona.lastName + ' ' + persona.motherLastName}</td>
                                <td>{persona.runBody + '-' + persona.runDigit}</td>
                                <td className="d-flex align-items-center gap-4">
                                    <div>
                                        <button
                                            className="btn btn-primary"
                                            disabled={showForm}
                                            onClick={() => onEditClick(persona.id)}
                                        >
                                            Editar
                                        </button>
                                    </div>
                                    <div>
                                        <button
                                            className="btn btn-danger"
                                            disabled={showForm}
                                            onClick={() => onDeleteClick(persona.id)}
                                        >
                                            Eliminar
                                        </button>
                                    </div>
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

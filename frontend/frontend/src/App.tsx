import React, { useState, useEffect } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import GridPersons from './components/GridPersons';
import PersonForm from './components/PersonForm';
import { Person } from './types';

function App() {
    const [personas, setPersonas] = useState<Person[]>([]);
    const [currentPerson, setCurrentPerson] = useState<Person | null>(null); // Establece el tipo de currentPerson como Person | null

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await axios.get<Person[]>('https://localhost:7163/person');
            setPersonas(response.data);
            console.log(response.data);
        } catch (error) {
            console.error('Error al obtener datos:', error);
        }
    };

    const onSubmit = async (values: Person) => { // Establece el tipo de values como Person
        try {
            console.log(values);
            if (values.id == null || values.id == "") {
                const { id, ...postData } = values;
                const response = await axios.post('https://localhost:7163/person', postData, {
                    headers: {
                        'Accept': 'text/plain',
                        'Content-Type': 'application/json'
                    }
                });
                console.log('Respuesta del servidor:', response.data);
                values.id = response.data;
                values.run = values.runBody + '-' + values.runDigit;
                setPersonas([
                    ...personas,
                    values
                ])
            }
        } catch (error) {
            console.error('Error al obtener datos:', error);
        }
    };

    return (
        <div className="container">
            <div className="row justify-content-center mt-5">
                <div className="col-md-8">
                    <h2 className="text-center mb-4">Agregar/Edit Person</h2>
                    <PersonForm person={currentPerson} onSubmit={onSubmit} />
                </div>
            </div>
            <div className="row mt-5">
                <div className="col-md-12 text-left"> {/* Cambia text-right a text-left */}
                    <button className="btn btn-primary">Agregar Nueva Persona</button>
                </div>
            </div>
            <div className="row mt-5">
                <div className="col-md-12">
                    <GridPersons personas={personas} />
                </div>
            </div>
        </div>
    );

}

export default App;

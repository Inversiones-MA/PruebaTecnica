import React, { useState, useEffect } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import GridPersons from './components/GridPersons';
import PersonForm from './components/PersonForm';
import { Person } from './types';

function App() {
    const [personas, setPersonas] = useState<Person[]>([]);
    const [currentPerson, setCurrentPerson] = useState<Person | null>(null);
    const [showForm, setShowForm] = useState<boolean>(false);
    const [alert, setAlert] = useState<string | null>(null);
    const [showModal, setShowModal] = useState<boolean>(false);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await axios.get<Person[]>('https://localhost:7163/person');
            setPersonas(response.data);
        } catch (error) {
            console.error('Error al obtener datos:', error);
            setAlert('Error al obtener datos');
        }
    };

    const onSubmit = async (values: Person) => {
        try {
            if (values.id == null || values.id == "") {
                const { id, ...postData } = values;
                const response = await axios.post('https://localhost:7163/person', postData, {
                    headers: {
                        'Accept': 'text/plain',
                        'Content-Type': 'application/json'
                    }
                });
                values.id = response.data;
                values.run = values.runBody + '-' + values.runDigit;
                setPersonas([
                    ...personas,
                    values
                ]);
                setAlert('Persona agregada correctamente');
            } else {
                await axios.put('https://localhost:7163/person', values, {
                    headers: {
                        'Accept': 'text/plain',
                        'Content-Type': 'application/json'
                    }
                });
                const editedPersonIndex = personas.findIndex(p => p.id == values.id);
                const newPersonsList = [...personas];
                newPersonsList[editedPersonIndex] = values;
                setPersonas(newPersonsList);
                setAlert('Persona actualizada correctamente');
            }
            setCurrentPerson(null);
            setShowForm(false);
        } catch (error) {
            console.error('Error al obtener datos:', error);
            setAlert('Error al guardando la información');
        }
    };

    const handleAddNewPersonClick = () => {
        if (!showForm) {
            setShowForm(true);
        } else {
            setCurrentPerson(null);
            setShowForm(false);
        }
    }

    const handleGridEditBtnClick = (idPerson: string) => {
        const person = personas.find(p => p.id == idPerson);
        setCurrentPerson(person);
        setShowForm(true);
        window.scrollTo({
            top: 0,
            left: 0,
            behavior: 'smooth'
        });
    }

    const handleGridDeleteBtnClick = (idPerson: string) => {
        const person = personas.find(p => p.id == idPerson);
        if (person != null) {
            setCurrentPerson(person);
            setShowModal(true);
        }
        
    }

    const handleConfirmDelete = async () => {
        try {
            await axios.delete(`https://localhost:7163/person?idPerson=${currentPerson.id}`);
            let newPersonsList = [...personas];
            newPersonsList = newPersonsList.filter(p => p.id != currentPerson.id);
            setPersonas(newPersonsList);
            setAlert('Registro eliminado correctamente');

        } catch (error) {
            console.error('Error al eliminando datos:', error);
            setAlert('Error al eliminar la información');
        } finally {
            setCurrentPerson(null);
            setShowModal(false);
        }
    };

    const handleCancelDelete = () => {
        setShowModal(false);
        setCurrentPerson(null);
    };

    return (
        <div className="container">
            {alert && (
                <div className={`alert alert-${alert.includes('Error') ? 'danger' : 'success'} alert-dismissible`} role="alert">
                    <button type="button" className="btn-close" aria-label="Close" onClick={() => setAlert(null)}></button>
                    {alert}
                </div>
            )}
            {showForm && (
                <div className="row justify-content-center mt-3">
                    <div className="col-md-8">
                        <h2 className="text-center mb-4">{currentPerson == null ? "Agregar persona" : "Actualizar Persona"}</h2>
                        <PersonForm person={currentPerson} onSubmit={onSubmit} />
                    </div>
                </div>
            )}
            <div className="row mt-3">
                <div className="col-md-12 text-left">
                    <button
                        className={!showForm ? "btn btn-success" : "btn btn-danger"}
                        onClick={handleAddNewPersonClick}>{!showForm ? "Agregar Nueva Persona" : "Cancelar"}</button>
                </div>
            </div>
            <div className="row mt-3">
                <div className="col-md-12">
                    <GridPersons
                        personas={personas}
                        showForm={showForm}
                        onEditClick={handleGridEditBtnClick}
                        onDeleteClick={handleGridDeleteBtnClick}
                    />
                </div>
            </div>
            {showModal && (
                <div className="modal fade show" tabIndex="-1" role="dialog" style={{ display: 'block' }}>
                    <div className="modal-dialog modal-dialog-centered" role="document">
                        <div className="modal-content">
                            <div className="modal-header d-flex justify-content-between bg-light">
                                <h5 className="modal-title">Confirmar Eliminación</h5>
                                <button type="button" className="close" onClick={handleCancelDelete}>
                                    <span>&times;</span>
                                </button>
                            </div>

                            <div className="modal-body">
                                <p>¿Estás seguro de que deseas eliminar este registro?</p>
                            </div>
                            <div className="modal-footer">
                                <button type="button" className="btn btn-danger" onClick={handleConfirmDelete}>Confirmar</button>
                                <button type="button" className="btn btn-secondary" onClick={handleCancelDelete}>Cancelar</button>
                            </div>
                        </div>
                    </div>
                </div>
            )}


        </div>
    );
}

export default App;

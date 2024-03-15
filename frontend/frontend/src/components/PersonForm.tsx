import React, { useState, useEffect } from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import axios from 'axios';
import { Person, Region, City, Commune } from '../types';

interface Props {
    person: Person | null;
    onSubmit: (values: Person) => void;
}

const PersonForm: React.FC<Props> = ({ person, onSubmit }) => {
    const [regions, setRegions] = useState<Region[]>([]);
    const [cities, setCities] = useState<City[]>([]);
    const [communes, setCommunes] = useState<Commune[]>([]);

    useEffect(() => {
        const fetchRegions = async () => {
            try {
                const response = await axios.get('https://localhost:7163/region');
                setRegions(response.data);
            } catch (error) {
                console.error('Error al obtener las regiones:', error);
            }
        };

        fetchRegions();

        if (person != null) {
            updateSelectValues(person);
        }
    }, []);

    const updateSelectValues = async (p:Person) => {
        if (p.regionCode) {
            await handleRegionChange(p.regionCode);

            if (p.cityCode) {
                await handleCityChange(p.regionCode, p.cityCode);
            }
        }
        
    }

    const initialValues: Person = person || {
        id: '',
        runBody: 0,
        runDigit: '',
        names: '',
        lastName: '',
        motherLastName: '',
        email: '',
        genderCode: 1,
        birthDate: '',
        regionCode: undefined,
        cityCode: undefined,
        communeCode: undefined,
        address: '',
        phone: undefined,
        observations: ''
    };

    const validationSchema = Yup.object().shape({
        runBody: Yup.string().required('El cuerpo del R.U.N. es obligatorio'),
        runDigit: Yup.string().required('El digito del R.U.N. es obligatorio'),
        names: Yup.string().required('El nombre es obligatorio'),
        lastName: Yup.string().required('El apellido es obligatorio'),
        genderCode: Yup.number().oneOf([1, 2], 'El código de género es obligatorio'),
        birthDate: Yup.string().required('La fecha de nacimiento es obligatoria')
    });

    const handleSubmit = async (values: Person) => {
        console.log(values);
        try {
            onSubmit(values);
        } catch (error) {
            console.error('Error al obtener datos:', error);
        }
    };


    const handleRegionChange = async (value:number) => {
        setCities([]);
        setCommunes([]);
        console.log(value);
        try {
            if (!value) {
                return;
            }
            const response = await axios.get(`https://localhost:7163/city?regionCode=${value}`);
            setCities(response.data);
        } catch (error) {
            console.error('Error al obtener las ciudades:', error);
        }
    };

    const handleCityChange = async (regionValue:number, cityValue:number) => {
        setCommunes([]);
        try {
            if (!regionValue || !cityValue) {
                return;
            }
            const response = await axios.get(`https://localhost:7163/commune?regionCode=${regionValue}&cityCode=${cityValue}`);
            setCommunes(response.data);
        } catch (error) {
            console.error('Error al obtener las ciudades:', error);
        }
    };

    

    return (
        <Formik initialValues={initialValues} validationSchema={validationSchema} onSubmit={handleSubmit}>
            {({ values, isSubmitting, setFieldValue }) => (
                <Form>
                    <div className="form-group mb-2">
                        <label htmlFor="names">R.U.N:</label>
                        <Field type="text" name="run" className="form-control" disabled />
                    </div>

                    <div className="form-group row mb-2">
                        <div className="col">
                            <label htmlFor="runBody">R.U.N. Cuerpo:</label>
                            <Field type="number" name="runBody" className="form-control" />
                            <ErrorMessage name="runBody" component="div" className="text-danger" />
                        </div>
                        <div className="col">
                            <label htmlFor="runDigit">R.U.N. Digito:</label>
                            <Field type="text" name="runDigit" className="form-control" />
                            <ErrorMessage name="runDigit" component="div" className="text-danger" />
                        </div>
                    </div>


                    <div className="form-group mb-2">
                        <label>Nombres:</label>
                        <div className="row">
                            <div className="col">
                                <Field type="text" name="names" placeholder="Ingrese sus nombres" className="form-control" />
                                <ErrorMessage name="names" component="div" className="text-danger" />
                            </div>
                            <div className="col">
                                <Field type="text" name="lastName" placeholder="Ingrese sus apellidos" className="form-control" />
                                <ErrorMessage name="lastName" component="div" className="text-danger" />
                            </div>
                            <div className="col">
                                <Field type="text" name="motherLastName" placeholder="Ingrese su apellido materno" className="form-control" />
                                <ErrorMessage name="motherLastName" component="div" className="text-danger" />
                            </div>
                        </div>
                    </div>


                    <div className="form-group mb-2">
                        <label htmlFor="email">Email:</label>
                        <Field type="email" name="email" className="form-control" />
                    </div>

                    <div className="form-group mb-2">
                        <label className="d-block">Género:</label>
                        <div className="form-check form-check-inline">
                            <Field type="radio" name="genderCode" value={1} className="form-check-input" id="male" />
                            <label htmlFor="male" className="form-check-label mr-3">Masculino</label>
                        </div>
                        <div className="form-check form-check-inline">
                            <Field type="radio" name="genderCode" value={2} className="form-check-input" id="female" />
                            <label htmlFor="female" className="form-check-label">Femenino</label>
                        </div>
                        <ErrorMessage name="genderCode" component="div" className="text-danger" />
                    </div>


                    <div className="form-group mb-2">
                        <label htmlFor="birthDate">Fecha de Nacimiento:</label>
                        <Field type="date" name="birthDate" className="form-control" />
                        <ErrorMessage name="birthDate" component="div" className="text-danger" />
                    </div>

                    <div className="form-group mb-2">
                        <label htmlFor="regionCode">Región:</label>
                        <Field
                            as="select"
                            id="regionCode"
                            name="regionCode"
                            className="form-control"
                            onChange={(event) => {
                                const value = event.target.value ? parseInt(event.target.value) : null;
                                handleRegionChange(value);
                                setFieldValue("regionCode", value);
                                setFieldValue("cityCode", null);
                                setFieldValue("communeCode", null);
                            }}
                        >
                            <option value="">Selecciona una región</option>
                            {regions.map(region => (
                                <option key={region.code} value={region.code}>
                                    {region.name}
                                </option>
                            ))}
                        </Field>
                        <ErrorMessage name="regionCode" component="div" className="text-danger" />
                    </div>

                    <div className="form-group mb-2">
                        <label htmlFor="cityCode">Ciudad:</label>
                        <Field
                            as="select"
                            name="cityCode"
                            className="form-control"
                            onChange={(event) => {
                                const value = event.target.value ? parseInt(event.target.value) : null;
                                handleCityChange(values.regionCode, value);
                                setFieldValue("cityCode", value);
                                setFieldValue("communeCode", null);
                            }}
                        >
                            <option value="">Selecciona una ciudad</option>
                            {cities.map(city => (
                                <option key={city.code} value={city.code}>
                                    {city.name}
                                </option>
                            ))}
                        </Field>
                        <ErrorMessage name="cityCode" component="div" className="text-danger" />
                    </div>

                    <div className="form-group mb-2">
                        <label htmlFor="communeCode">Comuna:</label>
                        <Field as="select" name="communeCode" className="form-control">
                            <option value="">Selecciona una comuna</option>
                            {communes.map(commune => (
                                <option key={commune.code} value={commune.code}>
                                    {commune.name}
                                </option>
                            ))}
                        </Field>
                        <ErrorMessage name="communeCode" component="div" className="text-danger" />
                    </div>

                    <div className="form-group mb-2">
                        <label htmlFor="address">Dirección:</label>
                        <Field type="text" name="address" className="form-control" />
                        <ErrorMessage name="address" component="div" className="text-danger" />
                    </div>

                    <div className="form-group mb-2">
                        <label htmlFor="phone">Teléfono:</label>
                        <Field type="number" name="phone" className="form-control" />
                        <ErrorMessage name="phone" component="div" className="text-danger" />
                    </div>

                    <div className="form-group mb-2">
                        <label htmlFor="observations">Observaciones:</label>
                        <Field as="textarea" name="observations" className="form-control" />
                        <ErrorMessage name="observations" component="div" className="text-danger" />
                    </div>

                    <button type="submit" className="btn btn-primary" disabled={isSubmitting}>
                        {person ? 'Editar' : 'Crear'}
                    </button>
                </Form>
            )}
        </Formik>
    );
};

export default PersonForm;

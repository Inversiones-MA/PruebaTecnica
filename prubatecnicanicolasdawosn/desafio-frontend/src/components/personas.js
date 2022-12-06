import React, { Component } from "react";
import { Table, Button, Alert } from "flowbite-react";
import { Link } from "react-router-dom";

export default class personas extends Component {
  state = {
    personas: [],
    showModal: false
  }
  async componentDidMount() {
    await this.Getpersonas();
}

async BorrarPersona(e, id){
  const requestObj = {
    method: 'DELETE',
    cache: 'no-cache',
    mode: 'cors',
    headers: {
        "Content-Type": "application/x-www-form-urlencoded",
        "origin": "*"
    },
    referrerPolicy: 'no-referrer'
}
try {
  const url = process.env.REACT_APP_URL + "personas/" + id.toString()
  const serviceResponse = await fetch(url, requestObj);
  if (serviceResponse.ok) {
    this.setState({
      status: true,
      titulo: "Creado",
      descripcion: "Persona borrada correctamente ",
      color: "success"
    })
    setTimeout(() => {
      this.setState({         
        status: false});
    }, 1000)
    await this.Getpersonas();
} else {
  this.setState({
    status: true,
    titulo: "Fallido",
    descripcion: "Persona no se logro borrar ",
    color: "failure"
  })
  setTimeout(() => {
    this.setState({         
      status: false});
  }, 1000)
};
} catch (exception) {
  this.setState({
    status: true,
    titulo: "Fallido",
    descripcion: "Persona no se logro borrar ",
    color: "failure"
  })
  setTimeout(() => {
    this.setState({         
      status: false});
  }, 1000)
}
}

async Getpersonas () {
  const requestObj = {
    method: 'GET',
    cache: 'no-cache',
    mode: 'cors',
    headers: {
        "Content-Type": "application/x-www-form-urlencoded",
        "origin": "*"
    },
    referrerPolicy: 'no-referrer'
}
try {
  const url = process.env.REACT_APP_URL + "personas"
  const serviceResponse = await fetch(url, requestObj);
  const jsonResult = await serviceResponse.json();
  if (serviceResponse.ok) {
    this.setState({
        personas: jsonResult
    });
};
} catch (exception) {
    return exception;
}
}
  render() {
    return (
<div>
{
          this.state.status && 
<Alert
  color={this.state.color}
  >
  <span>
    <span className="font-medium">
    {this.state.titulo}
    </span>
    {' '}{this.state.descripcion }
  </span>
</Alert>
        }
<div className="bg-white py-3">
  <div>
  <Button>
    <Link to="/createpersona">
    Crear
    </Link>
  </Button>
  </div>
</div>

<Table hoverable={true}>
  <Table.Head>
    <Table.HeadCell>
      Nombre
    </Table.HeadCell>
    <Table.HeadCell>
      Rut
    </Table.HeadCell>
    <Table.HeadCell>
      <span className="sr-only">
        Editar
      </span>
    </Table.HeadCell>
    <Table.HeadCell>
      <span className="sr-only">
        Borrar
      </span>
    </Table.HeadCell>
  </Table.Head>

{  this.state.personas.map((persona) => {
    return <Table.Body className="divide-y">
    <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
      <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
       {persona.nombre}
      </Table.Cell>
      <Table.Cell>
       {persona.run}
      </Table.Cell>
      <Table.Cell>
        <Link
          to={"/editpersona"}
          element = {persona.id}
          className="font-medium text-green-600 hover:underline dark:text-green-500"
        >
          Editar
        </Link>
      </Table.Cell>
      <Table.Cell>
        <Link
          onClick={(e) => this.BorrarPersona(e, persona.id)}
          className="font-medium text-red-600 hover:underline dark:text-red-500"
        >
          Borrar
        </Link>
      </Table.Cell>
    </Table.Row>
  </Table.Body>
  })}
</Table>
</div>
    );
  }
}

import React, { Component } from "react";
import { Table, Button, Alert } from "flowbite-react";
import { Link } from "react-router-dom";

export default class cuidadanos extends Component {
  state = {
    cuidadanos: [],
    showModal: false
  }
  async componentDidMount() {
    await this.GetCuidadanos();
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
  const url = "https://localhost:7274/api/personas/" + id.toString()
  const serviceResponse = await fetch(url, requestObj);
  if (serviceResponse.ok) {
    this.setState({
      status: true,
      titulo: "Creado",
      descripcion: "Persona borrada correctamente ",
      color: "success"
    })
    await this.GetCuidadanos();
} else {
  this.setState({
    status: true,
    titulo: "Fallido",
    descripcion: "Persona no se logro borrar ",
    color: "failure"
  })
};
} catch (exception) {
  this.setState({
    status: true,
    titulo: "Fallido",
    descripcion: "Persona no se logro borrar ",
    color: "failure"
  })
}
}

async GetCuidadanos () {
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
  const url = "https://localhost:7274/api/personas"
  const serviceResponse = await fetch(url, requestObj);
  const jsonResult = await serviceResponse.json();
  if (serviceResponse.ok) {
    this.setState({
        cuidadanos: jsonResult
    });
} else {
    //this.alertBanner.current.show(true, 'danger', jsonResult);
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

{  this.state.cuidadanos.map((cuidadano) => {
    return <Table.Body className="divide-y">
    <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
      <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
       {cuidadano.nombre}
      </Table.Cell>
      <Table.Cell>
       {cuidadano.run}
      </Table.Cell>
      <Table.Cell>
        <Link
          to={"/editpersona"}
          element = {cuidadano.id}
          className="font-medium text-green-600 hover:underline dark:text-green-500"
        >
          Editar
        </Link>
      </Table.Cell>
      <Table.Cell>
        <Link
          onClick={(e) => this.BorrarPersona(e, cuidadano.id)}
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

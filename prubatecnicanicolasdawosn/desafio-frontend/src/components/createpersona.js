import React, { Component  } from "react";
import { Label, TextInput, Radio, Button, Textarea, Select, Alert } from "flowbite-react";

export default class createpersona extends Component {
  state = {
    regiones: [],
    comunas: [],
    ciudades: [],
    status: false,
    sexos: [
      {
        nombre: "Masculino",
        letra:
          "M",
          codigo: 1
      },
      {
          nombre: "Femenino",
          letra:
            "F",
            codigo: 2
        }
    ],
    persona:  {      
      runCuerpo: 0,
      sexoCodigo: 2,
      runDigito: "",
      nombres: "",
      apellidoPaterno: "",
      apellidoMaterno: "",
      email: "",
      fechaNacimiento: ''
    },
    showCiudad: true,
    showComuna: true  
  }

  async componentDidMount() {
    await this.GetRegiones();
    await this.GetCiudades();
    await this.GetComunas();
  }

  async GetRegiones () {
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
    const url = "https://localhost:7274/api/regiones"
    const serviceResponse = await fetch(url, requestObj);
    const jsonResult = await serviceResponse.json();
    if (serviceResponse.ok) {
      this.setState({
        regiones: jsonResult
      });
  } else {
      //this.alertBanner.current.show(true, 'danger', jsonResult);
  };
  } catch (exception) {
      return exception;
  }
  }

  async GetCiudades () {
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
    const url = "https://localhost:7274/api/regiones/ciudades"
    const serviceResponse = await fetch(url, requestObj);
    const jsonResult = await serviceResponse.json();
    if (serviceResponse.ok) {
      this.setState({
        ciudades: jsonResult
      });
  } else {
      //this.alertBanner.current.show(true, 'danger', jsonResult);
  };
  } catch (exception) {
      return exception;
  }
  }

  async GetComunas () {
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
    const url = "https://localhost:7274/api/regiones/ciudades/comunas"
    const serviceResponse = await fetch(url, requestObj);
    const jsonResult = await serviceResponse.json();
    if (serviceResponse.ok) {
      this.setState({
        comunas: jsonResult
      });
  } else {
      //this.alertBanner.current.show(true, 'danger', jsonResult);
  };
  } catch (exception) {
      return exception;
  }
  }

  onChangeRegion = (e) =>{
    const ciudadesFiltradas = this.state.ciudades.filter(x => x.regionCodigo.toString() === e.target.value)
    const persona = this.state.persona
    persona.regionCodigo = e.target.value

    this.setState({
      ciudades: ciudadesFiltradas,
      showCiudad: false,
      persona: persona
    })
  }

  onChangeCiudad =(e) =>{
    const comunasFiltradas = this.state.comunas.filter(x => x.ciudadCodigo.toString() === e.target.value)
    const persona = this.state.persona
    persona.ciudadCodigo = e.target.value

    this.setState({
      comunas: comunasFiltradas,
      showComuna: false,
      persona: persona
    })
  }

  onChangeComuna(e){
    const persona = this.state.persona
    persona.ciudadCodigo = e.target.value

    this.setState({
      persona: persona
    })
  }

  async CrearPersona(e){
    e.preventDefault();
    const persona = this.state.persona
    const requestObj = {
      method: 'POST',
      headers: {
          'Accept': '*/*',
          'Content-Type': 'application/json'
      },
      body: JSON.stringify(persona)
  }
  try {
    const url = "https://localhost:7274/api/personas"
    const serviceResponse = await fetch(url, requestObj);
    if (serviceResponse.ok) {
      this.setState({
        status: true,
        titulo: "Creado",
        descripcion: "Persona creada correctamente ",
        color: "success"
      })
//
  } else {
    this.setState({
      status: true,
      titulo: "Fallido",
      descripcion: "Persona no se logro crear ",
      color: "failure"
    })
  };
  } catch (exception) {
    this.setState({
      status: true,
      titulo: "Fallido",
      descripcion: "Persona no se logro crear ",
      color: "failure"
    })
  }
  }

  handleChange(event) {
    var name = event.target.name
    var val = event.target.value
    var persona  = this.state.persona
    persona[name] = val
    this.setState(persona)
  }

  handleChangeSexo(event){
    var name = event.target.id
    var sexo = this.state.sexos.find(x => x.nombre === name);
    var persona  = this.state.persona
    persona.sexoCodigo = sexo.codigo
    this.setState(persona)
  }
    render() {
        return (
        <div>
<form className="flex flex-col gap-4">
<div>
    <div className="mb-2 block">
      <Label
        htmlFor="base"
        value="Rut"
      />
    </div>
    <TextInput
      id="runCuerpo"
      type="text"
      sizing="md"
      value={this.state.runCuerpo} name="runCuerpo" onChange={(e) => this.handleChange(e)}
    />
  </div>
  <div>
    <div className="mb-2 block">
      <Label
        htmlFor="base"
        value="runDigito"
      />
    </div>
    <TextInput
      id="runDigito"
      type="text"
      sizing="md"
      value={this.state.runDigito} name="runDigito" onChange={(e) => this.handleChange(e)}
    />
  </div>
  <div>
    <div className="mb-2 block">
      <Label
        htmlFor="base"
        value="Nombre"
      />
    </div>
    <TextInput
      id="nombres"
      type="text"
      sizing="md"
      value={this.state.nombres} name="nombres" onChange={(e) => this.handleChange(e)}
    />
  </div>

  <div>
    <div className="mb-2 block">
      <Label
        htmlFor="base"
        value="Apellido paterno"
      />
    </div>
    <TextInput
      id="apellidoPaterno"
      type="text"
      sizing="md"
      value={this.state.apellidoPaterno} name="apellidoPaterno" onChange={(e) => this.handleChange(e)}
      
    />
  </div>

  <div>
    <div className="mb-2 block">
      <Label
        htmlFor="base"
        value="Apellido materno"
      />
    </div>
    <TextInput
      id="apellidoMaterno"
      type="text"
      sizing="md"
      value={this.state.apellidoMaterno} name="apellidoMaterno" onChange={(e) => this.handleChange(e)}
    />
  </div>

  <div>
    <div className="mb-2 block">
      <Label
        htmlFor="base"
        value="Email"
      />
    </div>
    <TextInput
      id="email"
      type="text"
      sizing="md"
      value={this.state.email} name="email" onChange={(e) => this.handleChange(e)}
    />
  </div>

  <fieldset
  className="flex flex-col gap-4"
  id="radio"
>
  <legend>
    Sexo
  </legend>
  <div className="flex items-center gap-2">
    <Radio
      id="Femenino"
      name="sexoCodigo"
      value={this.state.sexoCodigo}
      onChange={(e) => this.handleChangeSexo(e)}
      defaultChecked={true}
    />
    <Label htmlFor="united-state">
      Femenino
    </Label>
  </div>
  <div className="flex items-center gap-2">
    <Radio
      id="Masculino"
      name="sexoCodigo"
      value={this.state.sexoCodigo}
      onChange={(e) => this.handleChangeSexo(e)}
    />
    <Label htmlFor="germany">
      Masculino
    </Label>
  </div>
</fieldset>
<div id="select">
      <div className="mb-2 block">
        <Label
          htmlFor="region"
          value="Region"
        />
      </div>
      <Select
      id="region"
      name="regionCodigo"
      onChange={(e) => this.onChangeRegion(e)}
      >
        {this.state.regiones.map((region) => {
               return <option value={region.codigo} >
                {region.nombre}
              </option>
        })}
        </Select>
</div>



<div id="select">
      <div className="mb-2 block">
        <Label
          htmlFor="ciudad"
          value="Ciudad"
        />
      </div>
      <Select
      id="ciudad"
      name="ciudadCodigo"
      disabled={this.state.showCiudad}
      onChange={(e) => this.onChangeCiudad(e)}
      >
        {this.state.ciudades.map((ciudad) => {
               return <option value={ciudad.codigo} >
                {ciudad.nombre}
              </option>
        })}
        </Select>
</div>

<div id="select">
      <div className="mb-2 block">
        <Label
          htmlFor="comuna"
          value="Comuna"
        />
      </div>
      <Select
      id="comuna"
      name="comunaCodigo"
      disabled={this.state.showComuna}
      onChange={(e) => this.onChangeComuna(e)}
      >
        {this.state.comunas.map((comuna) => {
               return <option value={comuna.codigo} >
                {comuna.nombre}
              </option>
        })}
        </Select>
</div>

<div>
    <div className="mb-2 block">
      <Label
        htmlFor="date"
        value="Fecha Nacimiento"
      />
    </div>
    <TextInput
      id="fechaNacimiento"
      type="date"
      sizing="md"
      value={this.state.fechaNacimiento} 
      name="fechaNacimiento"
      onChange={(e) => this.handleChange(e)}
    />
  </div>

  <div>
    <div className="mb-2 block">
      <Label
        htmlFor="base"
        value="Direccion"
      />
    </div>
    <TextInput
      id="direccion"
      type="text"
      sizing="md"
      value={this.state.direccion} 
      name="direccion"
      onChange={(e) => this.handleChange(e)}
    />
  </div>

  <div>
    <div className="mb-2 block">
      <Label
        htmlFor="base"
        value="Telefono"
      />
    </div>
    <TextInput
      id="telefono"
      type="text"
      sizing="md"
      value={this.state.telefono} 
      name="telefono"
      onChange={(e) => this.handleChange(e)}
    />
  </div>

  <div id="textarea">
  <div className="mb-2 block">
    <Label
      htmlFor="comment"
      value="Observaciones"
    />
  </div>
  <Textarea
    id="observaciones"
    rows={4}
    value={this.state.observaciones} 
    name="observaciones"
    onChange={(e) => this.handleChange(e)}
  />
</div>
  <Button type="submit" onClick={(e) => this.CrearPersona(e)}>
    Submit
  </Button>
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


</form>
</div>

)
}}
  


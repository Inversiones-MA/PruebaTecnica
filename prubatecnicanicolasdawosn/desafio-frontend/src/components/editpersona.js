import React, { Component  } from "react";
import { Label, TextInput, Radio, Button, Textarea, Select, Alert } from "flowbite-react";

export default class editpersona extends Component {
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
        debugger
        let { id } = this.props.val1;
        debugger
    
        this.setState({
            personaId: id
        });
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

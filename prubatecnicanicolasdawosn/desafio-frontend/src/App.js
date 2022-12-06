import React from "react";
import Home from "./components/home";
import NavBar from "../src/components/navbar";
import Cuidadanos from "./components/cuidadanos";
import { Route, Routes } from "react-router-dom";
import Createpersona from "./components/createpersona";
import Editpersona from "./components/editpersona";

export default function App(){
  return (
    <div>
      <div>
      <NavBar/>
      </div>
      <div className="bg-white py-24 sm:py-32 lg:py-40">
      <Routes>
          <Route path="/" element={<Home/>} />
          <Route path="/cuidadanos" element={<Cuidadanos/>} />
          <Route path="/createpersona" element={<Createpersona/>} />
          <Route path="/editpersona" element={<Editpersona/>} />
        </Routes>
      </div>
    </div>
  )
}
  


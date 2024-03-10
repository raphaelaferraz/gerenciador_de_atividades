import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './paginas/home/Home';
import Cadastrar from './paginas/cadastrar/Cadastrar';
import Editar from './paginas/editar/Editar';

function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/cadastrar' element={<Cadastrar/>} />
        <Route path='/editar' element={<Editar/>} />
      </Routes>
    </BrowserRouter>
  )
}

export default AppRoutes;
import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './paginas/home/Home';
import Cadastrar from './paginas/cadastrar/Cadastrar';

function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/cadastrar' element={<Cadastrar/>} />
      </Routes>
    </BrowserRouter>
  )
}

export default AppRoutes;
import { useState } from 'react'
import './App.css'
import Atividade from './componentes/atividade/atividade'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
     <Atividade nomeAtividade={"Teste"} descricao={"Esta é uma atividade de teste"}/>
    </>
  )
}

export default App

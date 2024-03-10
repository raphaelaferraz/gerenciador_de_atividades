import React, { useState, useEffect } from 'react';
import Atividade from '../../componentes/atividade/atividade';

export default function Home() {

  const [atividade, setAtividade] = useState([]);

  useEffect(() => {
    const getAtividades = async () => {
      const atividadesDoServidor = await fetchAtividades();
      setAtividade(atividadesDoServidor);
    }
    getAtividades();
  }, []);

  const fetchAtividades = async () => {
    const res = await fetch('http://localhost:5125/atividade');
    const data = await res.json();
    console.log(data);
    return data;
  }

  const defineStatus = (status) => {
    if (status === true) {
      return 'Concluída';
    } else if (status === false) {
      return 'Não concluída';
    } 
  }


  return (
    <div>
      <h1>Gerenciador de Atividades</h1>
      {atividade.map((atividade) => (
        <Atividade key={atividade.id} status={defineStatus(atividade.concluida)} nomeAtividade={atividade.nome} descricao={atividade.descricao}/>
      ))}
    </div>
  )
}
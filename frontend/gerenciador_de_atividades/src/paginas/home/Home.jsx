import React, { useState, useEffect } from 'react';
import Atividade from '../../componentes/atividade/atividade';
import styled from './Home.module.css';
import { Link } from 'react-router-dom';

export default function Home() {
  // URL da API
  const apiUrl = import.meta.env.VITE_APP_API_URL;

  // Estado para controlar as atividades
  const [atividade, setAtividade] = useState([]);


  // Função para buscar as atividades do servidor
  useEffect(() => {
    const getAtividades = async () => {
      const atividadesDoServidor = await fetchAtividades();
      setAtividade(atividadesDoServidor);
    }
    getAtividades();
  }, []);

  const fetchAtividades = async () => {
    const res = await fetch(`${apiUrl}`);
    const data = await res.json();
    console.log(data);
    return data;
  }

  // Função para definir o status da atividade
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
      <div className={styled.botao}>
        <Link 
          to="/cadastrar"
          className={styled.link}
          >Cadastrar Atividade</Link>
      </div>

      <div className={styled.atividades}>
        {atividade.map((atividade) => (
          <Atividade id={atividade.id} key={atividade.id} status={defineStatus(atividade.concluida)} nomeAtividade={atividade.nome} descricao={atividade.descricao}/>
        ))}
      </div>
    </div>
  )
}
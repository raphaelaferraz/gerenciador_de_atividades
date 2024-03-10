import styles from './formulario.module.css';
import { useState } from 'react';

// Componente que renderiza o formulário para cadastrar atividades
export default function Formulario() {

  // Estado para controlar o formulário
  const [form, setForm] = useState({
    nome: '',
    descricao: '',
    concluida: false,
  });

  // URL da API
  const apiUrl = import.meta.env.VITE_APP_API_URL;

  // Função para controlar as mudanças no formulário
  const handleChange = (event) => {
    const { name, value, type } = event.target;

    let finalValue = value;
    if (name === 'concluida') {
        finalValue = value === 'true';
    }

    setForm(prevForm => ({
      ...prevForm,
      [name]: finalValue,
    }));
  };

  // Função para enviar os dados do formulário para a API
  const enviaDados = async (event) => {
    event.preventDefault();

    const res = await fetch(`${apiUrl}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(form),
    });

    if (res.ok) {
      const data = await res.json();
      console.log(data);
      return data;
    } else {
      console.error('Falha ao enviar os dados', await res.text());
    }
  };

  return (
    <div className={styles.container}>
      <form className={styles.formulario} onSubmit={enviaDados}>
        <label htmlFor="nome">Nome da atividade:</label>
        <input
          type="text"
          name="nome"
          value={form.nome}
          onChange={handleChange}
        />

        <label htmlFor="descricao">Descrição da atividade:</label>
        <input
          type="text"
          name="descricao"
          value={form.descricao}
          onChange={handleChange}
        />

        <label htmlFor="concluida">Status da atividade:</label>
        <select
          name="concluida"
          value={form.concluida}
          onChange={handleChange}
        >
          <option value="true">Concluída</option>
          <option value="false">Não concluída</option>
        </select>

        <button type="submit">Cadastrar atividade</button>
      </form>
    </div>
  );
}

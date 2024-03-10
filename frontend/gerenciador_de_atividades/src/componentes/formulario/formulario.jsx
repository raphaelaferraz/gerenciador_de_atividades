import styles from './formulario.module.css';

export default function Formulario() {
  return (
    <div className={styles.container}>
    <form className={styles.formulario}>
      <label htmlFor="nome">Nome da atividade:</label>
      <input type="text" name="nome" />
      <label htmlFor="descricao">Descrição da atividade:</label>
      <input type="text" name="descricao" />
      <label htmlFor="status">Status da atividade:</label>
      <select name="status">
        <option value="true">Concluída</option>
        <option value="false">Não concluída</option>
      </select>
      <button type="submit">Cadastrar atividade</button>
    </form>
    </div>
  )
}
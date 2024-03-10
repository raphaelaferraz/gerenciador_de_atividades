import styles from './formulario.module.css';

export default function Formulario() {
  return (
    <form className={styles.formulario}>
      <label for="nome">Nome da atividade:</label>
      <input type="text" name="nome" />
      <label for="descricao">Descrição da atividade:</label>
      <input type="text" name="descricao" />
      <label for="status">Status da atividade:</label>
      <select name="status">
        <option value="true">Concluída</option>
        <option value="false">Não concluída</option>
      </select>
    </form>
  )
}
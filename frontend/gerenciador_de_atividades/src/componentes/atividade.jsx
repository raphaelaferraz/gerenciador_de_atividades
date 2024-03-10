import styles from './atividade.module.css'
import { AiFillDelete, AiFillEdit } from "react-icons/ai";


export default function Atividade({nomeAtividade, descricao}) {
  return (
    <>
      <div className={styles.atividade}>
        <h1 className={styles.titulo}>{nomeAtividade}</h1>
        <p className={styles.descricao}>{descricao}</p>
        <div className={styles.botoes}>
          <button className={styles.botaoEditar}>
            <AiFillEdit />Editar atividade
          </button>
          <button className={styles.botaoExcluir}>
            <AiFillDelete /> Excluir atividade
          </button>
        </div>
      </div>
    </>
  )
}
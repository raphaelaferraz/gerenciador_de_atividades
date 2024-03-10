import styles from './atividade.module.css'
import { AiFillDelete } from "react-icons/ai";


export default function Atividade({nomeAtividade, descricao}) {
  return (
    <>
      <div className={styles.atividade}>
        <h1 className={styles.titulo}>{nomeAtividade}</h1>
        <p>{descricao}</p>
        <div className={styles.botoes}>
          <button className={styles.botaoExcluir}>
            <AiFillDelete /> Excluir atividade
          </button>
        </div>
      </div>

    </>
  )
}
import styles from './atividade.module.css'
import { AiFillDelete, AiFillEdit } from "react-icons/ai";
import { useState } from 'react';

export default function Atividade({nomeAtividade, descricao, status}) {
  const [isPopupOpen, setIsPopupOpen] = useState(false);
  const togglePopup = () => {
    setIsPopupOpen(!isPopupOpen);
};
  return (
    <>
      <div className={styles.atividade}>
        <h1 className={styles.titulo}>{nomeAtividade}</h1>
        <p className={styles.descricao}>{descricao}</p>
        <p className={styles.status}>Status da atividade: {status}</p>
        <div className={styles.botoes}>
          <button className={styles.botaoEditar}>
            <AiFillEdit />Editar atividade
          </button>
          <button className={styles.botaoExcluir} onClick={togglePopup}>
            <AiFillDelete /> Excluir atividade
          </button>
          {isPopupOpen && (
                <div className={styles.popup}>
                    <p>Deseja deletar a atividade {nomeAtividade}?</p>
                    <div className={styles.popupButtons}>
                      <button>Sim</button>
                      <button>Não</button>
                    </div>
                    <button onClick={togglePopup}>Fechar Pop-up</button>
                </div>
            )}
        </div>
      </div>
    </>
  )
}
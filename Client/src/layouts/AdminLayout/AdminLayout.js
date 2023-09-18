import Link from "next/link";
import styles from "./AdminLayout.module.scss";


export  function AdminLayout(props) {
    const { children } = props;
  return (
    <div className={styles.BasicLayout}>

        <Link href='/'>Inicio</Link>
        <Link href='/AdminUsuariosLayout'>Usuarios</Link>
        <Link href='/Asignaturas'>Asignaturas</Link>
        <Link href='/Calificaciones'>Calificaciones</Link>
        <Link href='/Ranking'>Ranking</Link>
        <Link href='/Reportes'>Reportes</Link>
        {children}

        
    </div>
  )
}
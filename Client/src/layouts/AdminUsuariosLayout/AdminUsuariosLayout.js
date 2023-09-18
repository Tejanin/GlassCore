import { TablaUsuarios } from '@/components/Layout/TablaUsuarios/TablaUsuarios';
import { CrearUsuario } from '@/components/Layout/CrearUsuario/CrearUsuario';
import { TopLogo } from '@/components/Layout/TopLogo/TopLogo';
import { useState } from 'react';
import { Dropdown, Button, Search, Table, Input} from "semantic-ui-react";
import styles from './AdminUsuariosLayout.module.scss';
export  function AdminUsuarios() {
  const Filtros = [
    { key: '1', value: '1', text:'Profesor'},
    { key: '2', value: '2', text:'Estudiantes'},
    { key: '3', value: '3', text:'Administrador'},
  ]
  const [modalOpen, setModalOpen] = useState(false);
  const handleOpenModal = () => {
    setModalOpen(true);
  };

  const handleCloseModal = () => {
    setModalOpen(false);
  };

  return (
    <div className={styles.adminusuarios}>
      <TopLogo/>
  <div className={styles.header}>
    <h1>Usuarios</h1>
  </div>
  <div className={styles.filterRow}>
    <div className={styles.leftSection}>
      <div className={styles.filterContainer}>
        <span>Filtrar por:</span>
        <div className={styles.selectContainer}>
          <Dropdown
            placeholder="Filtrar Usuarios"
            fluid
            selection
            options={Filtros}
            className={styles.filterSelect}
          />
        </div>
      </div>
      <div className={styles.searchContainer}>
        <Search className={styles.searchInput} />
      </div>
    </div>
    <div className={styles.rightSection}>
      <Button content='Agregar Estudiante' primary className={styles.addButton} onClick={handleOpenModal} />
      <CrearUsuario isOpen={modalOpen} onClose={handleCloseModal} />
    </div>
  </div>
  <div className={styles.tableContainer}>
    <TablaUsuarios />
  </div>
</div>
  );
}

import { Table, Button, Icon } from "semantic-ui-react";
import styles from './TablaUsuarios.module.scss';
import React, { useState } from 'react';

let data = [
    { Name: 'Juan Pérez', ID: '12345', Email: 'juan@example.com', type: "Estudiante", Registerdate: '2023-01-15' },
    { Name: 'María López', ID: '67890', Email: 'maria@example.com', type: "Estudiante", Registerdate: '2023-02-20' },
    // ... otros datos ...
  ];

  
export function TablaUsuarios() {
    
    const [confirmOpen, setConfirmOpen] = useState(false);
    const [selectedItemId, setSelectedItemId] = useState(null);

  const handleEdit = (id) => {
    // Lógica para editar el elemento con el ID proporcionado
    // Aquí puedes abrir un modal o realizar la acción que necesites.
  };

  const handleDelete = (id) => {
    setSelectedItemId(id);
    setConfirmOpen(true);
  };

  const handleConfirmDelete = () => {
    // Lógica para eliminar el elemento con el ID seleccionado
    // Aquí debes eliminar el elemento de tu lista de datos.
    // Por ejemplo, puedes usar filter para crear una nueva lista sin el elemento.
    data = data.filter((item) => item.id !== selectedItemId);
    setConfirmOpen(false);
  };

  const handleCancelDelete = () => {
    setConfirmOpen(false);
  };
  return (
    <div className={styles.customTable}>
         <Table>
        <Table.Header >
          <Table.Row>
            <Table.HeaderCell ></Table.HeaderCell>
            <Table.HeaderCell className={styles.headerCell}>Nombre</Table.HeaderCell>
            <Table.HeaderCell className={styles.headerCell}>Matrícula</Table.HeaderCell>
            <Table.HeaderCell>Email</Table.HeaderCell>
            <Table.HeaderCell>Fecha de Creación</Table.HeaderCell>
            <Table.HeaderCell>Acciones</Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {data.map((item, index) => (
            <Table.Row key={index}>
              <Table.Cell style={{ width: '150px' }} className={styles.centeredCell}>{/*item.Photo*/}<Icon name="id card" /></Table.Cell>
              <Table.Cell style={{ width: '200px' }} className={styles.centeredCell}>{item.Name}</Table.Cell>
              <Table.Cell style={{ width: '200px' }} className={styles.centeredCell}>{item.ID}</Table.Cell>
              <Table.Cell style={{ width: '200px' }} className={styles.centeredCell}>{item.Email}</Table.Cell>
              <Table.Cell style={{ width: '200px' }} className={styles.centeredCell}>{item.Registerdate}</Table.Cell>
              <Table.Cell style={{ width: '50px' }} className={styles.centeredCell}>
              <Button icon color="" onClick={() => handleEdit(item.id)} className={styles.iconButton}>
                  <Icon name="pencil alternate" />
                </Button>
                <Button icon color="" onClick={() => handleDelete(item.id)} className={styles.iconButton}>
                  <Icon name="trash alternate" />
                </Button>
              </Table.Cell> 
        </Table.Row>
          ))}
        </Table.Body>
      </Table>
      

    </div>
  )
}

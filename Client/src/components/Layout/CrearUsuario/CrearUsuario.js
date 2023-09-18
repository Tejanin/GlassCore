import { Modal, Form, Button, Checkbox, Segment} from "semantic-ui-react";
import styles from './CrearUsuario.module.scss'

export  function CrearUsuario({ isOpen, onClose }) {
  
    return (
        <div className={styles.crearusuariolayout}>
          <Modal open={isOpen} onClose={onClose} className={styles.modal}>
            <Modal.Header>Activar usuario</Modal.Header>
            <Modal.Content>
              <Form>
                <Form.Field className={styles.checkboxGroup}>
                  <label>Tipo de usuario</label>
                  <div className={styles.checkboxContainer}>
                    <div className={styles.checkboxItem}>
                    
                      <Checkbox toggle label="Profesor" />
                    
                    </div>
                    <div className={styles.checkboxItem}>
                     
                      <Checkbox toggle label="Alumno" />
                    
                    </div>
                  </div>
                </Form.Field>
                <div className={styles.nameRow}>
                  <div className={styles.nameField}>
                    <Form.Field>
                      <label>Nombre</label>
                      <input type="text" placeholder="Nombre" />
                    </Form.Field>
                  </div>
                  <div className={styles.nameField}>
                    <Form.Field>
                      <label>Apellido Paterno</label>
                      <input type="text" placeholder="Apellido Paterno" />
                    </Form.Field>
                  </div>
                  <div className={styles.nameField}>
                    <Form.Field>
                      <label>Apellido Materno</label>
                      <input type="text" placeholder="Apellido Materno" />
                    </Form.Field>
                  </div>
                </div>
                <div className={styles.emailPhoneRow}>
                  <div className={styles.emailField}>
                    <Form.Field>
                      <label>Correo</label>
                      <input type="email" placeholder="Correo" />
                    </Form.Field>
                  </div>
                  <div className={styles.phoneField}>
                    <Form.Field>
                      <label>Teléfono</label>
                      <input type="tel" placeholder="Teléfono" />
                    </Form.Field>
                  </div>
                </div>
              </Form>
            </Modal.Content>
            <Modal.Actions className={styles.actionsContainer}>
              <div className={styles.buttonContainer}>
                <Button negative onClick={onClose} className={styles.cancelButton}>
                  Cancelar
                </Button>
                <Button positive className={styles.saveButton}>
                  Guardar
                </Button>
              </div>
            </Modal.Actions>
          </Modal>
        </div>
      );
}

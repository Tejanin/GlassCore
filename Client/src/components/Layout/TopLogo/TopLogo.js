
import React from 'react';
import styles from './TopLogo.module.scss'; // Importa tus estilos SCSS
import Image from 'next/image'
import  Logo  from './';
export function TopLogo() {

    return (
        <div className={styles.presentationBar}>
      <div className={styles.content}>
        <div className={styles.title}>Glasscore</div>
        <Image src="" alt="Logo Glasscore" className={styles.logo} />
      </div>
    </div>
    )
  }
  
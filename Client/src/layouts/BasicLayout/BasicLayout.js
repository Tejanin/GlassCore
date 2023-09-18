import styles from "./BasicLayout.module.scss";

import { Container} from "semantic-ui-react";
import classNames from "classnames";



export  function BasicLayout(props) {
    const { children } = props;
  return (
    <div className={styles.BasicLayout}>

        
        {children}

        
    </div>
  )
}

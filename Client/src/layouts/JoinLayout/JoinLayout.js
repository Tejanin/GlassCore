import Link from "next/link"
import {Icon, Image} from "semantic-ui-react"
import styles from "./JoinLayout.module.scss"

export  function JoinLayout(props) {
    const { children } = props;
  return (
    <div className={styles.container}>
        <div className={styles.topBar}>  
          <Link href="/">
            Logo
          </Link>
        </div>
    </div>
  )
}

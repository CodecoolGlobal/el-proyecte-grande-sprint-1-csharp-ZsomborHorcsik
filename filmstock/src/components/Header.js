import React from 'react'
import Navmenu from './Navmenu'

const Header = ({setFilter}) => {
  return (
    <div>
      <Navmenu filter={setFilter}/>
    </div>
  )
}

export default Header
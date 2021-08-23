import React, { useState } from 'react'
import Header from '../Header/Header'
import Menu from '../Menu/Menu'

function Navigation() {
    const [openMenu, setOpenMenu] = useState(false)

    return (
        <>
            <Header setOpenMenu={setOpenMenu}/>
            <Menu setOpenMenu={setOpenMenu} openMenu={openMenu}/>
        </>
    )
}

export default Navigation

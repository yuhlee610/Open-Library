import React from 'react'
import './Header.css'
import { useHistory } from 'react-router'

function Header({setOpenMenu}) {
    const history = useHistory()
    const moveToHomePage = () => {
        history.push('/')
    }
    return (
        <div className='container header'>
            <p onClick={moveToHomePage}>📖 OPEN LIBRARY 📰</p>
            <button onClick={() => setOpenMenu(true)}><i className="fas fa-bars"></i></button>
        </div>
    )
}

export default Header

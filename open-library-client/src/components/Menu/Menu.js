import React from 'react'
import { useHistory } from 'react-router'
import { Divider } from 'antd'
import './Menu.css'
import Overlay from '../Overlay/Overlay'
import { connect } from 'react-redux'
import AuthItem from '../AuthItem/AuthItem'


function Menu({ setOpenMenu, openMenu, categories }) {
    const history = useHistory()

    const onSelectCategory = (event) => {
        history.push(`/${event.target.innerText}`)
        setOpenMenu(false)
    }

    return (
        <>
            <div className={`menu ${openMenu && 'active'}`}>
                <i className="fas fa-times" onClick={() => setOpenMenu(false)}></i>
                <Divider />
                {
                    categories.length !== 0 &&
                    categories.map(ele =>
                        <p
                            onClick={(event) => onSelectCategory(event)}
                            key={ele.id}
                        >
                            {ele.name}</p>)
                }
                <AuthItem setOpenMenu={setOpenMenu}/>
            </div>
            <Overlay enable={openMenu} setOpenMenu={setOpenMenu} />
        </>
    )
}

const mapStateToProps = state => {
    return {
        categories: state.book.categories
    }
}

export default connect(mapStateToProps, null)(Menu)

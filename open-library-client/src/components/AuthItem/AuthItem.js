import React from 'react'
import { Button } from 'antd'
import { Divider } from 'antd'
import { useHistory } from 'react-router'
import * as actions from '../../store/actions/index'
import { connect } from 'react-redux'

function AuthItem({ auth, onLogout, setOpenMenu }) {
    const history = useHistory()
    const goLogin = () => {
        history.push('/login')
        setOpenMenu(false)
    }

    const goRegister = () => {
        history.push('/register')
        setOpenMenu(false)
    }

    const goLogout = () => {
        onLogout()
        setOpenMenu(false)
    }

    const style = {
        background: 'black',
        color: 'white'
    }

    return (
        <>
            {
                auth ? (
                    <>
                        <Divider />
                        <Button
                            block
                            onClick={goLogout}
                            type='dashed'
                            size='large'
                            style={style}
                        >
                            LOGOUT</Button>
                    </>
                ) : (
                    <>
                        <Divider />
                        <Button
                            block
                            style={style}
                            size='large'
                            onClick={goLogin}
                        >
                            LOGIN
                        </Button>

                        <Divider />
                        <Button
                            block
                            style={style}
                            size='large'
                            onClick={goRegister}
                        >
                            REGISTER
                        </Button>
                    </>
                )
            }
        </>
    )
}

const mapDispatchToProps = dispatch => {
    return {
        onLogout: () => dispatch(actions.logout())
    }
}

const mapStateToProps = state => {
    return {
        auth: state.auth.token !== null
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(AuthItem)

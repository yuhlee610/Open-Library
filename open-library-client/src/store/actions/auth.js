import * as actionTypes from './actionTypes'
import axios from '../../axios'
import { fetchFail } from './book'

export const login = (formData) => {
    return async dispatch => {
        dispatch(startLoading())
        try {
            const response = await axios.post('/Account/Login', formData)
            const expire = new Date(response.data.expiresIn)
            localStorage.setItem('expire', expire)
            localStorage.setItem('token', response.data.token)
            localStorage.setItem('idUser', response.data.idUser)
            dispatch(checkAuthTimeOut(new Date(response.data.expiresIn)))
            dispatch(loginSuccess(response.data.token, response.data.idUser))
        }
        catch {
            dispatch(fetchFail('Login failed!! Please try again!'))
        }
        dispatch(endLoading())
    }
}

export const register = formData => {
    return async dispatch => {
        dispatch(startLoading())
        try {
            await axios.post('/Account/Register', formData)
            const {email, password} = formData
            dispatch(login({email, password}))
        }
        catch {
            dispatch(endLoading())
            dispatch(fetchFail('Register failed!! Please try again!'))
        }
    }
}


export const authCheckState = () => {
    return dispatch => {
        const token = localStorage.getItem('token')
        if (!token) {
            dispatch(logout())
        }
        else {
            const expire = new Date(localStorage.getItem('expire'))
            if(new Date(expire) > new Date()) {
                const idUser = localStorage.getItem('idUser')
                dispatch(loginSuccess(token, idUser))
                dispatch(checkAuthTimeOut(expire))
            }
            else {
                dispatch(logout())
            }
        }
    }
}

const checkAuthTimeOut = (expire) => {
    return dispatch => {
        setTimeout(() => {
            dispatch(logout())
        }, expire.getTime() - new Date().getTime());
    }
}

export const logout = () => {
    localStorage.removeItem('expire')
    localStorage.removeItem('token')
    localStorage.removeItem('idUser')
    return {
        type: actionTypes.LOGOUT
    }
}

const loginSuccess = (token, idUser) => {
    return {
        type: actionTypes.LOGIN_SUCCESS,
        token: token,
        idUser: idUser
    }
}

export const startLoading = () => {
    return {
        type: actionTypes.START_LOADING
    }
}

export const endLoading = () => {
    return {
        type: actionTypes.END_LOADING
    }
}
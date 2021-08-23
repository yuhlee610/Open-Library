import * as actionTypes from '../actions/actionTypes'

const initialState = {
    token: null,
    idUser: null,
    loading: false
}

const authReducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.START_LOADING:
            return {
                ...state,
                loading: true
            }

        case actionTypes.END_LOADING:
            return {
                ...state,
                loading: false
            }

        case actionTypes.LOGOUT:
            return {
                ...state,
                token: null,
                idUser: null
            }

        case actionTypes.LOGIN_SUCCESS:
            return {
                ...state,
                token: action.token,
                idUser: action.idUser
            }
    
        default:
            return state
    }
}

export default authReducer
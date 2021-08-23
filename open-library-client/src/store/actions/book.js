import * as actionTypes from './actionTypes'
import axios from '../../axios'

export const fetchCategories = () => {
    return async dispatch => {
        try {
            const data = await axios.get('/Category')
            dispatch(fetchCategoriesSuccess(data.data))
        }
        catch {
            dispatch(fetchFail())
        }
    }
}

const fetchCategoriesSuccess = (data) => {
    return {
        type: actionTypes.FETCH_CATEGORIES_SUCCESS,
        data: data
    }
}


export const fetchFail = (message = 'Oops! Something wrong! Please try again.') => {
    return {
        type: actionTypes.FETCH_FAIL,
        message: message
    }
}

export const resetError = () => {
    return {
        type: actionTypes.RESET_ERROR
    }
}
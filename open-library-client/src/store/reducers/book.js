import * as actionTypes from '../actions/actionTypes'

const initialState = {
    categories: [],
    loading: false,
    errorFlag: false,
    errorMessage: ''
}

const bookReducer = (state = initialState, action) => {
    switch(action.type) {
        case actionTypes.FETCH_CATEGORIES_SUCCESS:
            let listCate = []
            for (const key in action.data) {
                listCate.push({
                    id: key,
                    ...action.data[key]
                })
            }
            return {
                ...state,
                categories: listCate
            }
        
        case actionTypes.FETCH_FAIL:
            return {
                ...state,
                errorFlag: true,
                errorMessage: action.message
            }

        case actionTypes.RESET_ERROR:
            return {
                ...state,
                errorFlag: false,
                errorMessage: ''
            }

        default:
            return state
    }
}

export default bookReducer
import React from 'react'
import { Button } from 'antd'
import { connect } from 'react-redux'
import { useHistory } from 'react-router'
import axios from '../../axios'
import * as actions from '../../store/actions/index'
import { openNotification } from '../Notification/Notification'
import { Skeleton } from 'antd'

function BookDetail({
    id,
    picture,
    name,
    author,
    year,
    description,
    auth,
    token,
    idUser,
    onFetchFail}) {

    const history = useHistory()

    const onBorrow = async () => {
        if (!auth) {
            history.push('/login')
            return
        }
        try {
            await axios.put('/Book/BorrowBook', {
                idUser: idUser,
                idBook: id
            }, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            })
            openNotification('Success', 'Your request has been approved')
        }
        catch {
            onFetchFail('Something went wrong!! You already might had borrowed this book. Please check again!!!')
        }
    }

    return (
        <>
            <div className="bookThumbnail">
                <img src={`data:image/jpeg;base64,${picture}`} alt="book" />
                <Button className='customButton' onClick={onBorrow} style={{ background: 'black', color: 'white' }}>
                    BORROW
                </Button>
            </div>
            <div className="bookInfo">
                <h3>{name}</h3>
                <div>{author}</div>
                <div>{year}</div>
                <p>{description}</p>
            </div>
        </>
    )
}

const mapStateToProps = state => {
    return {
        auth: state.auth.token !== null,
        token: state.auth.token,
        idUser: state.auth.idUser
    }
}

const mapDispatchToProps = dispatch => {
    return {
        onFetchFail: (message) => dispatch(actions.fetchFail(message))
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(BookDetail)

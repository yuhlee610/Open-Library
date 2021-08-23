import React from 'react'
import { Card } from 'antd'
import { useHistory } from 'react-router'

const { Meta } = Card

function BookCard({ id, name, author, picture, loading }) {
    const history = useHistory()

    const onClickHandle = () => {
        history.push(`/book/${id}`)
    }

    return (
        <Card 
            onClick={onClickHandle}
            loading={loading}
            hoverable
            cover={
                !loading ?
                    <img style={{ maxHeight: 280 }} alt="bookPicture" src={`data:image/jpeg;base64,${picture}`} /> :
                    <img style={{maxHeight: 280}} alt="bookPicture" src={'/cover-not-available-fpo.png'}/>}
        >
            <Meta title={name} description={author} />
        </Card>
    )
}

export default BookCard

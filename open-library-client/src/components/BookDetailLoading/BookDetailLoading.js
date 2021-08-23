import React from 'react'
import { Skeleton } from 'antd'
import { Button } from 'antd'

function BookDetailLoading() {
    return (
        <>
            <div className="bookThumbnail">
                <Skeleton.Image style={{ width: '200px', height: '200px' }} />
                <Button className='customButton' style={{ background: 'black', color: 'white' }}>
                    BORROW
                </Button>
            </div>
            <Skeleton />
        </>
    )
}

export default BookDetailLoading

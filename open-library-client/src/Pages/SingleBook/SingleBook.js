import React from 'react'
import './SingleBook.css'
import axios from '../../axios'
import { useState } from 'react'
import { connect } from 'react-redux'
import * as actions from '../../store/actions/index'
import { useEffect } from 'react'
import BookDetail from '../../components/BookDetail/BookDetail'
import BookDetailLoading from '../../components/BookDetailLoading/BookDetailLoading'

function SingleBook({ match, onFetchFail }) {
    const [content, setContent] = useState(null)
    // loading = true
    const fetchBook = async () => {
        const id = match.params.id
        try {
            const response = await axios.get(`/Book/${id}`)
            setContent(response.data)
        }
        catch {
            onFetchFail()
        }
    }

    useEffect(() => {
        fetchBook()
    }, [match])


    return (
        <div className='container singleBook'>
            <div className="whiteLayout">
                {
                    content !== null
                        ?
                        <BookDetail
                            id={content.id}
                            picture={content.picture}
                            author={content.author}
                            name={content.name}
                            year={content.year}
                            description={content.description}
                        />
                        :
                        <BookDetailLoading />
                }
            </div>
        </div>
    )
}

const mapDispatchToProps = dispatch => {
    return {
        onFetchFail: () => dispatch(actions.fetchFail())
    }
}


export default connect(null, mapDispatchToProps)(SingleBook)

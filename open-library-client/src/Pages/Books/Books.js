import React, { useState } from 'react'
import './Books.css'
import BookCard from '../../components/BookCard/BookCard'
import { Row, Col } from 'antd'
import Pagination from '../../components/Pagination/Pagination'
import { useEffect } from 'react'
import axios from '../../axios'
import { connect } from 'react-redux'
import * as actions from '../../store/actions/index'
import Loading from '../../components/Loading/Loading'

let temp = 'All Books'

function Books({ match, categories, onFetchFail, onStartLoading, onEndLoading, loading }) {
    const [currentPage, setCurrentPage] = useState(1)
    const [content, setContent] = useState(null)
    const [totalPage, setTotalPage] = useState(0)
    let heading = 'All Books'

    if (Object.keys(match.params).length !== 0) {
        heading = match.params.category
    }

    if (heading !== temp) {
        temp = heading
        setCurrentPage(1)
    }

    const fetchBooks = async () => {
        let response = null
        onStartLoading()
        try {
            if (heading === 'All Books') {
                response = await axios.get(`/Book?currentPage=${currentPage}`)
            }
            else {
                const cate = categories.filter(ele => ele.name === heading)
                response = await axios.get(`/Book?currentPage=${currentPage}&categoryId=${cate[0].id}`)
            }
            setContent(response.data.books)
            setTotalPage(response.data.totalPage)
        }
        catch {
            onFetchFail()
        }
        onEndLoading()
    }

    useEffect(() => {
        if (categories.length !== 0) {
            fetchBooks()
            window.scroll(0, 0)
        }
    }, [currentPage, match, categories])

    return (
        <div className='container books'>
            <h2 className='heading'>-- {heading} --</h2>
            <Row
                gutter={[{ xs: 12, sm: 16, md: 24, lg: 32 }, { xs: 12, sm: 16, md: 24, lg: 32 }]}
                wrap>
                {
                    content !== null && content.map(({ id, name, picture, author }) =>
                        <Col key={id} className="gutter-row" xl={6} md={8} sm={12} xs={12}>
                            <BookCard
                                id={id}
                                name={name}
                                author={author}
                                picture={picture}
                            />
                        </Col>
                    )
                }
            </Row>
            {loading && <Loading/>}
            <Pagination currentPage={currentPage} setCurrentPage={setCurrentPage} totalPage={totalPage} />
        </div>
    )
}

const mapStateToProps = state => {
    return {
        categories: state.book.categories,
        loading: state.auth.loading
    }
}

const mapDispatchToProps = dispatch => {
    return {
        onFetchFail: () => dispatch(actions.fetchFail()),
        onStartLoading: () => dispatch(actions.startLoading()),
        onEndLoading: () => dispatch(actions.endLoading())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Books)

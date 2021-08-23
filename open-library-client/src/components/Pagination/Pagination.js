import React from 'react'
import { Pagination } from 'antd';

function Paging({ currentPage, totalPage, setCurrentPage }) {

    function onShowSizeChange(current, pageSize) {
        setCurrentPage(current)
    }

    return (
        <Pagination
            style={{ padding: '40px', textAlign: 'center' }}
            current={currentPage}
            showSizeChanger={false}
            total={totalPage * 10}
            onChange={onShowSizeChange} />
    )
}

export default Paging

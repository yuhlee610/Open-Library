import React, { useState } from 'react'
import Modal from 'antd/lib/modal/Modal'
import { connect } from 'react-redux'
import { useEffect } from 'react';
import * as actions from '../../store/actions/index'

function ModalCustom({ message, toggle, onResetError }) {
    const [isModalVisible, setIsModalVisible] = useState(false);
    useEffect(() => {
        if(toggle) {
            setIsModalVisible(true)
        }
    },[toggle])

    const closeTrigger = () => {
        onResetError()
    }

    const handleOk = () => {
        setIsModalVisible(false);
    };

    const handleCancel = () => {
        setIsModalVisible(false);
    };

    return (
        <Modal
            title='Notification'
            visible={isModalVisible}
            afterClose={closeTrigger}
            onOk={handleOk} 
            onCancel={handleCancel}
            maskStyle={{
                width: '100%'
            }}
        >
            <p>{message}</p>
        </Modal>
    )
}

const mapStateToProps = state => {
    return {
        toggle: state.book.errorFlag,
        message: state.book.errorMessage
    }
}

const mapDispatchToProps = dispatch => {
    return {
        onResetError: () => dispatch(actions.resetError())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ModalCustom)

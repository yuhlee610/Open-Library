import React from 'react'
import { Form, Input, Button } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';
import './Login.css'
import { connect } from 'react-redux';
import * as actions from '../../store/actions/index'
import { Link, Redirect } from 'react-router-dom';

function Login({onLogin, loading, auth}) {
    const onFinish = (values) => {
        onLogin(values)
    };

    if(auth) {
        return <Redirect to='/'/>
    }

    return (
        <div className='container login'>
            <div className="heading">LOGIN</div>
                <Form
                    className='form'
                    onFinish={onFinish}>
                    <Form.Item
                        name='email'
                        rules={[
                            {
                                require: true,
                                message: 'Please input your email!'
                            }
                        ]}
                    >
                        <Input
                            size='large'
                            prefix={<UserOutlined />}
                            placeholder="Email"
                        />
                    </Form.Item>

                    <Form.Item
                        name='password'
                        rules={[
                            {
                                required: true,
                                message: 'Please input your password!'
                            }
                        ]}
                    >
                        <Input
                            size='large'
                            prefix={<LockOutlined />}
                            type="password"
                            placeholder="Password"
                        />
                    </Form.Item>

                    <Form.Item>
                        <Button type="primary" htmlType="submit" block size='large' loading={loading}>
                            Log in
                        </Button>
                        Or <Link to="/register">register now!</Link>
                    </Form.Item>
                </Form>
        </div>
    )
}

const mapDispatchToProps = dispatch => {
    return {
        onLogin: (formData) => dispatch(actions.login(formData))
    }
}

const mapStateToProps = state => {
    return {
        loading: state.auth.loading,
        auth: state.auth.token !== null
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Login)

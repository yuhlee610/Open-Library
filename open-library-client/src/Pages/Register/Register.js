import { Input, Button, Form } from 'antd';
import React from 'react'
import './Register.css'
import { connect } from 'react-redux';
import * as actions from '../../store/actions/index'
import { Redirect } from 'react-router';

const formItemLayout = {
    labelCol: {
        sm: {
            span: 24,
        },
        md: {
            span: 6,
        },
    },
    wrapperCol: {
        sm: {
            span: 24,
        },
        md: {
            span: 14
        },
        lg: {
            offset: 1,
            span: 12,
        },
        xl: {
            offset: 1,
            span: 10
        }
    },
};

const tailFormItemLayout = {
    wrapperCol: {
        xs: {
            span: 24,
            offset: 0,
        },
        sm: {
            span: 16,
            offset: 0
        },
        md: {
            span: 16,
            offset: 6
        },
        lg: {
            span: 16,
            offset: 7
        }
    },
};

function Register({ loading, auth, onRegister }) {
    const onFinish = (values) => {
        const { email, firstName, lastName, password, phoneNumber } = values
        onRegister({ email, firstName, lastName, password, phoneNumber })
    };

    if(auth) {
        return <Redirect to='/'/>
    }

    return (
        <div className='container register'>
            <div className="heading">REGISTER</div>
            <Form
                onFinish={onFinish}
                {...formItemLayout}
                name='register'
            >
                <Form.Item
                    name='firstName'
                    label='First Name'
                    style={{ color: 'white' }}
                    rules={[
                        {
                            required: true,
                            message: 'Please input your First Name!',
                        }
                    ]}
                >
                    <Input size='large' />
                </Form.Item>

                <Form.Item
                    name='lastName'
                    label='Last Name'
                    rules={[
                        {
                            required: true,
                            message: 'Please input your Last Name!',
                        }
                    ]}
                >
                    <Input size='large' />
                </Form.Item>

                <Form.Item
                    name='email'
                    label='E-mail'
                    rules={[
                        {
                            type: 'email',
                            message: 'The input is not valid E-mail!',
                        },
                        {
                            required: true,
                            message: 'Please input your E-mail!',
                        },
                    ]}
                >
                    <Input size='large' />
                </Form.Item>

                <Form.Item
                    name='phoneNumber'
                    label='Phone Number'
                >
                    <Input size='large' />
                </Form.Item>

                <Form.Item
                    name="password"
                    label="Password"
                    rules={[
                        {
                            required: true,
                            message: 'Please input your password!',
                        },
                        {
                            min: 6,
                            message: 'Password length must be more than 6 characters!'
                        },
                        {
                            max: 15,
                            message: 'Password length must be less than 15 characters!'
                        }
                    ]}
                    hasFeedback
                >
                    <Input.Password size='large' />
                </Form.Item>

                <Form.Item
                    name="confirm"
                    label="Confirm Password"
                    dependencies={['password']}
                    hasFeedback
                    rules={[
                        {
                            required: true,
                            message: 'Please confirm your password!',
                        },
                        ({ getFieldValue }) => ({
                            validator(_, value) {
                                if (!value || getFieldValue('password') === value) {
                                    return Promise.resolve();
                                }

                                return Promise.reject(new Error('The two passwords that you entered do not match!'));
                            },
                        }),
                    ]}
                >
                    <Input.Password size='large' />
                </Form.Item>

                <Form.Item {...tailFormItemLayout}>
                    <Button type="primary" htmlType="submit" size='large' loading={loading}>
                        Register
                    </Button>
                </Form.Item>
            </Form>
        </div>
    )
}

const mapDispatchToProps = dispatch => {
    return {
        onRegister: (formData) => dispatch(actions.register(formData))
    }
}

const mapStateToProps = state => {
    return {
        loading: state.auth.loading,
        auth: state.auth.token !== null
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Register)

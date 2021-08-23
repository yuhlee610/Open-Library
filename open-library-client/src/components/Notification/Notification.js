import { notification } from 'antd';

export const openNotification = (title, message) => {
    notification.open({
        message: title,
        description: message
    });
};

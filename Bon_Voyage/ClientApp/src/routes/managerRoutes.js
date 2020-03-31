import React from 'react';

const Login = React.lazy(() => import("../views/othersViews/LoginPage"));
const ManagerProfileView = React.lazy(() => import("../views/managerViews/ManagerProfileView"));

// https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config
const routes = [
    { path: '/manager/login', name: 'Login', component: Login },
    { path: '/manager/profile', exact: true, name: 'ManagerProfileView', component: ManagerProfileView },
];

export default routes;
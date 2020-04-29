import React from 'react';

const Login = React.lazy(() => import("../views/othersViews/LoginPage"));
const ClientProfileView = React.lazy(() => import("../views/clientViews/ClientProfileView"));

const routes = [
    { path: '/client/login', name: 'Login', component: Login },
    { path: '/client/profile', exact: true, name: 'ClientProfileView', component: ClientProfileView },
];

export default routes;
import React from 'react';
import ClientMessageView from '../views/clientViews/ClientMessageView';

const Login = React.lazy(() => import("../views/othersViews/LoginPage"));
const ClientProfileView = React.lazy(() => import("../views/clientViews/ClientProfileView"));

const routes = [
    { path: '/client/login', name: 'Login', component: Login },
    { path: '/client/profile', exact: true, name: 'ClientProfileView', component: ClientProfileView },
    { path: '/client/message', exact: true, name: 'ClientMessageView', component: ClientMessageView },
];

export default routes;
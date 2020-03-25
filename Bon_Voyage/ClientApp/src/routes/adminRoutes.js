import React from 'react';

const ManagerControl = React.lazy(() => import("../views/adminViews/ManagerControl"));
const Login = React.lazy(() => import("../views/othersViews/LoginPage"));

// https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config
const routes = [
  { path: '/admin/manager/control', exact: true, name: 'ManagerControl', component: ManagerControl },
  { path: '/admin/login', name: 'Login', component: Login },  
];

export default routes;
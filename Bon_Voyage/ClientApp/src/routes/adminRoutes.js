import React from 'react';
import AirportControl from '../views/adminViews/AirportControl';

const ManagerControl = React.lazy(() => import("../views/adminViews/ManagerControl"));
const Login = React.lazy(() => import("../views/othersViews/LoginPage"));

// https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config
const routes = [
  { path: '/admin/manager/control', exact: true, name: 'ManagerControl', component: ManagerControl },
  { path: '/admin/login', name: 'Login', component: Login },  
  { path: '/admin/airport/control', name: 'AirportControl', component: AirportControl },  
];

export default routes;
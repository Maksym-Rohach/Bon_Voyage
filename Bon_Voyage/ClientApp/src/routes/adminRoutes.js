import React from 'react';

const ManagerControl = React.lazy(() => import("../views/adminViews/ManagerControl"));
const Login = React.lazy(() => import("../views/othersViews/LoginPage"));
const HotelControl = React.lazy(() => import("../views/adminViews/HotelControl"));

// https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config
const routes = [
  { path: '/admin/manager/control', exact: true, name: 'ManagerControl', component: ManagerControl },
  { path: '/admin/login', name: 'Login', component: Login },  
  { path: '/admin/hotel/control', exact: true, name: 'HotelControl',component: HotelControl }
];

export default routes;
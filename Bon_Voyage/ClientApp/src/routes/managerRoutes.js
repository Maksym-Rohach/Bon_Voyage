import React from 'react';
import BoughtTickets from '../views/managerViews/BoughtTickets';

import HotDealTickets from '../views/managerViews/HotDealTickets';

const Login = React.lazy(() => import("../views/othersViews/LoginPage"));
const ManagerProfileView = React.lazy(() => import("../views/managerViews/ManagerProfileView"));
const AddTicketView = React.lazy(() => import("../views/managerViews/AddTicketView"));
const FeedBackView = React.lazy(() => import("../views/managerViews/FeedBackManager"));

// https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config
const routes = [
    { path: '/manager/login', name: 'Login', component: Login },
    { path: '/manager/profile', exact: true, name: 'ManagerProfileView', component: ManagerProfileView },
    { path: '/manager/tickets/bought-tickets', name: 'BoughtTickets', component: BoughtTickets },
    { path: '/manager/tickets/hot-deal-tickets', name: 'HotDealTickets', component: HotDealTickets },
    { path: '/manager/ticket/add',exact:true,name: 'AddTicketView', component: AddTicketView },
    { path: '/manager/feedback',exact:true,name: 'FeedBackView', component: FeedBackView },
];

export default routes;
import React from 'react';
import AirportControl from '../views/adminViews/AirportControl';

const ManagerControl = React.lazy(() => import("../views/adminViews/ManagerControl"));
const Login = React.lazy(() => import("../views/othersViews/LoginPage"));
const CountryControl = React.lazy(() => import('../views/adminViews/CountryControl/CountryControlView'));
const generateHotelPhotosSeeder = React.lazy(() => import('../views/adminViews/generateHotelPhotoSeeder/generateHotelPhotosView'));
const HotelControl = React.lazy(() => import("../views/adminViews/HotelControl"));
const ClientControl = React.lazy(() => import("../views/adminViews/ClientControl"));
const CityControl = React.lazy(() => import("../views/adminViews/CityControl"));
// https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config
const routes = [
  { path: '/admin/manager/control', exact: true, name: 'ManagerControl', component: ManagerControl },
  { path: '/admin/login', name: 'Login', component: Login },  
  { path: '/admin/hotel/control', exact: true, name: 'HotelControl',component: HotelControl },
  { path: '/admin', exact: true, name: 'ManagerControl', component: ManagerControl },
  { path: '/admin/airport/control', name: 'AirportControl', component: AirportControl },
  { path: '/admin/city/control', name: 'CityControl', component: CityControl },
  { path: '/admin/country/control', name: 'CountryControl', component: CountryControl },
  { path: '/admin/client/control', name: 'ClientControl', component: ClientControl},
  { path: '/admin/seeder/hotelPhotos', name: 'HotelPhotosSeeder', component: generateHotelPhotosSeeder },
];

export default routes;
import React from 'react';

const PersonsChart = React.lazy(() => import("../views/adminViews/PersonsChart"));
const CommentsChart = React.lazy(() => import("../views/adminViews/CommentsChart"));
//import CommentsChart from "../views/CommentsChart";

var routes = [
  
    {
      path: "/persons",
      name: "Persons",
      icon: "tim-icons icon-single-02",
      component: PersonsChart,
      layout: "/admin"
    },
    {
      path: "/comments",
      name: "Comments",
      icon: "tim-icons icon-pencil",
      component: CommentsChart,
      layout: "/admin"
    }
];
export default routes;
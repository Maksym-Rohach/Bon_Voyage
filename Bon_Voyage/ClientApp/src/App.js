import React, { Suspense, Component } from 'react';
import { Route, Switch, Redirect } from "react-router";
//import './App.scss';
import "./assets/scss/black-dashboard-react.scss";
import "./assets/css/black-dashboard-react.css";
import "./assets/demo/demo.css";
import "./assets/css/nucleo-icons.css";
import 'font-awesome/css/font-awesome.min.css';

const AdminLayout = React.lazy(() => import("./layouts/adminLayout/AdminLayout"))
//const loading = () => <div className="animated fadeIn pt-3 text-center">Loading...</div>;
class App extends Component {

  state = {
    isLoading: false,
    isError: false
  }

  render() { 
    return (
      <Suspense fallback={ <div>Загрузка...</div> }>
        <Switch>
          <Route path="/admin" name="Admin" render={ props => <AdminLayout { ...props } /> } />
          <Redirect from="/" to="/admin/persons" />
        </Switch>
      </Suspense>
    );
  }
};

export default App;
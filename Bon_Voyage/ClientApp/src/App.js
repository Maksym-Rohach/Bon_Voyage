import React, { Suspense, Component } from 'react';
import { Route, Switch, HashRouter as Router } from "react-router-dom";
import './App.scss';
import 'font-awesome/css/font-awesome.min.css';
import 'primereact/resources/themes/nova-light/theme.css';
import 'primereact/resources/primereact.min.css';
import 'primeicons/primeicons.css';

// Layouts
const AdminLayout = React.lazy(() => import("./layouts/adminLayout/AdminLayout"));
const ManagerLayout = React.lazy(() => import("./layouts/managerLayout/ManagerLayout"));

// Pages
const LoginPage = React.lazy(() => import("./views/othersViews/LoginPage"));
const HomePage = React.lazy(() => import("./views/othersViews/HomePage"));
const RegisterPage = React.lazy(() => import("./views/othersViews/RegisterPage"));
class App extends Component {

    state = {
        isLoading: false,
        isError: false
    }

    render() {
        return (
            <Router>
                <Suspense fallback={<div>Загрузка...</div>}>
                    <Switch>
                        <Route exact path="/" name="Home" render={props => <HomePage {...props} />} />
                        <Route exact path="/login" name="Login Page" render={props => <LoginPage {...props} />} />
                        <Route exact path="/register" name="Register Page" render={props => <RegisterPage {...props} />} />
                        <Route path="/admin" name="Admin" render={props => <AdminLayout {...props} />} />
                        <Route path="/manager" name="Manager" render={props => <ManagerLayout {...props} />} />
                        {/* <Redirect from="/" to="/admin/persons" /> */}
                    </Switch>
                </Suspense>
            </Router>
        );
    }
};

export default App;
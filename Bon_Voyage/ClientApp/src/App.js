import React, { Suspense, Component } from 'react';
import { Route, Switch, HashRouter as Router } from "react-router-dom";
//import './views/othersViews/instruments/vendors/magnefic-popup/jquery.magnific-popup.min';
import './App.scss';
import 'font-awesome/css/font-awesome.min.css';
import 'primereact/resources/themes/nova-light/theme.css';
import 'primereact/resources/primereact.min.css';
import 'primeicons/primeicons.css';

// Layouts
const AdminLayout = React.lazy(() => import("./layouts/adminLayout/AdminLayout"));
const ManagerLayout = React.lazy(() => import("./layouts/managerLayout/ManagerLayout"));
const ClientLayout = React.lazy(() => import("./layouts/clientLayout/ClientLayout"));

// Pages
const LoginPage = React.lazy(() => import("./views/othersViews/LoginPage"));
const HomePage = React.lazy(() => import("./views/othersViews/HomePage"));
const ForgotPasswordPage = React.lazy(() => import("./views/othersViews/ForgotPasswordPage"));
const RegisterPage = React.lazy(() => import("./views/othersViews/RegisterPage"));
const NewPasswordPage = React.lazy(() => import("./views/othersViews/NewPasswordPage"));
const ContactPage = React.lazy(() => import("./views/othersViews/ContactPage"));
const GalleryPage = React.lazy(() => import("./views/othersViews/GalleryPage"));




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
                        <Route exact path="/contact-page" name="Contact Page" render={props => <ContactPage {...props} />} />
                        <Route exact path="/gallery-page" name="Gallery Page" render={props => <GalleryPage {...props} />} />
                        <Route exact path="/register" name="Register Page" render={props => <RegisterPage {...props} />} /> 
                        <Route exact path="/forgot-password" name="ForgotPassword Page" render={props => <ForgotPasswordPage {...props} />} /> 
                        <Route exact path="/new-password/:id" name="NewPassword Page" render={props => <NewPasswordPage {...props} />} />                       
                        <Route path="/admin" name="Admin" render={props => <AdminLayout {...props} />} />
                        <Route path="/manager" name="Manager" render={props => <ManagerLayout {...props} />} />
                        <Route path="/client" name="Client" render={props => <ClientLayout {...props} />} />
                        {/* <Redirect from="/" to="/admin/persons" /> */}
                    </Switch>
                </Suspense>
            </Router>
        );
    }
};

export default App;
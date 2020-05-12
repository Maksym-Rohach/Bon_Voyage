import React, { Component, Suspense } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import * as router from 'react-router-dom';
import { Container } from 'reactstrap';
import * as loginReducer from '../../views/othersViews/LoginPage/reducer';
import { connect } from "react-redux";
import get from 'lodash.get';
import { logout } from '../../views/othersViews/LoginPage/reducer';


import {
  AppAside,
  AppFooter,
  AppHeader,
  AppSidebar,
  AppSidebarFooter,
  AppSidebarForm,
  AppSidebarHeader,
  AppSidebarMinimizer,
  AppBreadcrumb2 as AppBreadcrumb,
  AppSidebarNav2 as AppSidebarNav,
} from '@coreui/react';

import navigation from '../../navs/_clientNavs';
import routes from '../../routes/clientRoutes';


const ClientNavbar = React.lazy(() => import('./ClientNavbar'));

class ClientLayout extends Component {

  loading = () => <div className="animated fadeIn pt-1 text-center">Loading...</div>

  signOut(e) {
    e.preventDefault()
    this.props.logout();
    this.props.history.push('/login')
  }

  render() {

    const { login } = this.props;
    let isAccess = false;


    if(login.isAuthenticated===undefined){
        return (
            <Redirect to="/login" />  
          );
    }
    if(login.isAuthenticated)
    {     
      const { roles } = login.user;
      for (let i = 0; i < roles.length; i++) {
        if (roles[i] === 'Client')
          isAccess = true;
      }
    }

    const page = (
      <div className="app">
        <AppHeader fixed>
          <Suspense  fallback={this.loading()}>
            <ClientNavbar onLogout={e=>this.signOut(e)}/>
          </Suspense>
        </AppHeader>
        <div className="app-body">
          <AppSidebar fixed display="lg">
            <AppSidebarHeader />
            <AppSidebarForm />
            <Suspense>
            <AppSidebarNav navConfig={navigation} {...this.props} router={router}/>
            </Suspense>
            <AppSidebarFooter />
            <AppSidebarMinimizer />
          </AppSidebar>
          <main className="main">           
            <Container fluid>
              <Suspense fallback={this.loading()}>
                <Switch>
                  {routes.map((route, idx) => {
                    return route.component ? (
                      <Route
                        key={idx}
                        path={route.path}
                        exact={route.exact}
                        name={route.name}
                        render={props => (
                          <route.component {...props} />
                        )} />
                    ) : (null);
                  })}
                  <Redirect from="/" to="/" />
                </Switch>
              </Suspense>
            </Container>
          </main>
        </div>
      </div>
    );


    return (
    isAccess?
    page:
    <Redirect to="/login"/>
    );
  }
}



const mapStateToProps = (state) => {
  return {
    login: get(state, 'login')
  };
}

export default connect(mapStateToProps, { logout }) (ClientLayout);

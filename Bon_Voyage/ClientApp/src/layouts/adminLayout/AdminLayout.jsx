import React from "react";
import { Route, Switch } from "react-router-dom";
import PerfectScrollbar from "perfect-scrollbar";
import AdminNavbar from "./AdminNavbar";
import AdminSideBar from "./AdminSidebar";
import routes from "../../routes/adminRoutes";

var ps;

class AdminLayout extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      backgroundColor: "blue",
      sidebarOpened:
        document.documentElement.className.indexOf("nav-open") !== -1
    };
  }

  componentDidUpdate(e) {
    if (e.history.action === "PUSH") {
      if (navigator.platform.indexOf("Win") > -1) {
        let tables = document.querySelectorAll(".table-responsive");
        for (let i = 0; i < tables.length; i++) {
          ps = new PerfectScrollbar(tables[i]); 
        }
      }
      document.documentElement.scrollTop = 0;
      document.scrollingElement.scrollTop = 0;
      this.refs.mainPanel.scrollTop = 0;
    }
  }

  toggleSidebar = () => {
    document.documentElement.classList.toggle("nav-open");
    this.setState({ sidebarOpened: !this.state.sidebarOpened });
  };
  getRoutes = routes => {
    return routes.map((prop, key) => {
      if (prop.layout === "/admin") {
        return (
          <Route
            path={prop.layout + prop.path}
            component={prop.component}
            key={key}
          />
        );
      } else {
        return null;
      }
    });
  };
  handleBgClick = color => {
    this.setState({ backgroundColor: color });
  };
  getBrandText = path => {
    for (let i = 0; i < routes.length; i++) {
      if (
        this.props.location.pathname.indexOf(
          routes[i].layout + routes[i].path
        ) !== -1
      ) {
        return routes[i].name;
      }
    }
    return "Brand";
  };
  render() {
   
    const content = (
     <React.Fragment>
      <div className="wrapper">
        <AdminSideBar
          {...this.props}
          routes={routes}
          bgColor={this.state.backgroundColor}
          toggleSidebar={this.toggleSidebar}
        />
        <div
          className="main-panel"
          ref="mainPanel"
          data={this.state.backgroundColor}
        >
          <AdminNavbar
            {...this.props}
            brandText={this.getBrandText(this.props.location.pathname)}
            toggleSidebar={this.toggleSidebar}
            sidebarOpened={this.state.sidebarOpened}
          />
          <Switch>{this.getRoutes(routes)}</Switch>
        </div>
      </div>
      </React.Fragment> 
    )
    return (
      content      
    );
  }
}

export default AdminLayout;
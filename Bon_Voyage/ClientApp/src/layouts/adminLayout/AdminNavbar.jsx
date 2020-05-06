import React, { Component } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Badge, UncontrolledDropdown, DropdownItem, DropdownMenu, DropdownToggle, Nav, NavItem } from 'reactstrap';
import PropTypes from 'prop-types';
import mylogo from '../../assets/img/Logo.png';
import { AppAsideToggler, AppNavbarBrand, AppSidebarToggler } from '@coreui/react';

const propTypes = {
  children: PropTypes.node,
};

const defaultProps = {};

class AdminNavbar extends Component {
  render() {
    const { children, image, ...attributes } = this.props;
    return (
      <React.Fragment>
        <AppSidebarToggler className="d-lg-none" display="md" mobile />        
        <AppSidebarToggler className="d-md-down-none" display="lg" />    
        <Link className="ml-4 navbar-brand logo_h"  to="/"><img src={mylogo} height="50px"  alt="" /></Link>
        <Nav className="ml-auto" navbar>       
          <UncontrolledDropdown nav direction="down">
            <DropdownToggle nav>
              <img src={image} className="img-avatar" alt="" />
            </DropdownToggle>
            <DropdownMenu right>
              <DropdownItem onClick={e => this.props.onLogout(e)}><i className="fa fa-lock"></i>Вихід</DropdownItem>
            </DropdownMenu>
          </UncontrolledDropdown>
        </Nav>       
      </React.Fragment>
    );
  }
}
AdminNavbar.propTypes = propTypes;
AdminNavbar.defaultProps = defaultProps;

export default AdminNavbar;

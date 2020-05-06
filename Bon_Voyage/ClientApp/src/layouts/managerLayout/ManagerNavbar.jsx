import React, { Component } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Badge, UncontrolledDropdown, DropdownItem, DropdownMenu, DropdownToggle, Nav, NavItem } from 'reactstrap';
import PropTypes from 'prop-types';

import { AppAsideToggler, AppNavbarBrand, AppSidebarToggler } from '@coreui/react';
import mylogo from '../../assets/img/Logo.png';
import avatar from '../../assets/img/anime3.png';

const propTypes = {
  children: PropTypes.node,
};

const defaultProps = {};

class ManagerNavbar extends Component {
  render() {

    // eslint-disable-next-line
    const { children, ...attributes } = this.props;

    return (
      <React.Fragment>
        <AppSidebarToggler className="d-lg-none" display="md" mobile />     
        <AppSidebarToggler className="d-md-down-none" display="lg" />
        <Link className="ml-4 navbar-brand logo_h"  to="/"><img src={mylogo} height="50px"  alt="" /></Link>
        <Nav className="ml-auto" navbar>        
          <UncontrolledDropdown nav direction="down">
            <DropdownToggle nav>
              <img src={avatar} className="img-avatar" alt="manager@bootstrapmaster.com" />
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
ManagerNavbar.propTypes = propTypes;
ManagerNavbar.defaultProps = defaultProps;

export default ManagerNavbar;

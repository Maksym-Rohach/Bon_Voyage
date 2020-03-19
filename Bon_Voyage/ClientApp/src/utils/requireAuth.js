import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import { Redirect } from "react-router";

export default function (ComposedComponent, roles = '', userProps) {
  class Authenticate extends React.Component {

    state = {
      redirect: false,
      roles: roles
    };
    UNSAFE_componentWillMount() {
      if (this.state.roles !== '') {
        if (this.searchStringInArray(this.state.roles, this.props.roles) === -1)
          this.setState({ redirect: true })
      }
      if (!this.props.isAuthenticated) {
        this.setState({ redirect: true })
      }
    }
    searchStringInArray(str, strArray) {
      for (var j = 0; j < strArray.length; j++) {
        if (strArray[j].match(str)) return j;
      }
      return -1;
    }

    componentWillUpdate(nextProps) {
      if (this.state.roles !== '')
        if (this.searchStringInArray(this.state.roles, this.nextProps.roles) === -1) {
          this.setState({ redirect: true })
        }
      if (!nextProps.isAuthenticated) {
        this.setState({ redirect: true });
      }
    }

    render() {
      return (
        this.state.redirect ?
          <Redirect to="/login" /> :
          <ComposedComponent {...this.props} {...userProps} />
      );
    }
  }

  Authenticate.propTypes = {
    isAuthenticated: PropTypes.bool.isRequired,
    roles: PropTypes.array.isRequired
  }

  function mapStateToProps(state) {
    return {
      isAuthenticated: state.login.isAuthenticated,
      roles: state.login.user.roles
    };
  }

  return connect(mapStateToProps, {})(Authenticate);
}

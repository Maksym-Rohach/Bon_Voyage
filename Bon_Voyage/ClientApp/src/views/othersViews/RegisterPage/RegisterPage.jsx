import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import {
  Button, Card, CardBody, CardFooter, CardGroup,
  Col, Container, Form, Input, InputGroup,
  InputGroupAddon, InputGroupText, Row
} from 'reactstrap';
import classnames from 'classnames';
import PropTypes from 'prop-types';
import { connect } from "react-redux";
import { Register } from './reducer';
import { Redirect } from 'react-router-dom'
import * as registerListActions from './reducer';

import get from "lodash.get";

class RegisterPage extends Component {

  state = {
    email: '',
    password: '',
    name: '',
    surname: '',
    errorsState: {},
    errorServer: {},
    done: false,
    isLoading: false,
    visible: false
  }

  onSubmitForm = (e) => {
    e.preventDefault();
    const { email, password, name, surname } = this.state;

    let errorsState = {};

    if (password.length<8) errorsState.password = " Поле має складатись з 8 символів, містити мінімум одну велику літеру! ";

    if (name.length <3) errorsState.name = " Введіть корректне ім'я! ";

    if (surname <3) errorsState.surname = " Введіть корректне прізвище! ";

    const isValid = Object.keys(errorsState).length === 0
    if (isValid) {
      this.setState({ isLoading: true });
      const model = {
        email: email,
        password: password,
        name: name,
        surname: surname
      };

      this.props.Register(model);
    }
    else {
      this.setState({ errorsState });
    }
  }

  componentWillReceiveProps = (nextProps) => { 
    this.setState(
        {
          errorServer: nextProps.redusererrors
        }
    )
}

  setStateByErrors = (name, value) => {
    if (!!this.state.errorsState[name]) {
      let errorsState = Object.assign({}, this.state.errorsState);
      delete errorsState[name];
      this.setState(
        {
          [name]: value,
          errorsState
        }
      )
    }
    else {
      this.setState(
        { [name]: value })
    }
  }

  handleChange = (e) => {
    this.setStateByErrors(e.target.name, e.target.value);
  }

  passwordVisible = (e) => {
    this.setState({
      visible: !this.state.visible,
    });
  }

  render() {
    const { errorsState, isLoading, profileUrl, visible, errorServer } = this.state;
    const form = (
      <div className="app flex-row">
        <Container>
          <Row className="justify-content-center mt-5">
            <Col md="8">
              <CardGroup>
                <Card className="p-4">
                  <CardBody>
                    <Form onSubmit={this.onSubmitForm}>
                      <h1>Реєстрація</h1>
                      <p className="text-muted">Зареєструйте свій обліковий запис</p>
                      <InputGroup className="mb-3">
                        <Input
                          type="email"
                          placeholder="Електронна пошта"
                          id="email"
                          autoComplete="email"
                          name="email"
                          value={this.state.email}
                          onChange={this.handleChange}
                        />
                      </InputGroup>
                      {!!errorsState.name ? <div style={{color:"red"}}>{errorsState.name}</div> : ""}
                      <InputGroup className="mb-3">
                        <Input
                          type="text"
                          placeholder="Ім'я"
                          id="name"
                          autoComplete="name"
                          name="name"
                          value={this.state.name}
                          onChange={this.handleChange}
                        />
                      </InputGroup>
                      {!!errorsState.surname ? <div style={{color:"red"}}>{errorsState.surname}</div> : ""}
                      <InputGroup className="mb-3">
                        <Input
                          type="text"
                          placeholder="Прізвище"
                          id="surname"
                          autoComplete="surname"
                          name="surname"
                          value={this.state.surname}
                          onChange={this.handleChange}
                        />
                      </InputGroup>
                      {!!errorsState.password ? <div style={{color:"red"}}>{errorsState.password}</div> : ""}
                      <InputGroup className="mb-4">
                        <Input
                          type={classnames(visible ? "text" : "password")}
                          id="password"
                          name="password"
                          placeholder="Пароль"
                          autoComplete="current-password"
                          onChange={this.handleChange}
                        />
                        <InputGroupAddon addonType="append">
                          <Button onClick={this.passwordVisible}>
                            <i className={classnames(visible ? 'fa fa-eye' : 'fa fa-eye-slash')}></i>
                          </Button>
                        </InputGroupAddon>
                      </InputGroup>
                      <Row>
                        <Col xs="6">
                          <Button type="submit" color="primary" className="px-4">Реєстрація</Button>
                        </Col>
                      </Row>
                      {!!errorServer ? <div style={{color:"red"}}>{errorServer.errorMessage}</div> : ""}
                    </Form>
                  </CardBody>
                </Card>
              </CardGroup>
            </Col>
          </Row>
        </Container>
      </div>
    );
    return (
      this.props.success ? <Redirect to='/login' /> : form
    );
  }
}

const mapStateToProps = state => {
  return {
    loading: get(state, 'register.post.loading'),
    failed: get(state, 'register.post.failed'),
    success: get(state, 'register.post.success'),
    redusererrors: get(state, 'register.post.errors')
  }
}

const mapDispatchToProps = (dispatch) => {
  return {
    Register: filter => {
      dispatch(registerListActions.Register(filter));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(RegisterPage);
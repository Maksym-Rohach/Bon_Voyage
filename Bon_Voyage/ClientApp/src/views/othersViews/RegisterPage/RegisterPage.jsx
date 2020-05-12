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

import get from "lodash.get";

class RegisterPage extends Component {

  state = {
    email: '',
    password: '',
    name: '',
    surname: '',
    errors: {},
    done: false,
    isLoading: false,
    visible: false,
    errorsServer: {}
  }

  passwordVisible = (e) => {
    this.setState({
      visible: !this.state.visible,
    });
  }

  static getDerivedStateFromProps(nextProps, prevState) {
    return { isLoading: nextProps.loading, errorsServer: nextProps.errors };
  }

  setStateByErrors = (name, value) => {
    if (!!this.state.errors[name]) {
      let errors = Object.assign({}, this.state.errors);
      delete errors[name];
      this.setState(
        {
          [name]: value,
          errors
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
  onSubmitForm = (e) => {
    e.preventDefault();
    const { email, password, name, surname } = this.state;

    let errors = {};

    if (password.length<8) errors.password = " Поле має складатись з 8 символів, містити мінімум одну велику літеру! ";

    if (name.length <3) errors.name = " Введіть корректне ім'я! ";

    if (surname <3) errors.surname = " Введіть корректне прізвище! ";

    const isValid = Object.keys(errors).length === 0
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
      this.setState({ errors });
    }
  }

  render() {
    const { errors, isLoading, profileUrl, visible, errorsServer } = this.state;
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
                      {!!errors.name ? <div style={{color:"red"}}>{errors.name}</div> : ""}
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
                      
                      {!!errors.surname ? <div style={{color:"red"}}>{errors.surname}</div> : ""}
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
                      {!!errors.password ? <div style={{color:"red"}}>{errors.password}</div> : ""}
                      {/* {!!errorsServer ? <div>{errorsServer}</div> : ""} */}
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

function mapStateToProps(state) {
  console.log("mapStateToProps", state);
  return {
    loading: get(state, 'register.post.loading'),
    failed: get(state, 'register.post.failed'),
    success: get(state, 'register.post.success'),
    errors: get(state, 'register.post.errors')
  }
}

const mapDispatch = {
  Register: (model) => {
    return Register(model);
  }
}

export default connect(mapStateToProps, mapDispatch)(RegisterPage);



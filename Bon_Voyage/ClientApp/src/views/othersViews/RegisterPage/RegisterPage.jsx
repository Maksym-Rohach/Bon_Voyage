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

    //const regex_phone = /^(?=\+?([0-9]{2})\(?([0-9]{3})\)?([0-9]{3})-?([0-9]{2})-?([0-9]{2})).{17}$/;

    let errors = {};

    if (email === '') errors.email = "Поле є обов'язковим";
    //if (!regex_phone.test(phone)) errors.phone = "Не вiрний формат +xx(xxx)xxx-xx-xx телефону";

    if (password === '') errors.password = "Поле є обов'язковим";

    if (name === '') errors.name = "Поле є обов'язковим";

    if (surname === '') errors.surname = "Поле є обов'язковим";

    const isValid = Object.keys(errors).length === 0
    if (isValid) {
      this.setState({ isLoading: true });
      const model = {
        email: email,
        password: password,
        name: name,
        surname: surname
      };

      console.log("Registration************************", model)
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
                          //className={classnames("form-control", { "is-invalid": !!errors.email })}
                          id="email"
                          autocomplete="new-password"
                          name="email"
                          value={this.state.email}
                          onChange={this.handleChange}
                        />
                        {/* {!!errors.email ? <div className="invalid-feedback">{errors.email}</div> : ""} */}
                      </InputGroup>
                      <InputGroup className="mb-3">
                        <Input
                          type="text"
                          placeholder="Імя"
                          //className={classnames("form-control", { "is-invalid": !!errors.name })}
                          id="name"
                          autocomplete="new-password"
                          name="name"
                          value={this.state.name}
                          onChange={this.handleChange}
                        />
                        {/* {!!errors.email ? <div className="invalid-feedback">{errors.email}</div> : ""} */}
                      </InputGroup>
                      <InputGroup className="mb-3">
                        <Input
                          type="text"
                          placeholder="Прізвище"
                          //className={classnames("form-control", { "is-invalid": !!errors.surname })}
                          id="surname"
                          autocomplete="new-password"
                          name="surname"
                          value={this.state.surname}
                          onChange={this.handleChange}
                        />
                        {/* {!!errors.email ? <div className="invalid-feedback">{errors.email}</div> : ""} */}
                      </InputGroup>
                      <InputGroup className="mb-4">
                        <Input
                          //className={classnames('form-control', { 'is-invalid': !!errors.password })}
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
                        {/* {!!errors.password ? <div className="invalid-feedback">{errors.password}</div> : ''} */}
                      </InputGroup>
                      <Row>
                        <Col xs="6">
                          <Button color="primary" className="px-4">Реєстрація</Button>
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
      form
    );
  }
}

// Register.propTypes =
//   {
//     Register: PropTypes.func.isRequired
//   }

function mapStateToProps(state) {
  console.log("mapStateToProps", state);
  return {
    loading: get(state, 'login.post.loading'),
    failed: get(state, 'login.post.failed'),
    success: get(state, 'login.post.success'),
    errors: get(state, 'login.post.errors')
  }
}

// const mapDispatchToProps = (dispatch) => {
//     return {
//         Register: filter => {
//         dispatch(getListActions.Register(filter));
//       }
//     }
//   }

const mapDispatch = {
  Register: (model) => {
    return Register(model);
  }
}

export default connect(mapStateToProps, mapDispatch)(RegisterPage);



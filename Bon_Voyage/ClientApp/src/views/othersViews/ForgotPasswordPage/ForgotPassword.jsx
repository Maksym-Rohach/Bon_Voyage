import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Button, Card, CardBody, CardFooter, CardGroup,
         Col, Container, Form, Input, InputGroup,
         InputGroupAddon, InputGroupText, Row } from 'reactstrap';
import classnames from 'classnames';
import PropTypes from 'prop-types';
import { connect } from "react-redux";
import {ForgotPassword} from './reducer';

import get from "lodash.get";

class ForgotPasswordPage extends Component {

    state = {
      email: '',
      errors: {},
      done: false,
      isLoading: false,
      errorsServer: {}
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
      const { email} = this.state;
  
      //const regex_phone = /^(?=\+?([0-9]{2})\(?([0-9]{3})\)?([0-9]{3})-?([0-9]{2})-?([0-9]{2})).{17}$/;
  
      let errors = {};
  
      if (email === '') errors.email = "Поле є обов'язковим";
      
  
  
      const isValid = Object.keys(errors).length === 0
      if (isValid) {
        this.setState({ isLoading: true });
        const model = {
          email: email,
          };
  
          console.log("Forgot Password",model)
        this.props.ForgotPassword(model);     
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
                            <h1>Забули Пароль?</h1>
                            <p className="text-muted">Вкажіть свою електронну пошту</p>
                                <InputGroup className="mb-3">
                                    <Input
                                        type="email"
                                        placeholder="Електронна пошта"
                                       
                                        id="email"
                                        autocomplete="new-password"
                                        name="email"
                                        value={this.state.email}
                                        onChange={this.handleChange}
                                    />                       
                                   
                                </InputGroup>                                                                                      
                                    <Row>
                                    <Col xs="4">
                                <Button color="primary" className="px-4">Відправити пароль</Button>
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
 


function mapStateToProps(state) {
  console.log("mapStateToProps", state);
  return {
    loading: get(state, 'login.post.loading'),
    failed: get(state, 'login.post.failed'),
    success: get(state, 'login.post.success'),
    errors: get(state, 'login.post.errors')
  }
}



const mapDispatch = {
  ForgotPassword: (model) => {
      return ForgotPassword(model);
  }
}

export default connect(mapStateToProps, mapDispatch)(ForgotPasswordPage);
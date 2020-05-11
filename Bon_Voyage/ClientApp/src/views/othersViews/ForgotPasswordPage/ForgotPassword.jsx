import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Button, Card, CardBody, CardFooter, CardGroup,
         Col, Container, Form, Input, InputGroup,
         InputGroupAddon, InputGroupText, Row } from 'reactstrap';

import { connect } from "react-redux";
import * as reducer from './reducer';
import {Growl} from 'primereact/growl';

import get from "lodash.get";

class ForgotPasswordPage extends Component {

    state = {
      email: '',
      errors: {},
      done: false,
      isLoading: false,
      isSuccess:false,
      errorsServer: {}
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
  
    showSuccess = () => {
      this.growl.show({severity: 'success', summary: 'Перейдіть на свою пошту для зміни паролю', detail:'',sticky:true});
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


    componentWillReceiveProps = (nextProps) => {
    // console.log("nextProps",nextProps);
      if(this.props != nextProps){
        this.setState({
          isSuccess : nextProps.successReducer
        });
      }
    }
    
    render() { 
        const { errors, isLoading, profileUrl, visible, errorsServer } = this.state;

      if(this.state.isSuccess){
        console.log("success");
        this.showSuccess();
        this.setState({isSuccess: false});
      }

        const form = (
            <div className="app flex-row">
              <Container>
              <Growl ref={(el) => this.growl = el} />
                <Row className="justify-content-center mt-5">
                  <Col md="8">
                    <CardGroup>
                      <Card className="p-4">
                        <CardBody>
                          <Form onSubmit={this.onSubmitForm}>
                            <h1>Забули Пароль?</h1>
                            <p className="text-muted">Вкажіть свою електронну пошту</p>
                                <InputGroup className="mb-2">
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
                                    <Link to="/login">                                                  
                                <Button color="primary" className="px-4">Назад</Button>    
                                    </Link>
                                    </Col> 
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
    loading: get(state, 'forgotPassword.post.loading'),
    failed: get(state, 'forgotPassword.post.failed'),
    successReducer: get(state, 'forgotPassword.post.success'),
    errors: get(state, 'forgotPassword.post.errors')
  }
}



const mapDispatch = {
  ForgotPassword: (model) => {
      return reducer.ForgotPassword(model);
  } 
  
}

export default connect(mapStateToProps, mapDispatch)(ForgotPasswordPage);
import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Button, Card, CardBody, CardGroup,
         Col, Container, Form, Input, InputGroup,
         Row } from 'reactstrap';
import { connect } from "react-redux";
import * as reducer from './reducer';
import {Growl} from 'primereact/growl';
import get from "lodash.get";


class NewPasswordPage extends Component {

    state = {
      newPassword: '',
      confirmPassword:'',
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
      this.growl.show({severity: 'success', summary: 'Ви успішно змінили свій пароль', detail:'',sticky:true});
  }



    handleChange = (e) => {
      this.setStateByErrors(e.target.name, e.target.value);
  
    }
    onSubmitForm = (e) => {
      e.preventDefault();
      const { newPassword,confirmPassword} = this.state;
  
      let errors = {};
  
      if (newPassword === '' || confirmPassword==='') errors.newPassword = "Поле є обов'язковим";
      
      
  
      const isValid = Object.keys(errors).length === 0
      if (isValid) {
        this.setState({ isLoading: true });
        const model = {
          newPassword: newPassword,
          confirmPassword:confirmPassword,
          };
  
          
        this.props.newPassword(model);     
      }
      else {
        this.setState({ errors });
      }
    }

    componentWillReceiveProps = (nextProps) => {
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
                            <h1>Змінити пароль</h1>
                            <p className="text-muted">Вкажіть новий пароль</p>
                                <InputGroup className="mb-2">
                                    <Input
                                        type="text"
                                        placeholder="Новий пароль"
                                       
                                        id="newPassword"
                                        autocomplete="new-password"
                                        name="newPassword"
                                        value={this.state.newPassword}
                                        onChange={this.handleChange}
                                    />                                                         
                                </InputGroup> 
                                <InputGroup className="mb-2">
                                    <Input
                                        type="text"
                                        placeholder="Підтвердіть новий пароль"                                       
                                        id="confirmPassword"
                                        autocomplete="confirm-password"
                                        name="confirmPassword"
                                        value={this.state.confirmPassword}
                                        onChange={this.handleChange}
                                    />                                                         
                                </InputGroup>                                                                                       
                                    <Row>
                                    <Col xs="4">                                 
                                    </Col> 
                                    <Col xs="4">
                                <Button color="primary" className="px-4">Змінити пароль</Button>                              
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
    loading: get(state, 'newPassword.post.loading'),
    failed: get(state, 'newPassword.post.failed'),
    successReducer: get(state, 'newPassword.post.success'),
    errors: get(state, 'newPassword.post.errors')
  }
}



const mapDispatch = {
  NewPassword: (model) => {
      return reducer.newPassword(model);
  } 
  
}

export default connect(mapStateToProps, mapDispatch)(NewPasswordPage);
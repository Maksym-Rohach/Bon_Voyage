import React, { Component } from 'react';
import * as createManagerListActions from './reducer';
import * as getManagerListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { Dialog } from 'primereact/dialog';
import { Dropdown } from 'primereact/dropdown';
import { Form, InputGroup, Input, InputGroupAddon, InputGroupText } from 'reactstrap';

class ManagerControl extends Component {
  state = {
    name:undefined,
    surname:undefined,
    email:undefined,
    salary:4800,
    errors:{},
    visible:false,
  }

  defaultState={
    name:undefined,
    surname:undefined,
    email:undefined,
    salary:4800,
    errors:{},
    visible:false,
  }
  dialogHide = (e) => {
    this.setState({ visible: false });
  }
  componentDidMount = () => {
    this.props.getManagerControlData();
  }

  submitForm=(e)=>{
    let isValid=true;
    let validErrors={};
    e.preventDefault();
    if(this.state.name===undefined||this.state.name===""){
      isValid=false;
      validErrors.name="Це поле має бути заповнено";
    }
    if(this.state.email===undefined||this.state.email===""){
      isValid=false;
      validErrors.email="Це поле має бути заповнено";
    }
    else{
      let regex=/[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}/;
      if(!regex.test(this.state.email)){
        isValid=false;
        validErrors.email="Почта введена невірно";
      }
    }
    if(this.state.surname===undefined||this.state.surname===""){
      isValid=false;
      validErrors.surname="Це поле має бути заповнено";
    }
    if(this.state.salary===0){
      isValid=false;
      validErrors.salary="Це поле має бути заповнено";
    }
    
    if(isValid){
      let model={
        name:this.state.name,
        email:this.state.email,
        salary:this.state.salary,
        surname:this.state.surname
      };
      this.props.createManager(model);
    }
    else{
      this.setState({errors:validErrors});
      this.state.errors=validErrors;
      console.log(this.state.errors);
    }
  }

  clear=()=>
  {
    this.setState(this.defaultState);
    this.props.clearErrors();
  }

  render() {    
    const { listManagers } = this.props;
    let {errors} = this.props;
    if(errors===undefined){
      if(this.state.errors===undefined){
        this.clear();
      }
      else{
        errors=this.state.errors;
      }
    }
    console.log("render", listManagers);
    return (
      <div className="d-flex" style={{paddingTop: "15px"}}>     
        <DataTable value={listManagers}>
          <Column field="name" header="Ім'я" />
          <Column field="surname" header="Прізвище" />
          <Column field="email" header="Пошта" />
          <Column field="dateOfRegister" header="Дата реєстрації" />
        </DataTable>
        <Dialog header="Додавання менеджера" position="right" visible={this.state.visible} style={{ width: '50vw'}} modal={true} onHide={e => this.dialogHide(e)}>
          <Form onSubmit={(e) => { this.submitForm(e) }} style={{ height: '15vw' }}>
            <InputGroup className="mb-3">
              <Input
                type="email"
                placeholder="Електронна пошта"
                name="email"
                value={this.state.email}
                onChange={(e)=>{this.setState({email: e.target.value})}}
              />
              {!!errors.email ? <div className="invalid-feedback">{errors.email}</div> : ""}
            </InputGroup>
            
            <InputGroup className="mb-3">
              <Input
                type="text"
                placeholder="Імя"
                id="name"
                name="name"
                value={this.state.name}
                onChange={(e)=>{this.setState({name: e.target.value})}}               
              /> 
              {!!errors.name ? <div className="invalid-feedback">{errors.name}</div> : ""}             
            </InputGroup>            
            <InputGroup className="mb-3">
              <Input
                type="text"
                placeholder="Прізвище"
                id="surname"
                autocomplete="new-password"
                name="surname"
                value={this.state.surname}
                onChange={(e)=>{this.setState({surname: e.target.value})}}
              />
              {!!errors.surname ? <div className="invalid-feedback">{errors.surname}</div> : ""}
            </InputGroup>            
            <InputGroup className="mb-3">
              <InputGroupAddon><InputGroupText>Зарплата</InputGroupText></InputGroupAddon>
              <Input
                type="number"
                id="surname"
                autocomplete="new-password"
                name="surname"
                value={this.state.salary}
                onChange={(e)=>{this.setState({salary: e.target.value})}}
              />
              {!!errors.salary ? <div className="invalid-feedback">{errors.salary}</div> : ""}
            </InputGroup>            
            <div>
              <Button label="Додати" style={{ margin: '1rem' }} color="secondary"></Button>
            </div>
          </Form>
        </Dialog>
        <div>
        <Button label="Додати менеджера" className="p-button-primary " onClick={(e) => this.setState({ visible: true })} />
        </div>
        
      </div>
        );
  }
}

const mapStateToProps = state => {
  return {
    listManagers: get(state, 'managers.list.data'),
    errors: get(state, 'managers.createRespone.errors'),
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    getManagerControlData: filter => {
      dispatch(getManagerListActions.getManagerControlData(filter));
    },
    createManager: (model) => {
      dispatch(createManagerListActions.createManager(model));
    },
    clearErrors: () => {
      dispatch(createManagerListActions.clearErrors());
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(ManagerControl);
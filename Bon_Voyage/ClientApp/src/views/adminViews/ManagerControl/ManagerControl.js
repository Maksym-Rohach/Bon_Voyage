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
import { Form, InputGroup, Input } from 'reactstrap';

class ManagerControl extends Component {
  state = {
    name:'',
    surname:'',
    email:'',
    salary:0,
  }

  dialogHide = (e) => {
    this.setState({ visible: false });
  }
  componentDidMount = () => {
    this.props.getManagerControlData();
  }

  render() {

    const { listManagers } = this.props;
    console.log("render", listManagers);
    return (
      <div className="d-flex" style={{paddingTop: "15px"}}>     
        <DataTable value={listManagers}>
          <Column field="name" header="Ім'я" />
          <Column field="surname" header="Прізвище" />
          <Column field="email" header="Пошта" />
          <Column field="dateOfRegister" header="Дата реєстрації" />
        </DataTable>
        <Dialog header="Додавання менеджера" position="right" visible={this.state.visible} style={{ width: '50vw' }} modal={true} onHide={e => this.dialogHide(e)}>
          <Form onSubmit={(e) => { this.submitForm(e) }} style={{ height: '15vw' }}>
          <InputGroup className="mb-3">
                        <Input
                          type="email"
                          placeholder="Електронна пошта"
                          name="email"
                          value={this.state.email}
                          onChange={(e)=>{this.setState({email: e.value})}}
                        />
                      </InputGroup>
                      <InputGroup className="mb-3">
                        <Input
                          type="text"
                          placeholder="Імя"
                          id="name"
                          name="name"
                          value={this.state.name}
                          onChange={(e)=>{this.setState({name: e.value})}}
                        />
                      </InputGroup>
                      <InputGroup className="mb-3">
                        <Input
                          type="text"
                          placeholder="Прізвище"
                          id="surname"
                          autocomplete="new-password"
                          name="surname"
                          value={this.state.surname}
                          onChange={(e)=>{this.setState({surname: e.value})}}
                        />
                      </InputGroup>
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
    createRespone: (model) => {
      dispatch(createManagerListActions.createManager(model));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(ManagerControl);
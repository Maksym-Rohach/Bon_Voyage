import React, { Component } from 'react';
import * as createManagerListActions from './reducer';
import * as getManagerListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { Dropdown } from 'primereact/dropdown';
import { Form } from 'reactstrap';

class ManagerControl extends Component {
  state = {
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
      <div>     
        <DataTable value={listManagers}>
          <Column field="name" header="Ім'я" />
          <Column field="surname" header="Прізвище" />
          <Column field="email" header="Пошта" />
          <Column field="dateOfRegister" header="Дата реєстрації" />
        </DataTable>
        <Dialog header="Додавання аеропорту" position="right" visible={this.state.visible} style={{ width: '50vw' }} modal={true} onHide={e => this.dialogHide(e)}>
          <Form onSubmit={(e) => { this.submitForm(e) }} style={{ height: '15vw' }}>

          </Form>
        </Dialog>
        <Button label="Додати аеропорт" className="p-button-primary btn-block p-button-raised" onClick={(e) => this.setState({ visible: true })} />
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
import React, { Component } from 'react';
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import {DataTable} from 'primereact/datatable';
import {Column} from 'primereact/column';

class ManagerControl extends Component {
    state = {  }

    componentDidMount = () => {
      this.props.getManagerControlData();
    }

    render() { 

        const { listManagers }= this.props;
        console.log("render",listManagers);

        return ( 
            <DataTable value={listManagers}>
            <Column field="name" header="Ім'я" />
            <Column field="surname" header="Прізвище" />
            <Column field="email" header="Пошта" />
            <Column field="dateOfRegister" header="Дата реєстрації" />
        </DataTable>
         );
    }
}

const mapStateToProps = state => {
    return {
        listManagers: get(state, 'managers.list.data'), 
    };
  }

  const mapDispatchToProps = (dispatch) => {
    return {
        getManagerControlData: filter => {
        dispatch(getListActions.getManagerControlData(filter));
      }
    }
  }
 
export default connect(mapStateToProps, mapDispatchToProps) (ManagerControl);
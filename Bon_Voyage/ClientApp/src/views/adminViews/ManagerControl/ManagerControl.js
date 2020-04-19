import React, { Component } from 'react';
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import {DataTable} from 'primereact/datatable';
import {Column} from 'primereact/column';
import Loader from '../../../components/Loader';

class ManagerControl extends Component {
    state = { 
     }

    componentDidMount = () => {
      this.props.getManagerControlData();
    }

    render() { 

        const { listManagers, isLoading }= this.props;
        console.log("render",listManagers);

        return ( 
          <React.Fragment>
            {isLoading && <Loader/>}
            <DataTable value={listManagers}>
            <Column field="name" header="Ім'я" />
            <Column field="surname" header="Прізвище" />
            <Column field="email" header="Пошта" />
            <Column field="dateOfRegister" header="Дата реєстрації" />
        </DataTable>
        </React.Fragment>
         );
    }
}

const mapStateToProps = state => {
    return {
        listManagers: get(state, 'managers.list.data'), 
        isLoading: get(state, 'managers.list.loading')
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
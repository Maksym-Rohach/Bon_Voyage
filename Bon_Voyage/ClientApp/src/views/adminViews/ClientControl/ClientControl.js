import React, { Component } from 'react';
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import {DataTable} from 'primereact/datatable';
import {Column} from 'primereact/column';
import {Button} from 'primereact/button';
import {Dialog} from 'primereact/dialog';

class ClientControl extends Component {
    state = { 
     }

    componentDidMount = () => {
      this.props.getClientControlData();
    }

    actionTemplate(rowData, column) {
        return <div>
            <Button type="button" icon="pi pi-cog" className="p-button-secondary p-button-rounded"></Button>

        </div>;
    }

    render() { 

        const { listClients }= this.props;
        console.log("render",listClients);

        var header = <div className="p-clearfix" style={{'lineHeight':'1.87em'}}>Список клієнтів</div>;

        return ( 
            <DataTable value={listClients} header={header}>
            <Column field="name" header="Ім'я" />
            <Column field="surname" header="Прізвище" />
            <Column field="dateOfBirth" header="Дата народження" />
        </DataTable>
         );
    }
}

const mapStateToProps = state => {
    return {
        listClients: get(state, 'clients.list.data'), 
    };
  }

  const mapDispatchToProps = (dispatch) => {
    return {
        getClientControlData: filter => {
        dispatch(getListActions.getClientControlData(filter));
      }
    }
  }
 
export default connect(mapStateToProps, mapDispatchToProps) (ClientControl);
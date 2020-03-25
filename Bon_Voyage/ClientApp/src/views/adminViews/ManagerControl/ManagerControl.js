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
            <DataTable value={this.state.cars}>
            <Column field="vin" header="Vin" />
            <Column field="year" header="Year" />
            <Column field="brand" header="Brand" />
            <Column field="color" header="Color" />
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
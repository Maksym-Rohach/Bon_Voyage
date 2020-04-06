import React, { Component, useState  } from 'react';
import * as getListActions from "./reducer"
import { connect } from 'react-redux';
import get from "lodash.get";
import { DataTable} from 'primereact/datatable';
import { Column } from 'primereact/column';
class AirportControl extends Component {
    state = {
    }
    
    componentDidMount = () => {
        this.props.getAirportControlData();
    }

    render() {
        const { listAirports } = this.props;
        console.log("render", listAirports);
        

        return (
            <div>
                <DataTable value={listAirports}>
                    <Column field="name" header="Ім'я" />
                    <Column field="shortName" header="Коротке ім'я" />
                    <Column field="cityName" header="Назва міста" />
                </DataTable>
                <button className="btn-secondary btn-lg align-self-end">Add airport</button>
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        listAirports: get(state, 'airports.list.data'),
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        getAirportControlData: filter => {
            dispatch(getListActions.getAirportControlData(filter));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(AirportControl);
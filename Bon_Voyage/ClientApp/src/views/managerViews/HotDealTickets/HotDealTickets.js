import React, { Component } from 'react';
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import {InputText} from "primereact/inputtext";

class HotDealTickets extends Component {
    state = {
    }

    actionTemplate(rowData, column) {
        return <div >
        <div className="p-inputgroup">
        
            <InputText value={this.discount} placeholder="Discount %"/>
            <Button icon="pi pi-check" className="p-button-success"/>
        </div>
    </div>;
    }

    componentDidMount = () => {
        this.props.getHotDealTicketsData();
    }

    render() {

        const { listHotDealTickets } = this.props;
        console.log("render", listHotDealTickets);

        return (
            <Card className="mt-5">
                <DataTable value={listHotDealTickets}>
                    <Column sortable={true} field="dateFrom" header="Date From" />
                    <Column sortable={true} field="dateTo" header="Date To" />
                    <Column sortable={true} field="country.name" header="Country Name" />
                    <Column sortable={true} field="countOfPlaces" header="Count Of Places" />
                    <Column sortable={true} field="price" header="Price" />
                    <Column sortable={true} body={this.actionTemplate} style={{textAlign:'center', width: '16em'}} field="discount" header="Discount" />
                </DataTable>
            </Card>
        );
    }
}

const mapStateToProps = state => {
    return {
        listHotDealTickets: get(state, 'hotDealTickets.list.data'),
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        getHotDealTicketsData: filter => {
            dispatch(getListActions.getHotDealTicketsData(filter));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(HotDealTickets);


 
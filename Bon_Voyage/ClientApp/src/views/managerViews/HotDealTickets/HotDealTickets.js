import React, { Component } from 'react';
import * as getListActions from './reducer';
import * as getUpdateDiscountListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import { InputText } from "primereact/inputtext";

class HotDealTickets extends Component {
    state = {
        Id: "",
        Discount: "",
        error: ""
    }
    handleKeyPress(event) {
        console.log(event.target);
        if (event.charCode == 13) {
            if (event.target.value != "") {
                if (event.target.value <= 100) {
                    event.preventDefault();
                    this.state.Discount = event.target.value;
                    this.state.Id = event.target.id;
                    const Id = this.state.Id;
                    const Discount = this.state.Discount;
                    const model = {
                        Id: Id,
                        NewDiscount: Discount,
                    };
                    console.log(event.target);
                    this.props.updateTicketDiscountData(model);
                    //this.props.getHotDealTicketsData();
                    this.forceUpdate();
                    event.target.placeholder = event.target.value;
                    event.target.value = "";
                }
            }
        }
    }




    //<Button icon="pi pi-check" onClick={this.buttonPress.bind(this)} className="p-button-success" />

    actionTemplate(rowData, column) {

        return <div >
            <div className="p-inputgroup">
                <span className="p-inputgroup-addon">
                    %
                </span>
                <InputText name="discountInput" id={rowData.id} placeholder={rowData.discount} keyfilter="pint" onKeyPress={this.handleKeyPress.bind(this)} />
                <span className="p-inputgroup-addon">
                    <img width="15px" height="10px" src="https://image.flaticon.com/icons/svg/60/60539.svg"></img>
                </span>
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
                <DataTable value={listHotDealTickets} paginator={true} ref={(el) => this.dt = el} rows={10} first={this.state.first} onPage={(e) => this.setState({ first: e.first })}>
                    <Column sortable={true} field="dateFrom" header="Date From" />
                    <Column sortable={true} field="dateTo" header="Date To" />
                    <Column sortable={true} field="country.name" header="Country Name" />
                    <Column sortable={true} field="countOfPlaces" header="Count Of Places" />
                    <Column sortable={true} field="price" header="Price" />
                    <Column sortable={true} body={this.actionTemplate.bind(this)} style={{ textAlign: 'center', width: '18em' }} field="discount" header="Discount" />
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
        },
        updateTicketDiscountData: (model) => {
            dispatch(getUpdateDiscountListActions.updateTicketDiscountData(model));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(HotDealTickets);



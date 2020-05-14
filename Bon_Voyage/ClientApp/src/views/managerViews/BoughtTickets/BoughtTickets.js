import React, { Component } from 'react';
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Card } from 'primereact/card';
import {Calendar} from 'primereact/calendar';


class BoughtTickets extends Component {
    state = {      
        dateFilter:null
    }

    renderDateFilter() {
        return (
            <Calendar value={this.state.dateFilter} onChange={this.onDateFilterChange} placeholder="Вибрати дату" dateFormat="dd.mm.yy" className="p-column-filter" />
        );
    }
    componentDidMount = () => {
        this.props.getBoughtTicketsData();
    }

    render() {

        const { listBoughtTickets } = this.props;
        console.log("render", listBoughtTickets);
        const dateFilter = this.renderDateFilter();
        return (        
            <Card className="mt-5">                       
                <DataTable value={listBoughtTickets} paginator={true} ref={(el) => this.dt = el} rows={10} first={this.state.first} onPage={(e) => this.setState({first: e.first})}>
                    <Column sortable={true} field="client.fullName" filter={true} filterPlaceholder="Search" style={{textAlign:'center'}} header="Ім'я покупця" />
                    <Column sortable={true} field="dateTo" filter={true} filterMatchMode="contains" filterPlaceholder="Search" style={{textAlign:'center'}} header="Дата відправлення" />            
                    <Column sortable={true} field="dateFrom" filter={true} filterMatchMode="contains" filterPlaceholder="Search" style={{textAlign:'center'}} header="Дата прибуття" />
                    <Column sortable={true} field="country.name" filter={true} filterMatchMode="contains" filterPlaceholder="Search" style={{textAlign:'center'}} header="Країна" />
                    <Column sortable={true} field="countOfPlaces" filter={true} filterMatchMode="contains" filterPlaceholder="Search" style={{textAlign:'center'}} header="Кількість місць" />
                    <Column sortable={true} field="price" filter={true} filterMatchMode="contains" filterPlaceholder="Search" style={{textAlign:'center'}} header="Ціна" />
                </DataTable>
            </Card>
        );
    }
}

const mapStateToProps = state => {
    return {
        listBoughtTickets: get(state, 'boughtTickets.list.data'),
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        getBoughtTicketsData: filter => {
            dispatch(getListActions.getBoughtTicketsData(filter));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(BoughtTickets);
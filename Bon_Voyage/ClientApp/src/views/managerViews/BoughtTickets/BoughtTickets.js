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
    // onDateFilterChange = (event) => {
    //     console.log("Format ", this.formatDate(event.value));
    //     if (event.value !== null)
    //         this.dt.filter(this.formatDate(event.value), 'date', 'equals');
    //     else
    //         this.dt.filter(null, 'date', 'equals');

    //     this.setState({dateFilter: event.value});   
    // }

    // filterDate = (value, filter) => {
    //     console.log("Filter", this.filterDate(value.filter));
    //     if (filter === undefined || filter === null || (typeof filter === 'string' && filter.trim() === '')) {
    //         return true;
    //     }

    //     if (value === undefined || value === null) {
    //         return false;
    //     }
       
    //     return value === this.formatDate(filter);
    // }

    // formatDate = (date) => {
    //     let month = date.getMonth() + 1;
    //     let day = date.getDate();

    //     if (month < 10) {
    //         month = '0' + month;
    //     }

    //     if (day < 10) {
    //         day = '0' + day;
    //     }
    //     return day + '.' + month + '.' + date.getFullYear();
    // }
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
                    <Column field="dateTo" header="Date" sortable filter filterMatchMode="custom" filterFunction={this.filterDate} filterElement={dateFilter} />            
                    {/* <Column sortable={true} field="dateFrom" header="Дата повернення" filter={true} sortable filter filterMatchMode="contains" style={{textAlign:'center'}} filterFunction={this.filterDate} filterElement={dateFilter} /> */}
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
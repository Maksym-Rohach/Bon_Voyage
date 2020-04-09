import React, { Component } from 'react';
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Card } from 'primereact/card';

class BoughtTickets extends Component {
    state = {
    }

    componentDidMount = () => {
        this.props.getBoughtTicketsData();
    }

    render() {

        const { listBoughtTickets } = this.props;
        console.log("render", listBoughtTickets);

        return (
            <Card className="mt-5">
                <DataTable value={listBoughtTickets}>
                    <Column sortable={true} field="client.fullName" header="Ім'я покупця" />
                    <Column sortable={true} field="dateFrom" header="Дата вильоту" />
                    <Column sortable={true} field="dateTo" header="Дата повернення" />
                    <Column sortable={true} field="country.name" header="Країна" />
                    <Column sortable={true} field="countOfPlaces" header="Кількість місць" />
                    <Column sortable={true} field="price" header="Ціна" />
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
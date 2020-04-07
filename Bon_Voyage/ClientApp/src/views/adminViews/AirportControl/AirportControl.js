import React, { Component, useState } from 'react';
import * as getAirportListActions from "./reducer";
import * as getCountryListActions from "./reducer"
import { connect } from 'react-redux';
import get from "lodash.get";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import {Dropdown} from 'primereact/dropdown';
import { Form } from 'reactstrap';
class AirportControl extends Component {
    state = {
        cityId: "",
        countryId: "",
        name: "",
        shortName: "",
        countries: []
    }
    isSelectCities = true;
    componentDidMount = () => {
        this.props.getAirportControlData();
        this.props.getCountries();
    }

    selectCountry = (countryId) =>{
        this.isSelectCities=false;
    }

    submitForm = () =>{
        let model = {
            name: this.state.name,
            shortName: this.state.shortName,
            cityId: this.state.cityId
        }
        this.props.createAirport(model);
    }
    render() {
        const { listAirports } = this.props;
        const { listCountries} = this.props;
        console.log(listCountries);
        let cities=[
            {label: 'Moskow',Id: "1"}
        ]
        
        let countries=[
            {label:null,value:null}        
        ]
        listCountries.forEach(element => {
            countries.push({label: element.name,value:element.id})
        });

        return (
            <div>
                <DataTable small value={listAirports}>
                    <Column field="name" header="Ім'я" sortable={true} />
                    <Column field="shortName" header="Коротке ім'я" sortable={true} />
                    <Column field="cityName" header="Назва міста" sortable={true} />
                </DataTable>
                <Dialog header="Додавання аеропорту" position="right" visible={this.state.visible} style={{ width: '50vw' }} modal={true} onHide={() => this.setState({ visible: false })}>
                    <Form  style={{ height: '20vw' }}>
                        <Dropdown style={{ margin: '1rem' }} value={this.state.countryId} options={countries} onChange={(e) => {this.selectCountry(e.value)}} placeholder="Виберіть країну" />
                        <Dropdown disabled={this.isSelectCities} style={{ margin: '1rem' }} value={this.state.cityId} options={cities} onChange={(e) => {this.setState({cityId: e.value   })}} placeholder="Виберіть місто"/>

                         <span style={{ margin: '1rem' }} className="p-float-label">
                            <InputText id="in" type="text" value={this.state.name} onChange={(e) => this.setState({ name: e.target.value })} />
                            <label htmlFor="in">Ім'я аеропорту</label>
                        </span>
                        <span style={{ margin: '1rem' }} className="p-float-label">
                            <InputText id="in" value={this.state.shortName} onChange={(e) => this.setState({ shortName: e.target.value })} />
                            <label htmlFor="in">Коротке ім'я аеропорту</label>
                        </span>
                    <Button label="Додати" style={{ margin: '1rem' }} color="secondary"></Button>
                    </Form>
                </Dialog>
                <Button label="Додати аеропорт" className="p-button-secondary btn-block p-button-raised" onClick={(e) => this.setState({ visible: true })} />
            </div>
        );
    }
}



const mapStateToProps = state => {
    return {
        listAirports: get(state, 'airports.list.data'),
        listCountries: get(state, 'countries.list.data'),
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        getAirportControlData: filter => {
            dispatch(getAirportListActions.getAirportControlData(filter));
        },
        getCountries: filter => {
            dispatch(getCountryListActions.getCountries(filter));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(AirportControl);
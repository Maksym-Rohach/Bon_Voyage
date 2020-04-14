import React, { Component, useState } from 'react';
import * as getAirportListActions from "./reducer";
import * as getCitiesListActions from "./reducer";
import * as createAirportListActions from "./reducer";
import { connect } from 'react-redux';
import get from "lodash.get";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { Dropdown } from 'primereact/dropdown';
import {Growl} from 'primereact/growl';
import { Form } from 'reactstrap';
class AirportControl extends Component {
    state = {
        cityId: undefined,
        countryId: null,
        name: undefined,
        shortName: undefined,
        isSelectCities: true,
        visible: false,
        errorsList: {},
        refreshForm: false
    }
    initialState = {
        cityId: undefined,
        countryId: null,
        name: undefined,
        shortName: undefined,
        isSelectCities: true,
        visible: false,
        errorsList: {},
        refreshForm: false
    }
    componentWillMount = () => {
        this.props.getAirportControlData();
    }

    componentWillReceiveProps = (nextProps) => {
        if(nextProps!==this.props){
            this.setState({errorsList: nextProps.errorsList});
        }
    }

    selectCountry = (e) => {
        this.setState({ isSelectCities: false })
        this.setState({ countryId: e.value });
        this.props.getCitiesByCountry(e.value);
    }

    selectCity = (e) => {
        this.setState({ cityId: e.value });
        this.state.cityId = e.value;
    }

    submitForm = (e) => {
        e.preventDefault();
        if (this.state.cityId === undefined) {
            this.setState({ errorsList: { errorMessage: "Оберіть будь ласка місто" } });
        }
        else if (this.state.name === undefined || this.state.name === "" || this.state.shortName === undefined || this.state.shortName === "") {
            this.setState({ errorsList: { errorMessage: "Заповніть будь ласка всі поля" } });
        }
        else {
            let model = {
                name: this.state.name,
                shortName: this.state.shortName,
                cityId: this.state.cityId
            }
            this.props.createAirport(model);
            this.setState({visible: false});
        }

    }

    dialogHide=(e)=>{
        this.setState({ visible: false });
    }

    clear = () => {        
        this.state = this.initialState;
    }

    render() {
        let { errorsList } = this.props;
        if (errorsList === undefined) {
            errorsList = this.state.errorsList;
        }

        let cities = [
            { label: '', value: '' }
        ]
        if (this.props.listCities !== undefined) {
            this.props.listCities.forEach(element => {
                cities.push({ label: element.name, value: element.id });
            });
        }
        let countries = []
        if (this.props.listAirportsData.countries !== undefined) {
            this.props.listAirportsData.countries.forEach(element => {
                countries.push({ label: element.name, value: element.id });
            });
        }
        return (
            <div>
                <DataTable small value={this.props.listAirportsData.airports}>
                    <Column field="name" header="Ім'я" sortable={true} />
                    <Column field="shortName" header="Коротке ім'я" sortable={true} />
                    <Column field="cityName" header="Назва міста" sortable={true} />
                </DataTable>
                <Dialog header="Додавання аеропорту" position="right" visible={this.state.visible} style={{ width: '50vw' }} modal={true} onHide={ e => this.dialogHide(e) }>
                    <Form onSubmit={(e) => { this.submitForm(e) }} style={{ height: '15vw' }}>
                        <Dropdown style={{ margin: '1rem' }}
                            value={this.state.countryId}
                            options={countries}
                            onChange={(e) => { this.selectCountry(e) }} placeholder="Виберіть країну"
                        />
                        <Dropdown
                            disabled={this.state.isSelectCities} style={{ margin: '1rem' }} value={this.state.cityId}
                            options={cities}
                            onChange={(e) => { this.selectCity(e) }}
                            placeholder="Виберіть місто"
                        />
                        <span style={{ margin: '1rem' }} className="p-float-label">
                            <InputText id="in" type="text" value={this.state.name} onChange={(e) => this.setState({ name: e.target.value })} />
                            <label htmlFor="in">Ім'я аеропорту</label>
                        </span>
                        <span style={{ margin: '1rem' }} className="p-float-label">
                            <InputText id="in" value={this.state.shortName} onChange={(e) => this.setState({ shortName: e.target.value })} />
                            <label htmlFor="in">Коротке ім'я аеропорту</label>
                        </span>
                        {!!errorsList?
                        <label style={{ color: 'red', padding: '0.1rem 1rem' }}>{errorsList.errorMessage}</label>:
                        <label></label>}
                        <div>
                            <Button label="Додати" style={{ margin: '1rem' }} color="secondary"></Button>
                        </div>
                    </Form>
                </Dialog>
                <Button label="Додати аеропорт" className="p-button-primary btn-block p-button-raised" onClick={(e) => this.setState({ visible: true })} />
                <Growl/>
            </div>
        );
    }
}



const mapStateToProps = state => {
    return {
        listAirportsData: get(state, 'airports.list.data'),
        listCities: get(state, 'airports.cities.data'),
        errorsList: get(state, 'airports.list.errors'),
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        getAirportControlData: filter => {
            dispatch(getAirportListActions.getAirportControlData(filter));
        },
        getCitiesByCountry: (countryId) => {
            dispatch(getCitiesListActions.getCitiesByCountry(countryId));
        },
        createAirport: (model) => {
            dispatch(createAirportListActions.createAirport(model));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(AirportControl);
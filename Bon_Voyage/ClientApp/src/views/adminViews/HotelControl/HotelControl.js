import React, { Component } from 'react';
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import {DataTable} from 'primereact/datatable';
import {Column} from 'primereact/column';
import {Button} from 'primereact/button';
import {Dialog} from 'primereact/dialog';
import Modal from '@trendmicro/react-modal';
import '@trendmicro/react-modal/dist/react-modal.css';
import {Label, Input, InputGroup, Table} from 'reactstrap';
import {Dropdown} from 'primereact/dropdown';
import { findByLabelText } from '@testing-library/react';
import {InputTextarea} from 'primereact/inputtextarea';

class HotelControl extends Component {
    state = { 
        display: false,
        displayEach: false,
        country: null,
        countries: [],
        city: null,
        cities: []
     }

    componentDidMount = () => {
      this.props.getHotelControlData();
    }

    
    onCountryChange = (e) => {
      this.setState({ country: e.value });
      this.props.getCityData(e.value.id);
    };
    
    onCityChange = (e) => {
      this.setState({ city: e.value });
    };
    
    componentWillMount = () => {
      this.props.getCountryData();
    }
    
    
    componentWillReceiveProps = (nextProps) => { //- Binding     
      if(nextProps != this.props){
        this.setState({
          countries : nextProps.countryReducer,
          cities : nextProps.cityReducer
        });
      }
    }
    actionTemplate(rowData, column) {
      return <div>
        <Button type="button" icon="pi pi-cog" className="p-button-secondary p-button-rounded"></Button>     
      </div>;
    }


    render() { 
        const hotelStars = [
            {label: '1*', value: 1},
            {label: '2*', value: 2},
            {label: '3*', value: 3},
            {label: '4*', value: 4},
            {label: '5*', value: 5}
        ];
        const { listHotels }= this.props;
        console.log("render",listHotels);
        var dialogFooter = (
            <div>
                <Button label="Зберегти" icon="pi pi-check" onClick={this.onHide} />
                <Button label="Відмінити" icon="pi pi-times" onClick={this.onHide} />
            </div>
        );
        var header = <div className="p-clearfix" style={{'lineHeight':'1.87em'}}>
            Список готелів
            <Dialog header="Додати новий готель" footer={dialogFooter} style={{maxWidth:'70%'}} visible={this.state.display} modal={true} onHide={() => this.setState({display:false})}>
                <Table>
                    <tr>
                        <td>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Назва</Label>
                                <Input style={{width:'100%'}} type="text"/>
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Кількість зірок</Label>
                                <Dropdown options={hotelStars}/>
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Опис</Label>
                                <InputTextarea rows={5} cols={30} value={this.state.value} onChange={(e) => this.setState({value: e.target.value})} autoResize={true} />
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Країна</Label>
                                <Dropdown
                                value={this.state.country}
                                options={this.state.countries}
                                onChange={(e) => this.onCountryChange(e)}
                                optionLabel="name"/>
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Місто</Label>
                                <Dropdown
                                value={this.state.city}
                                options={this.state.cities}
                                onChange={(e) => this.onCityChange(e)}
                                optionLabel="name"/>
                            </InputGroup>
                        </td>
                        <td>
                            <img style={{width:'20em', height:'20em'}} src='/src/assets/img/addimage.png'></img>
                        </td>
                    </tr>
                </Table>
            </Dialog>
            <Button icon="pi pi-plus" style={{'float':'right'}} onClick={() => this.setState({display: true})}/>
            </div>;

        return ( 
          <div>
            <DataTable value={listHotels} header={header}>
            <Column field="name" header="Назва" />
            <Column field="stars" header="Кількість *" />
            <Column field="city.name" header="Місто" />
            <Column field="isClosed" header="Працює" />
            <Column header="Змінити" body={this.actionTemplate.onClick} onClick={() => this.setState({displayEach: true})} style={{textAlign:'center', width: '6em'}}/>
        </DataTable>
        <Dialog header="Змінити існуючий готель" footer={dialogFooter} style={{maxWidth:'70%'}} visible={this.state.displayEach} modal={true} onHide={() => this.setState({displayEach:false})}>
                <Table>
                    <tr>
                        <td>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Назва</Label>
                                <Input style={{width:'100%'}} type="text"/>
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Кількість зірок</Label>
                                <Dropdown options={hotelStars}/>
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Опис</Label>
                                <InputTextarea rows={5} cols={30} value={this.state.value} onChange={(e) => this.setState({value: e.target.value})} autoResize={true} />
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Країна</Label>
                                <Dropdown
                                value={this.state.country}
                                options={this.state.countries}
                                onChange={(e) => this.onCountryChange(e)}
                                optionLabel="name"/>
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Місто</Label>
                                <Dropdown
                                value={this.state.city}
                                options={this.state.cities}
                                onChange={(e) => this.onCityChange(e)}
                                optionLabel="name"/>
                            </InputGroup>
                        </td>
                        <td>
                            <img style={{width:'20em', height:'20em'}} src='/src/assets/img/addimage.png'></img>
                        </td>
                    </tr>
                </Table>
            </Dialog>
        </div>
         );
    }
}

const mapStateToProps = state => {
    return {
        listHotels: get(state, 'hotels.list.data'), 
        countryReducer: get(state,'addHotel.countries'),
        cityReducer: get(state,'addHotel.cities'),
    };
  }

  const mapDispatchToProps = (dispatch) => {
    return {
        getHotelControlData: filter => {
        dispatch(getListActions.getHotelControlData(filter));
      },
      addHotel: (hotel) => {
        dispatch(getListActions.addHotel(hotel));
      },
      getCountryData: () => {
        dispatch(getListActions.getCountryData());
      },
      getCityData: (countryId) => {
        dispatch(getListActions.getCityData(countryId));
      },
    }
  }
 
export default connect(mapStateToProps, mapDispatchToProps) (HotelControl);
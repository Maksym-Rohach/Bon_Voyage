import React, { Component } from 'react';
import * as reducer from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import {DataTable} from 'primereact/datatable';
import {Column} from 'primereact/column';
import {Button} from 'primereact/button';
import {Dialog} from 'primereact/dialog';
import Modal from '@trendmicro/react-modal';
import '@trendmicro/react-modal/dist/react-modal.css';
import {Label, Input, InputGroup, Table, Form} from 'reactstrap';
import {Dropdown} from 'primereact/dropdown';
import { findByLabelText } from '@testing-library/react';
import {InputTextarea} from 'primereact/inputtextarea';

class HotelControl extends Component {
    state = { 
        display: false,
        displayEach: false,
        name:undefined,
        stars:1,
        description:undefined,
        isClosed:false,
        country: undefined,
        countries: [],
        city: undefined,
        cities: [],
        errors:{}
     }

     defaultState={
      name:undefined,
      stars:1,
      description:undefined,
      isClosed:false,
      errors:{},
      display:false,
    }

    dialogHide = (e) => {
      this.setState({ display: false });
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

    submitForm=(e)=>{
      let isValid=true;
      let validErrors={};
      e.preventDefault();
      if(this.state.name===undefined||this.state.name===""){
        isValid=false;
        validErrors.name="Це поле має бути заповнено";
      }
      if(this.state.description===undefined||this.state.description===""){
        isValid=false;
        validErrors.description="Це поле має бути заповнено";
      }
      if(this.state.city===undefined||this.state.city===""){
        isValid=false;
        validErrors.city="Це поле має бути заповнено";
      }
      if(this.state.country===undefined||this.state.country===""){
        isValid=false;
        validErrors.country="Це поле має бути заповнено";
      }
      if(this.state.stars===0){
        isValid=false;
        validErrors.country="Це поле має бути заповнено";
      }
      if(this.state.isClosed===null){
        isValid=false;
        validErrors.country="Це поле має бути заповнено";
      }
      
      if(isValid){
        let model={
          name:this.state.name,
          stars:this.state.stars,
          description:this.state.description,
          isClosed:this.state.isClosed,
          city:this.state.city
        };
        this.props.addHotel(model);
      }
      else{
        this.setState({errors:validErrors});
        this.state.errors=validErrors;
        console.log(this.state.errors);
      }
    }

    clear=()=>
  {
    this.setState(this.defaultState);
    this.props.clearErrors();
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
        let {errors} = this.props;
    if(errors===undefined){
      if(this.state.errors===undefined){
        this.clear();
      }
      else{
        errors=this.state.errors;
      }
    }
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
                          <Form onSubmit={(e) => { this.submitForm(e) }}>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Назва</Label>
                                <Input style={{width:'100%'}} 
                                type="text" 
                                name="name" 
                                value={this.state.name} 
                                onChange={(e)=>{this.setState({name: e.target.value})}}/>
                                {!!errors.name ? <div className="invalid-feedback">{errors.name}</div> : ""}
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Кількість зірок</Label>
                                <Dropdown options={hotelStars}
                                value={this.state.stars}
                                name="stars"
                                onChange={(e)=>{this.setState({stars: e.target.value})}}/>
                                {!!errors.stars ? <div className="invalid-feedback">{errors.stars}</div> : ""}
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Опис</Label>
                                <InputTextarea rows={5} cols={30} 
                                value={this.state.description} 
                                name="description"
                                onChange={(e) => this.setState({description: e.target.value})} autoResize={true} />
                                {!!errors.description ? <div className="invalid-feedback">{errors.description}</div> : ""}
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Країна</Label>
                                <Dropdown
                                value={this.state.country}
                                options={this.state.countries}
                                onChange={(e) => this.onCountryChange(e)}
                                name="country"/>
                                {!!errors.country ? <div className="invalid-feedback">{errors.country}</div> : ""}
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Місто</Label>
                                <Dropdown
                                value={this.state.city}
                                options={this.state.cities}
                                onChange={(e) => this.onCityChange(e)}
                                name="city"/>
                                {!!errors.country ? <div className="invalid-feedback">{errors.country}</div> : ""}
                            </InputGroup>
                            </Form>
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
        </DataTable>
        </div>
         );
    }
}

const mapStateToProps = state => {
    return {
        listHotels: get(state, 'hotels.list.data'), 
        countryReducer: get(state,'addHotel.countries'),
        cityReducer: get(state,'addHotel.cities'),
        errors: get(state, 'hotels.createRespone.errors')
    };
  }

  const mapDispatchToProps = (dispatch) => {
    return {
        getHotelControlData: filter => {
        dispatch(reducer.getHotelControlData(filter));
      },
      addHotel: (hotel) => {
        dispatch(reducer.addHotel(hotel));
      },
      getCountryData: () => {
        dispatch(reducer.getCountryData());
      },
      getCityData: (countryId) => {
        dispatch(reducer.getCityData(countryId));
      },
      clearErrors: () => {
        dispatch(reducer.clearErrors());
      }
    }
  }
 
export default connect(mapStateToProps, mapDispatchToProps) (HotelControl);
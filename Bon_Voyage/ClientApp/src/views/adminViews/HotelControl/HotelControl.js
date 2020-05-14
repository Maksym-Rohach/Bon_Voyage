import React, { Component } from 'react';
import * as reducer from './reducer';
import * as getCitiesListActions from "./reducer";
import * as addHotelListActions from "./reducer";
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
        name:undefined,
        stars:1,
        description:undefined,
        isClosed:false,
        cityId: undefined,
        countryId: null,
        isSelectCities: true,
        errors:{}
     }

     defaultState = () => {
      return {
        name:undefined,
        stars:1,
        description:undefined,
        isClosed:false,
        cityId: undefined,
        countryId: null,
        isSelectCities: true,
        errors:{}
      }

    }

    componentWillMount = () => {
      this.props.getHotelControlData();
    }

    componentWillReceiveProps = (nextProps) => { //- Binding     
      if (nextProps !== this.props) {
        this.setState({ errorsList: nextProps.errorsList });
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
      if(this.state.cityId===undefined||this.state.cityId===""){
        isValid=false;
        validErrors.cityId="Це поле має бути заповнено";
      }
      if(this.state.countryId===null||this.state.countryId===""){
        isValid=false;
        validErrors.countryId="Це поле має бути заповнено";
      }
      if(this.state.stars===0){
        isValid=false;
        validErrors.stars="Це поле має бути заповнено";
      }
      if(this.state.isClosed===null){
        isValid=false;
        validErrors.isClosed="Це поле має бути заповнено";
      }
      
      if(isValid){
        let model={
          name:this.state.name,
          stars:this.state.stars,
          description:this.state.description,
          isClosed:this.state.isClosed,
          cityId:this.state.cityId
        };
        this.props.addHotel(model);
      }
      else{
        this.setState({errors:validErrors});
        this.state.errors=validErrors;
        console.log(this.state.errors);
      }
    }

    dialogHide = (e) => {
      this.setState({ visible: false });
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
    let cities = [
      { label: '', value: '' }
  ]
  if (this.props.listCities !== undefined) {
      this.props.listCities.forEach(element => {
          cities.push({ label: element.name, value: element.id });
      });
  }
  let countries = []
  if (this.props.listHotels.countries !== undefined) {
      this.props.listHotels.countries.forEach(element => {
          countries.push({ label: element.name, value: element.id });
      });
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
            <Dialog header="Додати новий готель" style={{maxWidth:'70%'}} visible={this.state.display} modal={true} onHide={() => this.setState({display:false})}>
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
                                value={this.state.countryId}
                                options={countries}
                                onChange={(e) => { this.selectCountry(e) }}
                                name="country"/>
                                {!!errors.country ? <div className="invalid-feedback">{errors.country}</div> : ""}
                            </InputGroup>
                            <InputGroup style={{display:'flex', flexDirection:'column'}}>
                                <Label>Місто</Label>
                                <Dropdown
                                disabled={this.state.isSelectCities}
                                value={this.state.cityId}
                                options={cities}
                                onChange={(e) => { this.selectCity(e) }}
                                name="city"/>
                                {!!errors.country ? <div className="invalid-feedback">{errors.country}</div> : ""}
                            </InputGroup>


                    <Button label="Додати" style={{ margin: '1rem' }} color="secondary"></Button>

              </Form>
            </Dialog>
            <Button icon="pi pi-plus" style={{'float':'right'}} onClick={() => this.setState({display: true})}/>
            </div>;

        return ( 
          <div>
            <DataTable value={this.props.listHotels.hotels} header={header}>
            <Column field="name" header="Назва" sortable={true}/>
            <Column field="stars" header="Кількість *" sortable={true}/>
            <Column field="city.name" header="Місто" sortable={true}/>
            <Column field="isClosed" header="Працює" sortable={true}/>
        </DataTable>
        </div>
         );
    }
}

const mapStateToProps = state => {
    return {
        listHotels: get(state, 'hotels.list.data'), 
        listCities: get(state, 'airports.cities.data'),
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
      getCitiesByCountry: (countryId) => {
        dispatch(getCitiesListActions.getCitiesByCountry(countryId));
      },
      clearErrors: () => {
        dispatch(reducer.clearErrors());
      }
    }
  }
 
export default connect(mapStateToProps, mapDispatchToProps) (HotelControl);
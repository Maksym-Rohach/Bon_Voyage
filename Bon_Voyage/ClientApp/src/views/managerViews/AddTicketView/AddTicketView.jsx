import React, { Component } from "react";
import { InputText } from "primereact/inputtext";
import { InputMask } from "primereact/inputmask";
import { InputSwitch } from "primereact/inputswitch";
import { Dropdown } from "primereact/dropdown";
import { Growl } from "primereact/growl";
import { Button } from "primereact/button";
import { ProgressSpinner } from "primereact/progressspinner";
import { MultiSelect } from "primereact/multiselect";
import { Calendar } from "primereact/calendar";



import get from "lodash.get";
import { connect } from "react-redux";
import * as reducer from "./reducer";

class AddTicket extends Component {
  state = {
    country: null,
    countries: [],

    airport: null,
    airports: [],

    city: null,
    cities: [],

    hotel: null,
    hotels: [],

    roomType: null,
    roomTypes: [],

    comfortsSelected: [],
    comforts: [],

    percentState: false,
    percent: null,
    percents: [
      { percent: "5%", value: 5 },
      { percent: "10%", value: 10 },
      { percent: "15%", value: 15 },
      { percent: "20%", value: 20 },
      { percent: "25%", value: 25 },
      { percent: "30%", value: 30 },
      { percent: "35%", value: 35 },
      { percent: "40%", value: 40 },
      { percent: "45%", value: 45 },
      { percent: "50%", value: 50 },
      { percent: "55%", value: 55 },
      { percent: "60%", value: 60 },
      { percent: "65%", value: 65 },
      { percent: "70%", value: 70 },
      { percent: "75%", value: 75 },
      { percent: "80%", value: 80 },
      { percent: "85%", value: 85 },
      { percent: "90%", value: 90 },
      { percent: "95%", value: 95 },
      { percent: "100%", value: 100 },
    ],

    isLoad: false,
    isSuccess:false,
    isFailed:false,
    minDate: null,
    errors:{
      priceFrom:"",
      countsOfNight:"",
      dateFrom:"",
      dateTo:"",
      countOfPlaces:"",
      country:"",
      airport:"",
      city:"",
      hotel:"",
      roomType:"",
    },
    fields:{
      priceFrom:"",
      countsOfNight:"",
      dateFrom:"",
      dateTo:"",
      countOfPlaces:"",
      discount:"",
    },
    growlError:"",
  };



  //------------------------CHANGE--------------------------

  onCountryChange = (e) => {
    this.setState({ country: e.value });
    this.props.getAirportData(e.value.id);
    this.props.getCityData(e.value.id);
    this.props.getHotelData(0);
  };

  onAirportChange = (e) => {
    this.setState({ airport: e.value });
  };

  onCityChange = (e) => {
    this.setState({ city: e.value });
    this.props.getHotelData(e.value.id);
  };

  onHotelChange = (e) => {
    this.setState({ hotel: e.value });
  };

  onRoomTypeChange = (e) => {
    this.setState({ roomType: e.value });
  };

  onDateFromChange = (e) => {    
    this.state.fields.dateFrom = this.assemblyDate(e.value);
  }

  onDateToChange = (e) => {
    
    this.state.fields.dateTo = this.assemblyDate(e.value);
  }

  //-------------------------Other-------------------------------

  assemblyDate = (date) => {
    let myDate = new Date(date);
    let res = "";
    console.log(myDate);
    myDate.getDate() < 10 ? res+= '0' + myDate.getDate() : res += myDate.getDate();
    res += '.';
    myDate.getMonth() < 10 ? res+= '0' + (myDate.getMonth()+1) : res += (myDate.getMonth()+1);
    res += '.';
    res += myDate.getFullYear();

    console.log(res);
    return res;
  }

  //-------------------------SHOW--------------------------------

  showSuccess() {
    this.setState({isSuccess:false});
    this.growl.show({
      severity: "success",
      summary: "Квиток створенний",
      life:10000
    });
    this.props.clearTicketState();
  }

  showError() {
    this.setState({isFailed:false});
    this.growl.show({
      severity: "error",
      summary: "Помилка",
      detail: this.state.growlError,
      life:8000
    });
    this.props.clearTicketState();
  }

  //-------------------------Validation--------------------------------

  onSubmit = (e) => {
    e.preventDefault();
    if (this.validation()) {
      this.props.addTicket(this.assemblyModel());
    }
  };

  clear = () => {
    this.setState({
      errors:{
        priceFrom:"",
        countsOfNight:"",
        dateFrom:"",
        dateTo:"",
        countOfPlaces:"",
        country:"",
        airport:"",
        city:"",
        hotel:"",
        roomType:""
      },
      fields:{
        priceFrom:"",
        countsOfNight:"",
        dateFrom:"",
        dateTo:"",
        countOfPlaces:"",
        discount:"",
      }, 
      
      country: null,
      countries: [],
  
      airport: null,
      airports: [],
  
      city: null,
      cities: [],
  
      hotel: null,
      hotels: [],
  
      roomType: null,
      roomTypes: [],
  
      comfortsSelected: [],
      comforts: [],

      percentState: false,
      percent: null,
    });
    document.getElementById("mainForm").reset();

    // this.props.clearTicketState();
    this.props.getCountryData();
    this.props.getRoomTypeData();
    this.props.getComfortData(); 


    setTimeout(() => { this.setState({
      airports: [],
  
      cities: [],
  
      hotels: [],
  
      percentState: false,
      percent: null,
    }); }, 700);

    
  };

  validation = () => {
    let flag = true;
    let errors = {
      priceFrom:"",
      countsOfNight:"",
      dateFrom:"",
      dateTo:"",
      countOfPlaces:"",
      country:"",
      airport:"",
      city:"",
      hotel:"",
      roomType:"",
      comforts:""
    }

    const {
      priceFrom,
      countsOfNight,
      dateFrom,
      dateTo,
      countOfPlaces,
      } = this.state.fields;

    const {
      country,
      airport,
      city,
      hotel,
      roomType
    } = this.state;

    if(priceFrom == '')
    {
      flag = false;
      errors.priceFrom = "Введіть початкову ціну";
    }
    if(countsOfNight == '')
    {
      flag = false;    
      errors.countsOfNight = "Введіть кількість ночей";
    }
    if(dateFrom == '')
    {
      flag = false;
      errors.dateFrom = "Введіть дату відльоту";
    }
    if(dateTo == '')
    {
      flag = false;
      errors.dateTo = "Введіть дату прильоту";
    }
    if(countOfPlaces == '')
    {
      flag = false;
      errors.countOfPlaces = "Введіть кількість місць";
    }
    if(country == null)
    {
      flag = false;
      errors.country = "Виберіть країну";
    }
    if(airport == null)
    {
      flag = false;
      errors.airport = "Виберіть аеропорт";
    }
    if(city == null)
    {
      flag = false;
      errors.city = "Виберіть місто";
    }
    if(hotel == null)
    {
      flag = false;
      errors.hotel = "Виберіть готель";
    }
    if(roomType == null)
    {
      flag = false;
      errors.roomType = "Виберіть тип кімнати";
    }


    this.setState({errors: errors});
    return flag;
  };

  assemblyModel = () => {
    let {
      priceFrom,
      countsOfNight,
      dateFrom,
      dateTo,
      countOfPlaces,
    } = this.state.fields;
    let {
      airport,
      hotel,
      roomType,
      comfortsSelected,
      percent,
    } = this.state;

    if(percent == undefined || percent == null){
      percent = 0;
    }

    let model = {
      priceFrom: priceFrom,
      countsOfNight: countsOfNight,
      dateFrom: dateFrom.toString(),
      dateTo: dateTo.toString(),
      countsOfPlaces: countOfPlaces,
      discount: percent,
      hotelId: hotel.id,
      airportId: airport.id,
      roomTypeId: roomType.id,
      comfortsId: comfortsSelected.map(a => a.id)
    }
    console.log(model);
    return model;
  };


  //-------------------------Redux--------------------------------



  //3
  // Call reducer
  componentWillMount = () => {
    this.props.getCountryData();
    this.props.getRoomTypeData();
    this.props.getComfortData();

    let today = new Date();
    let month = today.getMonth();
    let year = today.getFullYear();
    let minDate = new Date();
    minDate.setMonth(month);
    minDate.setFullYear(year);

    this.setState({minDate:minDate});
  }


  componentWillReceiveProps = (nextProps) => { //- Binding     
    if(nextProps != this.props){
      this.setState({
        countries : nextProps.countryReducer,
        airports : nextProps.airportReducer,
        cities : nextProps.cityReducer,
        hotels : nextProps.hotelReducer,
        roomTypes : nextProps.roomTypeReducer,
        comforts : nextProps.comfortReducer,
        isLoad : nextProps.ticketReducer.loading,
        isSuccess:nextProps.ticketReducer.success,
        isFailed: nextProps.ticketReducer.failed,
        growlError: nextProps.ticketReducer.errors.errorMessage,
      });
    }
  }



  render() {
    const { isLoad,errors,isSuccess,isFailed,minDate } = this.state;

    if (isSuccess) {
      this.showSuccess();
      this.clear();
    }
    if(isFailed){
      this.showError();
    }

    return (
      <div className="mt-3 container">
        <Growl ref={(el) => (this.growl = el)} style={{ marginTop: "3rem" }} />

        <h3 style={{ fontSize: "2.3rem" }}>Сворити квиток</h3>

        <div className="card p-2 " style={{ background: "#f7f1e3" }}>
          <form
            id="mainForm"
            onSubmit={this.onSubmit}
            className="row flex-row d-flex justify-content-between"
          >
            <div className="card m-3 p-2 col-sm">
              <h6>Початкова ціна</h6>
              <div
                className={
                  errors.priceFrom == ""
                    ? "input-group mb-3"
                    : "input-group mb-2"
                }
              >
                <div className="input-group-prepend">
                  <span className="input-group-text">₴</span>
                </div>
                <input
                  type="number"
                  min="0"
                  className={
                    errors.priceFrom == ""
                      ? "form-control"
                      : "form-control is-invalid"
                  }
                  aria-label="Amount (to the nearest dollar)"
                  onChange={(e) =>
                    (this.state.fields.priceFrom = e.target.value)
                  }
                />
                <div className="input-group-append">
                  <span className="input-group-text">.00</span>
                </div>
                <div
                  className="invalid-feedback"
                  style={{ fontSize: "0.8rem", fontWeight: "500" }}
                >
                  {errors.priceFrom}
                </div>
              </div>

              <h6>Кількість ночей</h6>
              <InputText
                className={
                  errors.countsOfNight == "" ? "mb-3" : "is-invalid p-error"
                }
                type="text"
                keyfilter="pint"
                onChange={(e) =>
                  (this.state.fields.countsOfNight = e.target.value)
                }
              />
              <div
                className="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >
                {errors.countsOfNight}
              </div>

              <h6>Дата відльоту</h6>              
              <div>
                <Calendar
                    dateFormat="dd/mm/yy"
                  readOnlyInput={true}
                  style={{ width: "100%" }}
                  inputStyle={{ minWidth: "100%" }}
                  minDate={minDate}
                  placeholder="Ведіть дату"
                  onSelect ={(e) => this.onDateFromChange(e)}
                  className={
                    errors.dateFrom == "" ? "mb-3" : "is-invalid p-error"
                  }
                  showButtonBar={true}
                />
                <div
                  className="invalid-feedback mb-2"
                  style={{ fontSize: "0.8rem", fontWeight: "500" }}
                >
                  {errors.dateFrom}
                </div>
              </div>

              <h6>Дата прильоту</h6>
              <div>
              <Calendar
                  dateFormat="dd/mm/yy"
                  readOnlyInput={true}
                  style={{ width: "100%" }}
                  inputStyle={{ minWidth: "100%" }}
                  minDate={minDate}
                  placeholder="Ведіть дату"
                  onSelect ={(e) => this.onDateToChange(e)}
                  className={
                    errors.dateTo == "" ? "mb-3" : "is-invalid p-error"
                  }
                  showButtonBar={true}
                />
                <div
                  className="invalid-feedback mb-2"
                  style={{ fontSize: "0.8rem", fontWeight: "500" }}
                >
                  {errors.dateTo}
                </div>
              </div>

              <h6>Кількість місць</h6>
              <InputText
                className={
                  errors.countOfPlaces == "" ? "mb-3" : "is-invalid p-error"
                }
                type="text"
                keyfilter="pint"
                onChange={(e) =>
                  (this.state.fields.countOfPlaces = e.target.value)
                }
              />
              <div
                className="invalid-feedback mb-3"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >
                {errors.countOfPlaces}
              </div>

              <h6>Знижка</h6>
              <div className="d-flex flex-row">
                <InputSwitch
                  tooltip="Додати знижку"
                  tooltipOptions={{ position: "top" }}
                  className="mt-1 mr-3"
                  checked={this.state.percentState}
                  onChange={(e) => this.setState({ percentState: e.value })}
                />
                <Dropdown
                  value={this.state.percent}
                  options={this.state.percents}
                  onChange={(e) => this.setState({ percent: e.value })}
                  placeholder="Виберіть знижку"
                  optionLabel="percent"
                  style={{ width: "12em" }}
                  disabled={!this.state.percentState}
                  className="mb-2"
                />
              </div>
            </div>

            {/*-----------------2------------------  */}

            <div className="card m-3 p-2 col-sm">
              <h6>Країна</h6>
              <Dropdown
                value={this.state.country}
                options={this.state.countries}
                onChange={(e) => this.onCountryChange(e)}
                placeholder="Виберіть країну"
                optionLabel="name"
                style={{ width: "100%" }}
                className={errors.country == "" ? "mb-3" : "is-invalid p-error"}
              />
              <div
                className="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >
                {errors.country}
              </div>

              <h6>Аеропорт </h6>
              <Dropdown
                value={this.state.airport}
                options={this.state.airports}
                onChange={(e) => this.onAirportChange(e)}
                placeholder="Виберіть аеропорт"
                optionLabel="name"
                style={{ width: "100%" }}
                className={errors.airport == "" ? "mb-3" : "is-invalid p-error"}
              />
              <div
                className="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >
                {errors.airport}
              </div>

              <h6>Місто</h6>
              <Dropdown
                value={this.state.city}
                options={this.state.cities}
                onChange={(e) => this.onCityChange(e)}
                placeholder="Виберіть місто"
                optionLabel="name"
                style={{ width: "100%" }}
                className={errors.city == "" ? "mb-3" : "is-invalid p-error"}
              />
              <div
                className="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >
                {errors.city}
              </div>

              <h6>Готель </h6>
              <Dropdown
                value={this.state.hotel}
                options={this.state.hotels}
                onChange={(e) => this.onHotelChange(e)}
                placeholder="Виберіть готель"
                optionLabel="name"
                style={{ width: "100%" }}
                className={errors.hotel == "" ? "mb-3" : "is-invalid p-error"}
              />
              <div
                className="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >
                {errors.hotel}
              </div>

              <h6>Тип кімнати </h6>
              <Dropdown
                value={this.state.roomType}
                options={this.state.roomTypes}
                onChange={(e) => this.onRoomTypeChange(e)}
                placeholder="Виберіть тип кімнати"
                optionLabel="name"
                style={{ width: "100%" }}
                className={
                  errors.roomType == "" ? "mb-3" : "is-invalid p-error"
                }
              />
              <div
                className="invalid-feedback mb-3"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >
                {errors.roomType}
              </div>

              <h6>Комфорт</h6>
              <MultiSelect
                value={this.state.comfortsSelected}
                options={this.state.comforts}
                onChange={(e) => this.setState({ comfortsSelected: e.value })}
                selectedItemsLabel="{0} вибрано"
                filter={true}
                optionLabel="name"
                maxSelectedLabels={5}
                filterPlaceholder="Пошук"
                placeholder="Виберіть комфорти"
                className="mb-3"
              />

              <div
                className="d-flex align-items-end justify-content-end m-2"
                style={{ height: "100%" }}
              >
                <Button
                  type="submit"
                  label="Створити"
                  className="p-button-success"
                />

                {isLoad && (
                  <ProgressSpinner
                    style={{ width: "2rem", margin: "0", height: "auto" }}
                    className="ml-2"
                    strokeWidth="8"
                    //fill="#EEEEEE"
                    animationDuration="9.7s"
                  />
                )}
              </div>
            </div>
          </form>
        </div>
      </div>
    );
  }
}




// 2
// GetReducerData
function mapStateToProps(state) {
  return{
    ticketReducer: get(state, 'addTicket.ticketStat'),
    countryReducer: get(state,'addTicket.countries'),
    airportReducer: get(state,'addTicket.airports'),
    cityReducer: get(state,'addTicket.cities'),
    hotelReducer: get(state,'addTicket.hotels'),
    roomTypeReducer: get(state,'addTicket.roomTypes'),
    comfortReducer: get(state,'addTicket.comforts')
  }
}

//1
//Call reducer
const mapDispatch = (dispatch) => {
  return {
    addTicket: (ticket) => {
      dispatch(reducer.addTicket(ticket));
    },
    getCountryData: () => {
      dispatch(reducer.getCountryData());
    },
    getAirportData: (countryId) => {
      dispatch(reducer.getAirportData(countryId));
    },
    getCityData: (countryId) => {
      dispatch(reducer.getCityData(countryId));
    },
    getHotelData: (cityId) => {
      dispatch(reducer.getHotelData(cityId));
    },
    getRoomTypeData: () => {
      dispatch(reducer.getRoomTypeData());
    },
    getComfortData: () => {
      dispatch(reducer.getComfortData());
    },
    clearTicketState: () => {
      dispatch(reducer.clearTicketState());
    },
  };
}

export default connect(mapStateToProps, mapDispatch)(AddTicket);
import React, { Component } from "react";
import { InputText } from "primereact/inputtext";
import { InputMask } from "primereact/inputmask";
import { InputSwitch } from "primereact/inputswitch";
import { Dropdown } from "primereact/dropdown";
import { Growl } from "primereact/growl";
import { Button } from "primereact/button";
import { ProgressSpinner } from "primereact/progressspinner";


import get from "lodash.get";
import { connect } from "react-redux";
import * as reducer from "./reducer";

class AddTicket extends Component {
  state = {
    currentData: null,

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
      // country:"",
      // airport:"",
      // city:"",
      // hotel:"",
      // roomType:""
    }
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

  //-------------------------SHOW--------------------------------

  showSuccess() {
    this.growl.show({
      severity: "success",
      summary: "Квиток створенний",
      // detail: "Order submitted",
    });
  }

  showError() {
    this.growl.show({
      severity: "error",
      summary: "Помилка",
      //detail: "Validation failed",
    });
  }

  //-------------------------Validation--------------------------------

  onSubmit = (e) => {
    e.preventDefault();
    this.clear();
    // if (this.firstValidation() && this.secondValidation()) {

    // }


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
      }
    });
  };

  firstValidation = () => {
    let flag = true;
    
    

    return flag;
  };

  secondValidation = () => {};



  //-------------------------Redux--------------------------------



  //3
  // Call reducer
  componentWillMount = () => {
    this.props.getCountryData();
    this.props.getRoomTypeData();
  }


  componentWillReceiveProps = (nextProps) => { //- Binding     
    if(nextProps != this.props){
      this.setState({
        countries : nextProps.countryReducer,
        airports : nextProps.airportReducer,
        cities : nextProps.cityReducer,
        hotels : nextProps.hotelReducer,
        roomTypes : nextProps.roomTypeReducer
      });
    }
  }



  render() {
    const { isLoad,errors,fields } = this.state;

    return (
      <div className="mt-3 container">
        <Growl ref={(el) => (this.growl = el)} style={{ marginTop: "3rem" }} />

        <h3 style={{ fontSize: "2.3rem" }}>Сворити квиток</h3>

        <div className="card p-2 " style={{ background: "#f7f1e3" }}>
          <form
            onSubmit={this.onSubmit}
            className="row flex-row d-flex justify-content-between"
          >
            <div className="card m-3 p-2 col-sm">
              <h6>Початкова ціна</h6>
              <div className={errors.priceFrom == "" ? "input-group mb-3" : "input-group mb-2" } >
                <div className="input-group-prepend">
                  <span className="input-group-text">₴</span>
                </div>
                <input
                  type="number"
                  min="0"                                 
                  className= {errors.priceFrom == "" ? "form-control" : "form-control is-invalid"}
                  aria-label="Amount (to the nearest dollar)"
                  onChange={e => this.fields.priceFrom = e.target.value }
                />
                <div className="input-group-append">
                  <span className="input-group-text">.00</span>
                </div>
                <div
                  class="invalid-feedback"
                  style={{ fontSize: "0.8rem", fontWeight: "500" }}
                >{errors.priceFrom}</div>
              </div>

              <h6>Кількість ночей</h6>
              <InputText
                className={errors.countsOfNight == "" ? "mb-3" : "is-invalid p-error"}
                type="text"
                keyfilter="pint"
                onChange={e => this.fields.countsOfNight = e.target.value }
              />
              <div
                class="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >{errors.countsOfNight}</div>

              <h6>Дата відльоту</h6>
              <div>
                <InputMask
                  style={{ width: "100%" }}
                  className={errors.dateFrom == "" ? "mb-3" : "is-invalid p-error"}
                  mask="99/99/9999"
                  placeholder="99/99/9999"
                  slotChar="мм/дд/рррр"
                  onChange={e => this.fields.dateFrom = e.target.value }
                ></InputMask>
                <div
                class="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >{errors.dateFrom}</div>
              </div>
              

              <h6>Дата прильоту</h6>
              <div>
                <InputMask
                  className={errors.dateTo == "" ? "mb-3" : "is-invalid p-error"}
                  style={{ width: "100%" }}
                  mask="99/99/9999"
                  placeholder="99/99/9999"
                  slotChar="мм/дд/рррр"
                  onChange={e => this.fields.dateTo = e.target.value }
                ></InputMask>
              </div>
              <div
                class="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >{errors.dateTo}</div>

              <h6>Кількість місць</h6>
              <InputText
                className={errors.countOfPlaces == "" ? "mb-3" : "is-invalid p-error"}
                type="text"
                keyfilter="pint"
                onChange={e => this.fields.countOfPlaces = e.target.value }
              />
              <div
                class="invalid-feedback mb-3"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >{errors.countOfPlaces}</div>

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
                  onChange={(e) => this.setState({percent: e.value})}
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
                class="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >{errors.country}</div>

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
                class="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >{errors.airport}</div>

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
                class="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >{errors.city}</div>

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
                class="invalid-feedback mb-2"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >{errors.hotel}</div>

              <h6>Тип кімнати </h6>
              <Dropdown
                value={this.state.roomType}
                options={this.state.roomTypes}
                onChange={(e) => this.onRoomTypeChange(e)}
                placeholder="Виберіть тип кімнати"
                optionLabel="name"
                style={{ width: "100%" }}
                className={errors.roomType == "" ? "mb-3" : "is-invalid p-error"}
              />
              <div
                class="invalid-feedback mb-3"
                style={{ fontSize: "0.8rem", fontWeight: "500" }}
              >{errors.roomType}</div>

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
    ticketReducer: get(state, 'addTicketReducer.ticketStat'),
    countryReducer: get(state,'addTicketReducer.countries'),
    airportReducer: get(state,'addTicketReducer.airports'),
    cityReducer: get(state,'addTicketReducer.cities'),
    hotelReducer: get(state,'addTicketReducer.hotels'),
    roomTypeReducer: get(state,'addTicketReducer.roomTypes'),
  }
}

//1
//Call reducer
const mapDispatch = {
  addTicket: (ticket) => {
    return reducer.addTicket(ticket);
  },
  getCountryData: () => {
    return reducer.getCountryData();
  },
  getAirportData: (countryId) => {
    return reducer.getAirportData(countryId);
  },
  getCityData: (countryId) => {
    return reducer.getCityData(countryId);
  },
  getHotelData: (cityId) => {
    return reducer.getHotelData(cityId);
  },
  getRoomTypeData: () => {
    return reducer.getRoomTypeData();
  }

}

export default connect(mapStateToProps, mapDispatch)(AddTicket);
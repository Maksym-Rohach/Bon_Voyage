import React, { Component } from "react";
import { InputText } from "primereact/inputtext";
import { InputMask } from "primereact/inputmask";
import { InputSwitch } from "primereact/inputswitch";
import { Dropdown } from "primereact/dropdown";
import {Growl} from 'primereact/growl';
import { Button } from "primereact/button";
import {ProgressSpinner} from 'primereact/progressspinner';
import {FileUpload} from 'primereact/fileupload';



class AddTicket extends Component {
  state = {
    currentData: null,

    country: null,
    countries: [],

    city: null,
    cities: [],

    hotel: null,
    hotels: [],

    airport: null,
    airports: [],

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
  };





  //------------------------CHANGE--------------------------

  onCountryChange = (e) => {
    this.setState({ country: e.value });
  };

  onCityChange = (e) => {
    this.setState({ city: e.value });
  };

  onHotelChange = (e) => {
    this.setState({ hotel: e.value });
  };

  onAirportChange = (e) => {
    this.setState({ roomType: e.value });
  };

  onRoomTypeChange = (e) => {
    this.setState({ roomType: e.value });
  };

  onPercentChange = (e) => {
    this.setState({ percent: e.value });
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




  render() {
    return (
      <div className="mt-3 container">
        <h3 style={{ fontSize: "2.3rem" }}>Сворити квиток</h3>

        <div
          className="card p-2 row flex-row d-flex justify-content-between "
          style={{ background: "#f7f1e3" }}
        >
          <div className="card m-3 p-2 col-sm">
            <h6>Початкова ціна</h6>
            <div className="input-group mb-3">
              <div className="input-group-prepend">
                <span className="input-group-text">$</span>
              </div>
              <input
                type="number"
                min="0"
                className="form-control"
                aria-label="Amount (to the nearest dollar)"
              />
              <div className="input-group-append">
                <span className="input-group-text">.00</span>
              </div>
            </div>

            <h6>Кількість ночей</h6>
            <InputText className="mb-3" type="text" keyfilter="pint" />

            <h6>Дата відльоту</h6>
            <div className="mb-3">
              <InputMask
                style={{ width: "100%" }}
                mask="99/99/9999"
                placeholder="99/99/9999"
                slotChar="мм/дд/рррр"
                className="p-error"
              ></InputMask>
            </div>

            <h6>Дата прильоту</h6>
            <div className="mb-3">
              <InputMask
                style={{ width: "100%" }}
                mask="99/99/9999"
                placeholder="99/99/9999"
                slotChar="мм/дд/рррр"
              ></InputMask>
            </div>

            <h6>Кількість місць</h6>
            <InputText type="text" keyfilter="pint" className="mb-3" />

            <h6>Знижка </h6>
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
                onChange={(e) => this.onPercentChange(e)}
                placeholder="Виберіть знижку"
                optionLabel="percent"
                style={{ width: "12em" }}
                disabled={!this.state.percentState}
                className="mb-3"
              />
            </div>
          </div>          

          {/*-----------------2------------------  */}

          <Growl
            ref={(el) => (this.growl = el)}
            style={{ marginTop: "3rem" }}
          />

          <div className="card m-3 p-2 col-sm">
            <h6>Країна</h6>
            <Dropdown
              value={this.state.country}
              options={this.state.countries}
              onChange={(e) => this.onCountryChange(e)}
              placeholder="Виберіть країну"
              optionLabel="name"
              style={{ width: "100%" }}
              className="mb-3"
            />

            <h6>Місто</h6>
            <Dropdown
              value={this.state.city}
              options={this.state.cities}
              onChange={(e) => this.onCityChangeChange(e)}
              placeholder="Виберіть місто"
              optionLabel="name"
              style={{ width: "100%" }}
              className="mb-3"
            />

            <h6>Готель </h6>
            <Dropdown
              value={this.state.hotel}
              options={this.state.hotels}
              onChange={(e) => this.onHotelChange(e)}
              placeholder="Виберіть готель"
              optionLabel="name"
              style={{ width: "100%" }}
              className="mb-3"
            />

            <h6>Аеропорт </h6>
            <Dropdown
              value={this.state.airport}
              options={this.state.airports}
              onChange={(e) => this.onAirportChange(e)}
              placeholder="Виберіть аеропорт"
              optionLabel="name"
              style={{ width: "100%" }}
              className="mb-3"
            />

            <div
              className="d-flex align-items-end justify-content-end m-2"
              style={{ height: "100%" }}
            >
              <Button
                onClick={(e) => this.showSuccess(e)}
                label="Створити"
                className="p-button-success"
              />
              <ProgressSpinner
                style={{ width: "2rem", margin: "0", height: "auto" }}
                className="ml-2"
                strokeWidth="8"
                //fill="#EEEEEE"
                animationDuration="9.7s"
              />
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default AddTicket;

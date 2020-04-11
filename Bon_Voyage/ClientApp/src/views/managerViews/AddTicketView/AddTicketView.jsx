import React, { Component } from "react";
import { InputText } from "primereact/inputtext";
import { InputMask } from "primereact/inputmask";
import {InputSwitch} from 'primereact/inputswitch';
import {Dropdown} from 'primereact/dropdown';


class AddTicket extends Component {
  state = {
    hotel:null,
    hotels:[],

    airport:null,
    airports:[],

    roomType:null,
    roomTypes:[],

    percentState: false,
    percent: null,
    percents: [
      { percent: "5%"  , value: 5},
      { percent: "10%" , value: 10},
      { percent: "15%" , value: 15},
      { percent: "20%" , value: 20},
      { percent: "25%" , value: 25},
      { percent: "30%" , value: 30},
      { percent: "35%" , value: 35},
      { percent: "40%" , value: 40},
      { percent: "45%" , value: 45},
      { percent: "50%" , value: 50},
      { percent: "55%" , value: 55},
      { percent: "60%" , value: 60},
      { percent: "65%" , value: 65},
      { percent: "70%" , value: 70},
      { percent: "75%" , value: 75},
      { percent: "80%" , value: 80},
      { percent: "85%" , value: 85},
      { percent: "90%" , value: 90},
      { percent: "95%" , value: 95},
      { percent: "100%", value: 100},
    ],
  };

  onCityChange = (e) => {
    console.log(e.value);
    this.setState({ city: e.value });
  };

  render() {
    return (
      <div className="mt-3 container">
        <h3 style={{ fontSize: "2.3rem" }}>Сворити квиток</h3>

        <div
          className="card p-2 row flex-row d-flex justify-content-center"
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
                mask="01/01/2020"
                //placeholder="99/99/9999"
                slotChar="мм/дд/рррр"
                className="p-error"
              ></InputMask>
            </div>

            <h6>Дата прильоту</h6>
            <div className="mb-3">
              <InputMask
                style={{ width: "100%" }}
                mask="01/31/2020"
                placeholder="99/99/9999"
                //slotChar="мм/дд/рррр"
              ></InputMask>
            </div>

            <h6>Кількість місць</h6>
            <InputText type="text" keyfilter="pint" />
          </div>

          {/*-----------------2------------------  */}

          <div className="card m-3 p-2 col-sm">
            <h6>Знижка </h6>
            <div className="d-flex flex-row">
              <InputSwitch
                className="mt-1 mr-3"
                checked={this.state.percentState}
                onChange={(e) => this.setState({ percentState: e.value })}
              />
              <Dropdown               
                value={this.state.percent}
                options={this.state.percents}
                onChange={(e) => this.onCityChange(e)}
                placeholder="Виберіть знижку"
                optionLabel="percent"
                style={{ width: "12em" }}
                disabled = {!this.state.percentState}
              />
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default AddTicket;

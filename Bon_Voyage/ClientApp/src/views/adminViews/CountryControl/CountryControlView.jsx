import React, { Component } from "react";

import { Link } from "react-router-dom";
import { connect } from "react-redux";
import get from "lodash.get";
import * as reducer from "./reducer";

import {DataTable} from 'primereact/datatable';
import {InputText} from 'primereact/inputtext';
import {Dialog} from 'primereact/dialog';
import {Column} from 'primereact/column';
import {Button} from 'primereact/button';



class CountryControl extends Component {
  state = {
    cars: [
        {vin: "123", year: "2020", brand: "Mercedes", color: "Black"},
        {vin: "123123", year: "2019", brand: "BMW", color: "White"},
    ],
    selectedCar: null,
    car: null,
    displayDialog: false,
    newCar:false,
  };

  componentDidMount= () => {
    // this.carservice.getCarsSmall().then(data => this.setState({cars: data}));
  }

  save= () => {
    let cars = [...this.state.cars];

    if (this.state.newCar) {
      cars.push(this.state.car);
    } else {
      cars[this.findSelectedCarIndex()] = this.state.car;
    }

    this.setState({
      cars: cars,
      selectedCar: null,
      car: null,
      displayDialog: false,
    });
  }



  //------------------ACTIONS------------------------

  delete= () => {
    let index = this.findSelectedCarIndex();
    this.setState({
      cars: this.state.cars.filter((val, i) => i !== index),
      selectedCar: null,
      car: null,
      displayDialog: false,
    });
  }

  findSelectedCarIndex= () => {
    return this.state.cars.indexOf(this.state.selectedCar);
  }

  // Update property in state
  updateProperty(property, value) {
    let car = this.state.car;
    car[property] = value;
    this.setState({ car: car });
  }

  // When click on row
  onCarSelect = (e) => {
    this.state.newCar = false;
    this.setState({
      displayDialog: true,
      car: Object.assign({}, e.data),
    });
  }

  addNew = () => {
    this.state.newCar = true;
    this.setState({
      car: { vin: "", year: "", brand: "", color: "" },
      displayDialog: true,
    });
  }

  updateCountries = () => {

  }

  //------------------RENDER------------------------

  renderHeader= () => {
      return ( <div className="p-clearfix" style={{'lineHeight':'1.87em'}}>Керування країнами<Button onClick={e => this.updateCountries()} icon="pi pi-refresh" style={{'float':'right'}}/></div>);
  }

  renderFooter= () => {
      return (
        <div className="p-clearfix" style={{width:'100%'}}>
            <Button style={{float:'left'}} label="Add" icon="pi pi-plus" onClick={e => this.addNew()}/>
        </div>
      );
  }

  renderDialogFooter= () => {
      return (
        <div className="ui-dialog-buttonpane p-clearfix">
          <Button label="Delete" icon="pi pi-times" onClick={this.delete} />
          <Button label="Save" icon="pi pi-check" onClick={this.save} />
        </div>
      );
  }

  render= () => {   


    return (
      <React.Fragment>
        <div className="ml-2 mr-2 m-2">
          {/* <DataTableSubmenu /> */}

          <div className="content-section introduction">
            <div className="feature-intro">
              <h1>DataTable</h1>
              <p>
                This samples demonstrates a CRUD implementation using various
                PrimeReact components.
              </p>
            </div>
          </div>

          <div className="content-section implementation">
            <DataTable
              value={this.state.cars}
              paginator={true}
              rows={15}
              header={this.renderHeader()}
              footer={this.renderFooter()}
              selectionMode="single"
              selection={this.state.selectedCar}
              onSelectionChange={(e) => this.setState({ selectedCar: e.value })}
              onRowSelect={(e) => this.onCarSelect(e)}
            >
              <Column field="vin" header="Vin" sortable={true} />
              <Column field="year" header="Year" sortable={true} />
              <Column field="brand" header="Brand" sortable={true} />
              <Column field="color" header="Color" sortable={true} />
            </DataTable>

            <Dialog
              visible={this.state.displayDialog}             
              style={{width:"20rem"}}
              header="Car Details"
              modal={true}
              footer={this.renderDialogFooter()}
              onHide={() => this.setState({ displayDialog: false })}
            >
              {this.state.car && (
                <div className="p-grid p-fluid">
                  <div className="p-col-4" style={{ padding: ".75em" }}>
                    <label htmlFor="vin">Vin</label>
                  </div>
                  <div className="p-col-8" style={{ padding: ".5em" }}>
                    <InputText
                      id="vin"
                      onChange={(e) => {
                        this.updateProperty("vin", e.target.value);
                      }}
                      value={this.state.car.vin}
                    />
                  </div>

                  <div className="p-col-4" style={{ padding: ".75em" }}>
                    <label htmlFor="year">Year</label>
                  </div>
                  <div className="p-col-8" style={{ padding: ".5em" }}>
                    <InputText
                      id="year"
                      onChange={(e) => {
                        this.updateProperty("year", e.target.value);
                      }}
                      value={this.state.car.year}
                    />
                  </div>

                  <div className="p-col-4" style={{ padding: ".75em" }}>
                    <label htmlFor="brand">Brand</label>
                  </div>
                  <div className="p-col-8" style={{ padding: ".5em" }}>
                    <InputText
                      id="brand"
                      onChange={(e) => {
                        this.updateProperty("brand", e.target.value);
                      }}
                      value={this.state.car.brand}
                    />
                  </div>

                  <div className="p-col-4" style={{ padding: ".75em" }}>
                    <label htmlFor="color">Color</label>
                  </div>
                  <div className="p-col-8" style={{ padding: ".5em" }}>
                    <InputText
                      id="color"
                      onChange={(e) => {
                        this.updateProperty("color", e.target.value);
                      }}
                      value={this.state.car.color}
                    />
                  </div>
                </div>
              )}
            </Dialog>
          </div>

          {/* <DataTableCrudDoc /> */}
        </div>
      </React.Fragment>
    );
  }
}

export default CountryControl;

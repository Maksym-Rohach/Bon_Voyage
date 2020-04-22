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
import {ProgressSpinner} from 'primereact/progressspinner';
import {Growl} from 'primereact/growl';
import Loader from '../../../components/Loader/index';


class CountryControl extends Component {
  state = {
    countries: [],
    selectedCountry: null,
    Country: null,
    displayDialog: false,
    newCountry: false,

    isLoadPage: false,
    isUpdateNameLoad: false,
    isDeleteLoad: false,
    isAddLoad: false,

    isUpdateNameSuccess: false,
    isDeleteSuccess:false,
    isAddSuccess:false,

    isCreateCountry:false,

    errors:{
        updateDialogError:{},
        deleteDialogError:{},
        addDialogError:{},
    },
    growlSuccessMessage: "",

    dialogTitle:"Опції країни",
  };

  //------------------ACTIONS------------------------

  save = () => {
    let countries = [...this.state.countries];

    // Add new
    if (this.state.newCountry) {
        const model = {
            name:this.state.Country.name
        }
        this.props.createCountry(model);
    } else {
        console.log("Save",this.state.Country);
        const {Country} = this.state;
        const model = {
            id: Country.id,
            newName: Country.name
        }
        this.props.changeCountry(model);
    }

    this.setState({
      countries: countries,
      selectedCountry: null,
      isCreateCountry:false,
    //   Country: null,
    //   displayDialog: false,
    });
  };

  delete = () => {  
    const model = {
        id: this.state.selectedCountry.id
    }
    this.props.deleteCountry(model);
  };

  // Update property in state
  updateProperty(property, value) {
    let Country = this.state.Country;
    Country[property] = value;
    this.setState({ Country: Country });
  }

  // When click on row
  onCountrySelect = (e) => {
    // console.log(e.data);

    this.state.newCountry = false;
    this.setState({
      displayDialog: true,
      isCreateCountry:false,
      Country: Object.assign({}, e.data),
      dialogTitle:"Опції країни"
    });
  };

  addNew = () => {
    this.state.newCountry = true;
    this.setState({
      Country: { name: "" },
      isCreateCountry:true,
      displayDialog: true,
      dialogTitle:"Створити країну"
    });
  };

  updateCountries = () => {
    this.props.getCountries();
  };

  onDialogHide = () => {
    let errors = {
        updateDialogError:{},
        deleteDialogError:{},
        addDialogError:{},
    }

    this.setState({
      displayDialog: false,
      errors,
    });

  }

  //-------------------GROWL------------------------

  showSuccess = () => {
    if (this.state.isDeleteSuccess) {
      this.growl.show({
        severity: "warn",
        summary: this.state.growlSuccessMessage,
        life:6000
      });
    } else {
      this.growl.show({
        severity: "success",
        summary: this.state.growlSuccessMessage,
        life: 10000,
      });
    }


    this.setState({
      isUpdateNameSuccess: false,
      isDeleteSuccess: false,
      isAddSuccess: false,
      displayDialog: false,
    }); 
    this.props.clearState();
  }
  //------------------RENDER------------------------

  renderHeader = () => {
    return (
      <div
        className=" d-flex justify-content-between align-content-center"
        style={{ lineHeight: "1.90em" }}
      >
        <label
          style={{
            fontSize: "1.3rem",
            marginBottom: "0",
            marginTop: "0.3rem",
            verticalAlign: "middle",
          }}
        >
          Список країн
        </label>
        <div style={{ textAlign: "left" }}>
          <Button
            onClick={(e) => this.updateCountries()}
            className="ml-2 p-button-warning"
            icon="pi pi-refresh"
            tooltip="Перезавантажити"
            tooltipOptions={{ position: "top" }}
            style={{ float: "right" }}
          />
          <Button
            style={{ float: "right" }}
            className="p-button-success"
            tooltip="Створити нову країну"
            tooltipOptions={{ position: "top" }}
            label="Створити"
            icon="pi pi-plus"
            onClick={(e) => this.addNew()}
          />
        </div>
      </div>
    );
  };

  renderDialogFooter = () => {
    const { isUpdateNameLoad, isDeleteLoad, isAddLoad,isCreateCountry } = this.state;

    return (
      <div className="ui-dialog-buttonpane p-clearfix d-flex justify-content-end">
        {!isCreateCountry ? (
          <Button
            label="Видалити"
            icon="pi pi-times"
            className="p-button-danger"
            onClick={(e) => this.delete()}
          />
        ) : (
          <div></div>
        )}
        <Button
          label="Зберегти"
          icon="pi pi-check"
          className="p-button-success"
          onClick={(e) => this.save()}
        />
        {isUpdateNameLoad || isDeleteLoad || isAddLoad ? (
          <ProgressSpinner
            style={{ width: "2rem", margin: "0", height: "auto" }}
            className="ml-2"
            strokeWidth="8"
            //fill="#EEEEEE"
            animationDuration="9.7s"
          />
        ) : (
          <div />
        )}
      </div>
    );
  };

  //------------------REDUX-------------------------

  componentDidMount = () => {
    this.updateCountries();
  };

  componentWillReceiveProps = (nextProps) => {
    //- Binding
    this.setState({
      isLoadPage: nextProps.getCountryReducer.loading,
      isUpdateNameLoad: nextProps.changeCountryReducer.loading,
      isDeleteLoad: nextProps.deleteCountryReducer.loading,
      isAddLoad: nextProps.createCountryReducer.loading,
      countries: nextProps.getCountryReducer.data,

      isUpdateNameSuccess: nextProps.changeCountryReducer.success,
      isDeleteSuccess: nextProps.deleteCountryReducer.success,
      isAddSuccess: nextProps.createCountryReducer.success,

      isCreateCountry:true,
      
      errors: {
        updateDialogError: nextProps.changeCountryReducer.error,
        deleteDialogError: nextProps.deleteCountryReducer.error,
        addDialogError: nextProps.createCountryReducer.error,
      },
    });
  };

  render = () => {
    const { isLoadPage,dialogTitle,isUpdateNameSuccess,isDeleteSuccess,isAddSuccess,errors } = this.state;

    if (isUpdateNameSuccess || isDeleteSuccess || isAddSuccess) {
        
      if (isUpdateNameSuccess) {
        this.state.growlSuccessMessage = "Місто змінено";
      } else if (isDeleteSuccess) {
        this.state.growlSuccessMessage = "Місто видалено";
      } else if (isAddSuccess) {
        this.state.growlSuccessMessage = "Місто створено";
      }
      

      this.updateCountries();
      this.showSuccess();
    }

    const page = (
      <React.Fragment>
        <Growl ref={(el) => (this.growl = el)} style={{ marginTop: "3rem" }} />
        <div className="ml-2 mr-2 m-2">
          <div className="content-section introduction">
            <div className="feature-intro">
              <h1>Керування країнами</h1>             
            </div>
          </div>

          <div className="content-section implementation">
            <DataTable
              value={this.state.countries}
              paginator={true}
              rows={25}
              header={this.renderHeader()}
              selectionMode="single"
              selection={this.state.selectedCountry}
              onSelectionChange={(e) =>
                this.setState({ selectedCountry: e.value })
              }
              onRowSelect={(e) => this.onCountrySelect(e)}
            >
              <Column field="name" header="Назва" sortable={true} />
              <Column
                field="cityCount"
                header="Кількість міст"
                sortable={true}
              />
            </DataTable>

            <Dialog
              visible={this.state.displayDialog}
              style={{ width: "20rem" }}
              header={dialogTitle}
              modal={true}
              footer={this.renderDialogFooter()}
              onHide={(e) => this.onDialogHide()}
            >            
              {this.state.Country && (
                <div>
                  <label className="mr-3" htmlFor="name">
                    Назва країни
                  </label>             
                  <InputText
                    id="name"
                    className = {Object.keys(errors.addDialogError).length > 0 ||
                    Object.keys(errors.updateDialogError).length > 0 ||
                    Object.keys(errors.deleteDialogError).length > 0 ? "p-error is-invalid" : "" }
                    onChange={(e) => {
                      this.updateProperty("name", e.target.value);
                    }}
                    value={this.state.Country.Name}
                  />
                  <div
                  className="invalid-feedback d-flex justify-content-end"
                  style={{ fontSize: "0.85rem", fontWeight: "600",float:"right",marginRight:"1.5rem" }}
                >
                    {errors.addDialogError?.errorMessage}
                    {errors.updateDialogError?.errorMessage}
                    {errors.deleteDialogError?.errorMessage}
                </div>
                </div>                
              )}
            </Dialog>
          </div>
        </div>
      </React.Fragment>
    );

    return isLoadPage ? <Loader /> : page;
  };
}





// 2
// GetReducerData
function mapStateToProps(state) {
    return {
      getCountryReducer: get(state, 'countryControl.countries'),
      createCountryReducer: get(state, 'countryControl.createCountry'),
      changeCountryReducer: get(state, 'countryControl.changeCountry'),
      deleteCountryReducer: get(state, 'countryControl.deleteCountry'),    
    };
  }


//1
//Call reducer
const mapDispatch = (dispatch) => {
  return {
    getCountries: () => {
      dispatch(reducer.getCountries());
    },
    createCountry: (country) => {
        dispatch(reducer.createCountry(country));
    },
    changeCountry: (country) => {
        dispatch(reducer.changeCountry(country));
    },
    deleteCountry: (country) => {
        dispatch(reducer.deleteCountry(country));
    },
    clearState: () => {
        dispatch(reducer.clearState());
    },
  };
};

  export default connect(mapStateToProps, mapDispatch)(CountryControl);
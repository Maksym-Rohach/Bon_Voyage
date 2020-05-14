import React, { Component } from "react";
import { Link } from 'react-router-dom';
import get from "lodash.get";
import { connect } from "react-redux";
import Loader from '../../../components/Loader/index'
import * as reducer from "./reducer";
import { Growl } from 'primereact/growl';

import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Button } from "primereact/button";

class FavoriteTicket extends Component {
    state = {
        tickets:[],
        isLoad:false,
        isSuccess:false,
        selectedTicket:undefined,
    };




    //3
    // Call reducer
    componentWillMount = () => {
        this.props.getTicketsData();
    }

    componentWillReceiveProps = (nextProps) => { //- Binding    
        this.setState({
            tickets: nextProps.ticketReducer,
            isLoad: nextProps.loadReducer,
            isSuccess: nextProps.successReducer
        });
    }

    buyTicket = (id) => {
        console.log(id);
        let model = {
            clientId:" ",
            ticketId:id,
        };
        this.props.buyTicket(model);
    }

    showSuccess() {
        window.location.reload();
        
        this.growl.show({ severity: 'success', life: 8000, summary: 'Success Message', detail: 'Order submitted' });
    }

    //-------------------------RENDER--------------------------------

    actionTemplate = (e) => {
      return (
            <div>
                <Button
                    type="button"
                    icon="pi pi-info"
                    className="p-button-info"
                    style={{ marginRight: ".5em" }}
                ></Button>
                <Button
                    type="button"
                    icon="pi pi-shopping-cart"
                    onClick={x => this.buyTicket(e.id)}
                    className="p-button-success"
                ></Button>
            </div>
        );
    };

    refresh = () => {
        this.props.getTicketsData();
    }

    render() {
        if(this.state.isSuccess)
        {
            this.showSuccess();
        }

        let ticketCount = this.state.tickets.length;
        let header = (
            <div className="p-clearfix" style={{ lineHeight: "1.87em" }}>
                Список квитків{" "}
                <Button icon="pi pi-refresh" onClick={e => this.refresh()} style={{ float: "right" }} />
            </div>
        );
        let footer = "Показано " + ticketCount + " квитків";

        const page = (
            <React.Fragment>
                <Growl ref={(el) => (this.growl = el)} style={{ marginTop: "3rem" }} />
                <div className="mt-3">
                    <div className="content-section introduction">
                        <div className="feature-intro">
                            <h1> </h1>
                            <p> </p>
                        </div>
                    </div>

                    <div className="content-section implementation">
                        <DataTable selection={this.state.selectedTicket} value={this.state.tickets} header={header} footer={footer}>
                            
                            <Column
                                field="country"
                                header="Країна"
                                style={{ textAlign: "center" }}
                            />
                            <Column
                                field="city"
                                header="Місто"
                                style={{ textAlign: "center" }}
                            />
                            <Column
                                field="hotel"
                                header="Готель"
                                style={{ textAlign: "center" }}
                            />
                            <Column
                                field="dateFrom"
                                header="Дата відльоту"
                                style={{ textAlign: "center" }}
                            />
                            <Column
                                field="dateTo"
                                header="Дата прильоту"
                                style={{ textAlign: "center" }}
                            />
                            <Column
                                field="price"
                                header="Ціна"
                                style={{ textAlign: "center" }}
                            />
                            <Column
                                field="countOfPlaces"
                                header="Кількість місць"
                                style={{ textAlign: "center" }}
                            />
                            <Column
                                
                                body={(e) => this.actionTemplate(e)}
                                style={{ textAlign: "center", width: "8em" }}
                            />
                        </DataTable>
                    </div>
                </div>
            </React.Fragment>
        );

        return this.state.isLoad ? <Loader/> : page;
    }
}


// 2
// GetReducerData
function mapStateToProps(state) {
    console.log(state);
    return {
        ticketReducer: get(state, 'cartTicket.list.data'),
        loadReducer: get(state, 'cartTicket.list.loading'),
        successReducer: get(state, 'cartTicket.addSuccess'),
    };
}

//1
//Call reducer
const mapDispatch = (dispatch) => {
    return {
        getTicketsData: () => {
            dispatch(reducer.getTicketsData());
        },
        buyTicket: (model) => {
            dispatch(reducer.buyTicket(model));
        },
    }
}


export default connect(mapStateToProps, mapDispatch)(FavoriteTicket);
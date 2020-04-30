import React from "react";
import classNames from "classnames";
import { Bar } from "react-chartjs-2";
import * as getListActions from "./reducer";
import { connect } from "react-redux";
import get from "lodash.get";
import ReactDOM from 'react-dom'
import { Map, GoogleApiWrapper, Marker } from 'google-maps-react';


import {
    Button,
    Card,
    CardBody,
    CardFooter,
    CardGroup,
    Col,
    Container,
    Form,
    Input,
    InputGroup,
    InputGroupAddon,
    InputGroupText,
    Row,
    FormGroup,
    Label,
    FormText,
} from "reactstrap";

const mapStyles = {
    width: '100%',
    height: '100%',
  };

class ClientMapView extends React.Component {
    state = {};

    render() {
        const { clientMap } = this.props;
        return (
            <Map
              google={this.props.google}
              zoom={5}
              style={mapStyles}
              initialCenter={{ lat: 50.641288, lng: 26.257515}}
            >
              <Marker position={{ lat: 50.641288, lng: 26.257515}} />
            </Map>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        listClients: get(state, "clientmap.list.data"),
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
    };
};

export default GoogleApiWrapper({})(ClientMapView);
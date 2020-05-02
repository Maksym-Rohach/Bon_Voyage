import React from "react";
import classNames from "classnames";
import { Bar } from "react-chartjs-2";
import * as getListActions from "./reducer";
import { connect } from "react-redux";
import get from "lodash.get";
import Iframe from 'react-iframe';



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


class ClientMapView extends React.Component {
    state = {};

    render() {
        const { clientMap } = this.props;
        return (
            <React.Fragment>
            <Iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3580.155688092591!2d26.25886499832669!3d50.61685488613916!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x472f134609e1331f:0x4b4b27390f364d81!2z0JrQvtC80L8n0Y7RgtC10YDQvdCwINCQ0LrQsNC00LXQvNGW0Y8g0KjQkNCT!5e0!3m2!1sru!2sua!4v1588261875083!5m2!1sru!2sua"
             width="1650" height="850" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></Iframe>
            </React.Fragment>
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

export default ClientMapView;
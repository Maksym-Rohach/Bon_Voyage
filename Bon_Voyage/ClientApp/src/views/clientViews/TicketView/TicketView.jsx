import React, { Component, useState, Fragment } from 'react';
import * as getListActions from './reducer';
import * as getFilterListActions from './reducer';
import * as getHotelListActions from './reducer';
import * as buyTicketListActions from './reducer';
import get from 'lodash.get';
import "../../othersViews/instruments/css/style.scss";
import "../../othersViews/instruments/vendors/linericon/style.css";
import { connect } from 'react-redux';
import { serverUrl } from '../../../config';
import { Card, Button, Dropdown } from 'reactstrap';
import { Link } from 'react-router-dom';
import mylogo from "../../../assets/img/Logo.png";
import { array } from 'prop-types';

class TicketView extends Component {
    state = {
        countryId: "",
        roomTypeId: "",
        hotelId: "",
        comfortsId: "",
        maxPrice: 0,
        hotelStarts: 0,
        dateFrom: null,
        dateTo: null,
        countOfNights: 0,
        countsOfPlaces: 0,
        withDiscount: false,
    }

    countrySelect = (e) => {
        this.setState({ countryId: e.target.value });
        this.props.getHotels(e.target.value);
    }
    roomTypeSelect = (e) => {
        this.setState({ roomTypeId: e.target.value });
    }
    hotelSelect = (e) => {
        this.setState({ hotelId: e.target.value });
    }
    comfortSelect = (e) => {
        this.setState({ comforts: e.target.value });
    }
    inputPrice = (e) => {
        this.setState({ maxPrice: e.target.value });
    }
    starInput = (e) => {
        this.setState({ hotelStars: e.target.value });
    }
    dateFromInput = (e) => {
        this.setState({ dateFrom: e.target.value });
    }
    dateToInput = (e) => {
        this.setState({ dateTo: e.target.value });
    }
    countsOfNightInput = (e) => {
        this.setState({ countOfNights: e.target.value });
    }
    countsOfPlacesInput = (e) => {
        this.setState({ countsOfPlaces: e.target.value })
    }
    discountCheckBox = (e) => {
        if(e.target.value==="on")
        this.setState({ withDiscount:true});
        else
        this.setState({ withDiscount:false});
    }

    buyTicket(ticketId,indx,filters) {
        this.props.buyTicket(ticketId,indx,filters);
    }

    submitFilter() {
        this.props.getFiltredTickets(0, this.state);
    }

    componentWillMount() {
        this.props.getFiltredTickets(0, null);
        this.props.getFilterData();
    }
    render() {
        const { tickets, filters, hotels } = this.props;
        let startIndx, count = tickets;
        return (
            <React.Fragment>
                <div className="home-page bg-white">
                    <header className="header_area">
                        <div className="main_menu">
                            <nav className="navbar navbar-expand-lg navbar-light">
                                <div className="container">
                                    <a className="navbar-brand logo_h" href="index.html">
                                        <img src={mylogo} height="50px" alt="" />
                                    </a>
                                    <button
                                        className="navbar-toggler"
                                        type="button"
                                        data-toggle="collapse"
                                        data-target="#navbarSupportedContent"
                                        aria-controls="navbarSupportedContent"
                                        aria-expanded="false"
                                        aria-label="Toggle navigation"
                                    >
                                        <span className="icon-bar"></span>
                                        <span className="icon-bar"></span>
                                        <span className="icon-bar"></span>
                                    </button>
                                    <div
                                        className="collapse navbar-collapse offset"
                                        id="navbarSupportedContent"
                                    >
                                        <ul className="nav navbar-nav menu_nav">
                                            <li className="nav-item active">
                                                <Link className="nav-link" to="/#/">
                                                    Головна
                        </Link>
                                            </li>
                                            <li className="nav-item">
                                                {" "}
                                                <Link className="nav-link" to="/contact-page">
                                                    Контакти
                        </Link>
                                            </li>
                                            <li className="nav-item">
                                                <Link className="nav-link" to="gallery-page">
                                                    Галерея
                        </Link>
                                            </li>
                                        </ul>
                                    </div>
                                    <div className="ml-auto d-none d-md-block d-md-flex">
                                        <div className="media header-top-info">
                                            <span className="header-top-info__icon">
                                                <i className="fa fa-phone"></i>
                                            </span>
                                            <div className="media-body">
                                                <p>Маєте питання?</p>
                                                <p>
                                                    Free:{" "}
                                                    <a href="tel:++38 096 6666666">++38 096 6666666</a>
                                                </p>
                                            </div>
                                        </div>
                                        <div className="media header-top-info">
                                            <span className="header-top-info__icon">
                                                <i className="fa fa-envelope" aria-hidden="true"></i>
                                            </span>
                                            <div className="media-body">
                                                <p>Have any question?</p>
                                                <p>
                                                    Free:{" "}
                                                    <a href="tel:+38 096 6666666">+38 096 6666666</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </nav>
                        </div>
                    </header>
                    <section className="contact-banner-area" id="contact">
                        <div className="container h-100">
                            <div className="contact-banner">
                                <div className="text-center">
                                    <h1>Список квитків</h1>
                                    <nav aria-label="breadcrumb" className="banner-breadcrumb">

                                    </nav>
                                </div>
                            </div>
                        </div>
                    </section>
                    <form class="form-search form-search-position accomodation">
                        <div style={{ marginTop: '5px' }} className="container">
                            <div className="row">
                                <div className="col-lg-6 gutters-19">
                                    <div className="form-group">
                                        <input className="form-control" type="number" onChange={(e) => { this.inputPrice(e) }} placeholder="Оберіть максимальну ціну" />
                                    </div>
                                </div>
                                <div className="col-lg-6 gutters-19">
                                    <div className="row">
                                        <div className="col-sm">
                                            <div className="form-group">
                                                <div className="form-select-custom">
                                                    <select name="" id="" onChange={(e) => { this.countrySelect(e) }}>
                                                        <option value="" disabled selected>Оберіть країну</option>
                                                        {!!filters ?
                                                            filters.countries.map((item, i) => {
                                                                return (
                                                                    <option value={item.id}>{item.name}</option>
                                                                )
                                                            })
                                                            : ""}
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="col-sm gutters-19">
                                            <div className="form-group">
                                                <div className="form-select-custom">
                                                    <select name="" id="" onChange={(e) => { this.hotelSelect(e) }}>
                                                        <option selected disabled >Оберіть готель</option>
                                                        {!!hotels ?
                                                            hotels.map((item, i) => {
                                                                return (
                                                                    <option value={item.id}>{item.name}</option>
                                                                )
                                                            })
                                                            : ""}
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="row">
                                <div className="col-sm gutters-19">
                                    <div className="form-group">
                                        <input type="checkbox" id="discount" className="form-check-label" onChange={(e) => { this.discountCheckBox(e) }} />
                                        <label for="discount">Квитки зі знижкою?</label>
                                    </div>
                                </div>
                                <div className="col-sm gutters-19">
                                    <div className="form-group">
                                        <div className="form-select-custom">
                                            <select name="" id="" onChange={(e) => { this.roomTypeSelect(e) }}>
                                                <option value="" disabled selected>Оберіть тип кімнати</option>
                                                {!!filters ?
                                                    filters.roomTypes.map((item, i) => {
                                                        return (
                                                            <option value={item.id}>{item.name}</option>
                                                        )
                                                    })
                                                    : ""}
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div className="col-sm gutters-19">
                                    <label for="dateFrom">Дата прибуття</label>
                                    <input id="dateFrom" name="dateFrom" className="form-control" type="date" min={Date.now()} onChange={(e) => { this.dateFromInput(e) }} placeholder="Оберіть дату прибуття" />
                                </div>
                                <div className="col-lg-4 gutters-19">
                                    <div className="form-group">
                                        <label for="dateTo">Дата прибуття</label>
                                        <input id="dateTo" name="dateTo" className="form-control" type="date" onChange={(e) => { this.dateToInput(e) }} placeholder="Оберіть дату повернення" />
                                    </div>
                                </div>
                            </div>
                            <div className="row">
                                <div className="col-sm gutters-19">
                                    <div className="form-group">
                                        <input className="form-control" type="number" onChange={(e) => { this.countsOfNightInput(e) }} placeholder="Оберіть кількість ночей" />
                                    </div>
                                </div>
                                <div className="col-sm gutters-19">
                                    <div className="form-group">
                                        <input className="form-control" type="number" onChange={(e) => { this.countsOfPlacesInput(e) }} placeholder="Оберіть кількість місць" />
                                    </div>
                                </div>
                                <div className="col-sm gutters-19">
                                    <input className="form-control" type="number" onChange={(e) => { this.starInput(e) }} placeholder="Оберіть кількість зірок в готелі" />
                                </div>
                            </div>
                            <div className="row">
                                <div className="col-sm gutters-19">
                                    <div className="form-select-custom">
                                        <select name="" id="" onChange={(e) => { this.comfortSelect(e) }}>
                                            <option value="" disabled selected>Оберіть зручності</option>
                                            {!!filters ?
                                                filters.comforts.map((item, i) => {
                                                    return (
                                                        <option value={item.id}>{item.name}</option>
                                                    )
                                                })
                                                : ""}
                                        </select>
                                    </div>
                                </div>
                                <div className="col-sm gutters-19">
                                    <button className="button button-form" onClick={(e) => { this.submitFilter() }}> Знайти квитки</button>
                                </div>
                            </div>
                        </div>
                    </form>
                    <section className="section-margin section-margin--small">
                        <div className="container">
                            <div className="section-intro text-center pb-80px">
                                <div className="section-intro__style">
                                    <img src="img/home/bed-icon.png" alt="" />
                                </div>
                                <h2>Квиткі в продажі</h2>
                            </div>

                            <div style={{ paddingTop: '5px' }} className="home-page bg-white d-flex flex-wrap justify-content-between">
                                {!!tickets ?
                                    tickets.tickets
                                        .map((item, i) => {
                                            return (
                                                <div className="col-md-6 col-xl-4 mb-5">
                                                    <div className="card card-explore">
                                                        <div className="card-explore__img">
                                                            <img className="card-img" src={`${serverUrl}HotelImages/${item.hotel.photo}`} alt="" />
                                                        </div>
                                                        <div className="card-body">
                                                            <h4 className="card-explore__title">{item.hotel.name} {item.hotel.stars}★</h4>
                                                            <h5 className="card-explore__title">{item.roomType.name}</h5>
                                                            <h5 className="card-explore__price">{item.priceFrom}₴</h5>

                                                            <p style={{ padding: '5px' }} className="card-explore">
                                                                <span style={{ fontWeight: 'bold' }}>Місто:</span> {item.city.name}<br />
                                                                <span style={{ fontWeight: 'bold' }}>Кількість ночей:</span> {item.countsOfNight}<br />
                                                                <span style={{ fontWeight: 'bold' }}>Кількість місць:</span> {item.countsOfPlaces}<br />
                                                            </p>
                                                            <p style={{ padding: '5px' }} className="card-explore">
                                                                <span style={{ fontWeight: 'bold' }}>Дата відправлення:</span> {item.dateFrom}<br />
                                                                <span style={{ fontWeight: 'bold' }}>Дата повернення:</span> {item.dateTo}<br />
                                                            </p>
                                                            <p className="card-explore">
                                                                {
                                                                    item.comforts.map((comfort, i) => {
                                                                        return (<li>{comfort.name}</li>)
                                                                    })
                                                                }
                                                            </p>

                                                            <button style={{ marginTop: '5px' }} className="button button-form" onClick={(e)=>{this.buyTicket(item.id,0,this.state.filter)}}>Додати до кошику <i className="ti-arrow-right"></i></button>
                                                        </div>
                                                    </div>
                                                </div>
                                            );
                                        }) : ""}
                            </div>
                        </div>

                    </section>
                    <footer className="footer-area section-gap" />

                </div>
            </React.Fragment >
        );
    }

}
const mapStateToProps = state => {
    return {
        tickets: get(state, "ticketReducer.list.data.data"),
        filters: get(state, "ticketReducer.list.filters.data"),
        hotels: get(state, "ticketReducer.list.hotels.data"),
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        getFiltredTickets: (indx, filter) => {
            dispatch(getListActions.getTicketsData(indx, filter));
        },
        getFilterData: () => {
            dispatch(getFilterListActions.getFiltersData());
        },
        getHotels: (countryId) => {
            dispatch(getHotelListActions.getHotelsData(countryId));
        },
        buyTicket: (ticketId,indx,filter)=>{
            dispatch(buyTicketListActions.buyTicket(ticketId,indx,filter));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(TicketView);
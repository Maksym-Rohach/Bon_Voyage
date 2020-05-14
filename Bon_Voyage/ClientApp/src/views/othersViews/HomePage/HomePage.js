import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import get from "lodash.get";
import { connect } from "react-redux";
import * as reducer from "./reducer";
import * as loginReducer from '../LoginPage/reducer';
import { getUrlToRedirect} from "../LoginPage/reducer";
import '../instruments/css/style.scss';
import mylogo from '../../../assets/img/Logo.png';
import Loader from '../../../components/Loader/index'
import { serverUrl } from '../../../config';
import bedIcon from '../../../assets/img/bed-icon.png'
import {Button} from 'reactstrap';

//import '../../../scss/customNav/custNavbar.scss'

import Banner1 from "../../../assets/img/welcomeBanner1.png";
import Banner2 from "../../../assets/img/welcomeBanner2.png";
import Banner3 from "../../../assets/img/welcomeBanner3.png";

import Header from './Header';
import Footer from "./Footer";


class HomePage extends Component {
  state = {
    countries: undefined,
    cities: undefined,
    hotels: undefined,
    randomPhotos: [],
    hotTickets: [],
    topHotels: [],
    isLoad: true,
  }


  //3
  // Call reducer
  componentWillMount = () => {
    this.props.getHomeData();
  }

  countrySelectEvent = e => {
    this.props.clearData();

    this.props.getCityData(e.target.value);
    if (this.state.cities.length > 0) {
      this.props.getHotelData(this.state.cities[0].id);
    }

    this.setState({ hotels: [] });
  }

  citySelectEvent = e => {
    this.props.getHotelData(e.target.value);
  }

  componentWillReceiveProps = (nextProps) => { //- Binding    
    console.log(nextProps);
    this.setState({
      countries: nextProps.countriesReducer,
      cities: nextProps.citiesReducer,
      hotels: nextProps.hotelsReducer,

      randomPhotos: nextProps.randomPhotosReducer,
      topHotels: nextProps.topHotelsReducer,
      hotTickets: nextProps.hotTicketsReducer,

      isLoad: nextProps.loadingReducer,
    });
  }



  render() {
    const { countries, cities, hotels, isLoad, randomPhotos,hotTickets,topHotels } = this.state;
    const { isAuthenticated } = this.props;
    console.log("URL to redirect", getUrlToRedirect());

    const page = (
      <React.Fragment>
        <div className="home-page bg-white">
          <header className="header_area">
            <div className="main_menu">
              <nav className="navbar navbar-expand-lg navbar-light">
                <div className="container">
                  <Link className="navbar-brand logo_h" to="/"><img src={mylogo} height="50px" alt="" /></Link>
                  <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                    aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="icon-bar"></span>
                    <span className="icon-bar"></span>
                    <span className="icon-bar"></span>
                  </button>
                  <div className="collapse navbar-collapse offset ml-5" id="navbarSupportedContent">
                    <ul className="nav navbar-nav menu_nav ml-5">
                    <li className="nav-item"> <Link className="nav-link" to="/#/">Головна</Link></li>
                      <li className="nav-item"> <Link className="nav-link" to="/contact-page">Контакти</Link></li>                    
                      <li className="nav-item"> <Link className="nav-link" to="/gallery-page">Галерея</Link></li>
                      {
                        getUrlToRedirect() == "/" ?
                          <li className="nav-item">
                            <Link className="nav-link" to="/login">Вхід</Link>
                          </li>
                          : < li className="nav-item">
                            <Link className="nav-link" to={getUrlToRedirect()}>Особистий кабінет</Link>
                          </li>
                      }
                      {
                        getUrlToRedirect() == "/" ?
                          <li className="nav-item">
                            <Link className="nav-link" to="/Register">Реєстрація</Link>
                          </li>
                          : <li className="nav-item">
                            <Link className="nav-link" onClick={this.props.logout}>Вихід</Link>
                          </li>
                      }



                      <li className="nav-item">
                        <a className="nav-link" href="#">
                          {

                          }
                          <i className="pi pi-shopping-cart" style={{ 'fontSize': '2em' }}></i>
                        </a></li>
                    </ul>
                  </div>
                </div>
              </nav>
            </div>
          </header>
          <main className="site-main">
            <section className="home-banner-area" id="home">
              <div className="container h-100">
                <div className="home-banner">
                  <div className="text-center">
                    <h4>Вибери свою подорож разом з Bon Voyage</h4>
                    <h1>Подорожуй <em>із</em> насолодою</h1>
                    <Link className="button home-banner-btn" to="/tickets">Список квитків</Link>
                  </div>
                </div>
              </div>
            </section>
            <form className="form-search form-search-position">
              <div className="container">
                <div className="row">
                  <div className="col-lg-6 gutters-19">
                    <div className="row">
                      <div className="col-sm">
                        <div className="form-group">
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-sm gutters-19">
                    <div className="form-group">
                      <div className="form-select-custom">
                        <select name="CountriesSelect" onChange={e => this.countrySelectEvent(e)}>
                          <option disabled selected default>Виберіть країну</option>
                          {

                            countries != undefined ?
                              countries.map(item => {
                                return (<option key={item.id} value={item.id} >{item.name}</option>)
                              }) : <div></div>
                          }
                        </select>
                      </div>
                    </div>
                  </div>
                  <div className="col-sm gutters-19">
                    <div className="form-group">
                      <div className="form-select-custom">
                        <select name="CitySelect" onChange={e => this.citySelectEvent(e)}>
                          <option disabled selected default>Виберіть місто</option>
                          {
                            cities != undefined ?
                              (cities.map(item => {
                                return (<option key={item.id} value={item.id} >{item.name}</option>)
                              })) : <div></div>

                          }
                        </select>
                      </div>
                    </div>
                  </div>
                  <div className="col-sm gutters-19">
                    <div className="form-group">
                      <div className="form-select-custom">
                        <select name="HotelSelect">
                          <option disabled selected default>Виберіть готель</option>
                          {                      
                            !!hotels ?
                            hotels.length > 0 ?
                              (hotels.map(item => {
                                return (<option key={item.id} value={item.id} >{item.name}</option>)
                              })) : <div></div> : <div></div>
                          }
                        </select>
                      </div>
                    </div>
                  </div>
                  <div className="col-lg-4 gutters-19">
                    <div className="form-group">
                      <button className="button button-form" type="submit">Пошук квитків</button>
                    </div>
                  </div>
                </div>
              </div>
            </form>
            <section className="welcome">
              <div className="container">
                <div className="row align-items-center">
                  <div className="col-lg-5 mb-4 mb-lg-0">
                    <div className="row no-gutters welcome-images">
                      <div className="col-sm-7">
                        <div className="card">
                          <img className="" src={`${serverUrl}HotelImages/${randomPhotos[0]}`} alt="Card image cap" />
                        </div>
                      </div>
                      <div className="col-sm-5">
                        <div className="card">
                          <img className="" src={`${serverUrl}HotelImages/${randomPhotos[1]}`} alt="Card image cap" />
                        </div>
                      </div>
                      <div className="col-lg-12">
                        <div className="card">
                          <img className="" src={`${serverUrl}HotelImages/${randomPhotos[2]}`} alt="Card image cap" />
                        </div>
                      </div>
                    </div>
                  </div>
                  <div className="col-lg-7">
                    <div className="welcome-content">
                      <h2 className="mb-4"><span className="d-block"></span>Виберіть подорож на свій смак</h2>
                      {/* <p>Beginning blessed second a creepeth. Darkness wherein fish years good air whose after seed appear midst evenin, appear void give third bearing divide one so blessed moved firmament gathered </p>
                    <p>Beginning blessed second a creepeth. Darkness wherein fish years good air whose after seed appear midst evenin, appear void give third bearing divide one so blessed</p> */}
                     
                      <Link to="/details-page">                                                  
                               <Button className="button button--active home-banner-btn mt-4">Дізнатись більше</Button>    
                       </Link>
                    </div>
                  </div>
                </div>
              </div>
            </section>
            <section className="section-margin">
              <div className="container">
                <div className="section-intro text-center pb-80px">
                  <div className="section-intro__style">
                    <img src="img/home/bed-icon.png" alt="" />
                  </div>
                  <h2>Вигідні пропозиції</h2>
                </div>

                <div className="row">
                  {
                    hotTickets.map(item => {      
                      console.log(item.id)              
                      return (                       
                          <div className="col-md-6 col-lg-4 mb-4 mb-lg-0">
                            <div className="card card-explore">
                              <div className="card-explore__img">
                                <img className="card-img" src={`${serverUrl}HotelImages/${item.photo}`} alt="" />
                              </div>
                              <div className="card-body">
                                <h3 className="card-explore__price">₴ {item.price}<sub>/ За Ніч</sub></h3>
                                <h4 className="card-explore__title"><a href="#">{item.hotelName}</a></h4>
                                <p>{item.description}</p>
                                <Link to="/details-page">                                                  
                               <Link to={`/details-page/${item.id}`} className="button button--active home-banner-btn mt-4">Дізнатись більше</Link>    
                              </Link>
                              </div>
                            </div>
                          </div>
                      )
                    })
                  }
                </div>

              </div>
            </section>
            <section className="video-area">
              <div className="container">
                <div className="row justify-content-center align-items-center flex-column text-center">
                  <h3>Ми надаємо широкий вибір квитків</h3>
                  <p>У різні куточки світу</p>
                </div>
              </div>
            </section>
            
          


            <section class="section-margin">
              <div class="container">
                <div class="section-intro text-center pb-80px">
                  <div class="section-intro__style">
                    <img src={bedIcon} alt="" />
                  </div>
                  <h2>Популярні готелі</h2>
                </div>
                <div class="row">
                  {
                    topHotels.map(item => {
                      return (

                        <div class="col-md-6 col-lg-4 mb-4 mb-md-0">
                          <div class="card card-news">
                            <div class="card-news__img">
                              <img class="card-img" src={`${serverUrl}HotelImages/${item.photo}`} alt="" />
                            </div>
                            <div class="card-body">
                              <h4 class="card-news__title"><a href="#">{item.name}</a></h4>
                              <ul class="card-news__info">
                                <li><a href="#"><span class="news-icon"><i class="ti-notepad"></i></span>{item.country},</a></li>
                                <li><a href="#"><span class="news-icon"><i class="ti-notepad"></i></span>{item.city}</a></li>
                              </ul>
                              <p>{item.description}</p>
                              <Link to={`/details-page/${item.id}`}>                                                  
                               <Button className="button button--active home-banner-btn mt-4">Дізнатись більше</Button>    
                             </Link>
                            </div>
                          </div>
                        </div>
                      )
                    })
                  }

             
                                  
                </div>
              </div>
            </section>

          
          

            <footer class="footer-area section-gap">
              {/* <div className="container">
                <div class="row">
                  <div class="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
                    <h4>Наші продукти</h4>
                    <ul>
                      <li><a href="#">Калькулятор на днопаскалі</a></li>
                      <li><a href="#">Менджер паролів на плюсах</a></li>
                      <li><a href="#">Недороблена курсова на MVC</a></li>
                      <li><a href="#">Marketing Service</a></li>
                    </ul>
                  </div>
                  <div class="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
                    <h4>Quick Links</h4>
                    <ul>
                      <li><a href="#">Jobs</a></li>
                      <li><a href="#">Brand Assets</a></li>
                      <li><a href="#">Investor Relations</a></li>
                      <li><a href="#">Terms of Service</a></li>
                    </ul>
                  </div>
                  <div class="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
                    <h4>Features</h4>
                    <ul>
                      <li><a href="#">Jobs</a></li>
                      <li><a href="#">Brand Assets</a></li>
                      <li><a href="#">Investor Relations</a></li>
                      <li><a href="#">Terms of Service</a></li>
                    </ul>
                  </div>
                  <div class="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
                    <h4>Resources</h4>
                    <ul>
                      <li><a href="#">Guides</a></li>
                      <li><a href="#">Research</a></li>
                      <li><a href="#">Experts</a></li>
                      <li><a href="#">Agencies</a></li>
                    </ul>
                  </div>
                  <div class="col-xl-4 col-md-8 mb-4 mb-xl-0 single-footer-widget">
                    <h4>Newsletter</h4>
                    <p>You can trust us. we only send promo offers,</p>
                    <div class="form-wrap" id="mc_embed_signup">
                      <form target="_blank"
                        method="get" class="form-inline">
                        <input class="form-control" name="EMAIL" placeholder="Your Email Address"
                          required="" type="email" />
                        <button class="click-btn btn btn-default text-uppercase">subscribe</button>
                        <div class="info"></div>
                      </form>
                    </div>
                  </div>
                </div>
              </div> */}
            </footer>


          </main>
        </div>
      </React.Fragment>
    );


    return isLoad ? (<Loader />) : page;
  }
}



// 2
// GetReducerData
function mapStateToProps(state) {
  return {
    countriesReducer: get(state, 'home.list.data'),
    loadingReducer: get(state, 'home.list.loading'),
    citiesReducer: get(state, 'home.cities'),
    hotelsReducer: get(state, 'home.hotels'),

    randomPhotosReducer: get(state, 'home.randomPhotos'),
    topHotelsReducer: get(state, 'home.topHotels'),
    hotTicketsReducer: get(state, 'home.hotTickets'),
  };
}

//1
//Call reducer
const mapDispatch = (dispatch) => {
  return {
    getHomeData: () => {
      dispatch(reducer.getHomeData());
    },
    getCityData: (countryId) => {
      dispatch(reducer.getCityData(countryId));
    },
    getHotelData: (cityId) => {
      dispatch(reducer.getHotelData(cityId));
    },
    clearData: () => {
      dispatch(reducer.clearData());
    },
    logout: () => {
      dispatch(loginReducer.logout());
    }
  }
}

export default connect(mapStateToProps, mapDispatch)(HomePage);
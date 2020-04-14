import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import get from "lodash.get";
import { connect } from "react-redux";
import * as reducer from "./reducer";
import * as login from "../LoginPage/reducer";
import '../instruments/css/style.scss';
import Loader from '../../../components/Loader';
//import '../../../scss/customNav/custNavbar.scss'

import Banner1 from "../../../assets/img/welcomeBanner1.png";
import Banner2 from "../../../assets/img/welcomeBanner2.png";
import Banner3 from "../../../assets/img/welcomeBanner3.png";

import Header from './Header';
import Footer from "./Footer";

class HomePage extends Component {
  state = {
    countries: [],
    cities: [],
    hotels: [],
    //randomPhotos:[],
    topTickets: [],
    hotTickets: [],
  }

  //3
  // Call reducer
  componentWillMount = () => {
    this.props.getHomeData();
  }

  countrySelectEvent = e => {
    this.props.getCityData(e.target.value);
    setTimeout(() => {
      this.props.getHotelData(this.state.cities[0].id);
    }, 500);
    // const {id} = e.target.dataSet;
    // this.props.cities = this.props.getCityData({id});
  }

  citySelectEvent = e => {
    this.props.getHotelData(e.target.value);   
  }

  componentWillReceiveProps = (nextProps) => { //- Binding    
    this.setState({
      countries: nextProps.countriesReducer,
      cities: nextProps.citiesReducer,
      hotels: nextProps.hotelsReducer
    });
  }

  render() {

    const { countries, cities, hotels } = this.state;
    const { isAuthenticated, isLoading} = this.props;
console.log("RENDER", countries);
    if(countries!==undefined)
    return (
      <React.Fragment>
        {isLoading && <Loader/>}
      <div className="home-page bg-white">
        <header className="header_area">

          <div className="main_menu">
            <nav className="navbar navbar-expand-lg navbar-light">
              <div className="container">
                <a className="navbar-brand logo_h" href="index.html"><img src="img/logo.png" alt="" /></a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                  aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                  <span className="icon-bar"></span>
                  <span className="icon-bar"></span>
                  <span className="icon-bar"></span>
                </button>
                <div className="collapse navbar-collapse offset" id="navbarSupportedContent">
                  <ul className="nav navbar-nav menu_nav">
                    <li className="nav-item active"><a className="nav-link" href="index.html">Home</a></li>
                    <li className="nav-item"><a className="nav-link" href="about.html">About</a></li>
                    <li className="nav-item"><a className="nav-link" href="properties.html">Properties</a></li>
                    <li className="nav-item"><a className="nav-link" href="gallery.html">Gallery</a></li>

                    {
                      !isAuthenticated ?
                        <li className="nav-item"><a className="nav-link" href="/#/login">Вхід</a></li>
                        : <li className="nav-item"><a className="nav-link" href="#/">Вийти</a></li>
                    }
                    {
                      !isAuthenticated ?
                        <li className="nav-item"><a className="nav-link" href="#/Register">Реєстрація</a></li>
                        : <div></div>
                    }



                    <li className="nav-item">
                      <a className="nav-link" href="#">
                        {

                        }
                        <i class="pi pi-shopping-cart" style={{ 'fontSize': '2em' }}></i>
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
                  {/* <h4>See What a Difference a stay makes</h4> */}
                  <h1>Подорожуй <em>із</em> насолодою</h1>
                  <a className="button home-banner-btn" href="#">Список квитків</a>
                </div>
              </div>
            </div>
          </section>
          <form className="form-search form-search-position">
            <div className="container">
              <div className="row">
                {/* <div className="col-lg-6 gutters-19">
                      <div className="form-group">
                        <input className="form-control" type="text" placeholder="Enter your keywords.." required />
                      </div>
                    </div> */}
                <div className="col-lg-6 gutters-19">
                  <div className="row">
                    <div className="col-sm">
                      <div className="form-group">
                        {/* <div className="form-select-custom">
                              <select name="" id="">
                                <option value="" disabled selected>Arrival</option>
                                <option value="8 AM">8 AM</option>
                                <option value="12 PM">12 PM</option>
                              </select>
                            </div> */}
                      </div>
                    </div>
                    {/* <div className="col-sm gutters-19">
                          <div className="form-group">
                            <div className="form-select-custom">
                              <select name="" id="">
                                <option value="" disabled selected>Number of room</option>
                                <option value="8 AM">8 AM</option>
                                <option value="12 PM">12 PM</option>
                              </select>
                            </div>
                          </div>
                        </div> */}
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-sm gutters-19">
                  <div c lassName="form-group">
                    <div className="form-select-custom">
                      <select name="CountriesSelect" onChange={e => this.countrySelectEvent(e)}>
                        <option disabled selected default>Виберіть країну</option>
                        {
                          countries.map(item => {
                            return (<option key={item.id} value={item.id} >{item.name}</option>)
                          })
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
                          cities.length > 0 ?
                            (cities.map(item => {
                              return (<option key={item.id} value={item.id} >{item.name}</option>)
                            }))
                            : <div></div>
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
                          hotels.length > 0 ?
                          (hotels.map(item => {
                            return (<option key={item.id} value={item.id} >{item.name}</option>)
                          })) : <div></div>
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
                        <img className="" src={Banner1} alt="Card image cap" />
                      </div>
                    </div>
                    <div className="col-sm-5">
                      <div className="card">
                        <img className="" src={Banner2} alt="Card image cap" />
                      </div>
                    </div>
                    <div className="col-lg-12">
                      <div className="card">
                        <img className="" src={Banner3} alt="Card image cap" />
                      </div>
                    </div>
                  </div>
                </div>
                <div className="col-lg-7">
                  <div className="welcome-content">
                    <h2 className="mb-4"><span className="d-block">Welcome</span> to our residence</h2>
                    <p>Beginning blessed second a creepeth. Darkness wherein fish years good air whose after seed appear midst evenin, appear void give third bearing divide one so blessed moved firmament gathered </p>
                    <p>Beginning blessed second a creepeth. Darkness wherein fish years good air whose after seed appear midst evenin, appear void give third bearing divide one so blessed</p>
                    <a className="button button--active home-banner-btn mt-4" href="#">Learn More</a>
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
                <h2>Explore Our Rooms</h2>
              </div>

              <div className="row">
                <div className="col-md-6 col-lg-4 mb-4 mb-lg-0">
                  <div className="card card-explore">
                    <div className="card-explore__img">
                      <img className="card-img" src="img/home/explore1.png" alt="" />
                    </div>
                    <div className="card-body">
                      <h3 className="card-explore__price">$150.00 <sub>/ Per Night</sub></h3>
                      <h4 className="card-explore__title"><a href="#">Classic Bed Room</a></h4>
                      <p>Beginning fourth dominion creeping god was. Beginning, which fly yieldi dry beast moved blessed </p>
                      <a className="card-explore__link" href="#">Book Now <i className="ti-arrow-right"></i></a>
                    </div>
                  </div>
                </div>

                <div className="col-md-6 col-lg-4 mb-4 mb-lg-0">
                  <div className="card card-explore">
                    <div className="card-explore__img">
                      <img className="card-img" src="img/home/explore2.png" alt="" />
                    </div>
                    <div className="card-body">
                      <h3 className="card-explore__price">$170.00 <sub>/ Per Night</sub></h3>
                      <h4 className="card-explore__title"><a href="#">Premium Room</a></h4>
                      <p>Beginning fourth dominion creeping god was. Beginning, which fly yieldi dry beast moved blessed </p>
                      <a className="card-explore__link" href="#">Book Now <i className="ti-arrow-right"></i></a>
                    </div>
                  </div>
                </div>

                <div className="col-md-6 col-lg-4 mb-4 mb-lg-0">
                  <div className="card card-explore">
                    <div className="card-explore__img">
                      <img className="card-img" src="img/home/explore3.png" alt="" />
                    </div>
                    <div className="card-body">
                      <h3 className="card-explore__price">$190.00 <sub>/ Per Night</sub></h3>
                      <h4 className="card-explore__title"><a href="#">Family Room</a></h4>
                      <p>Beginning fourth dominion creeping god was. Beginning, which fly yieldi dry beast moved blessed </p>
                      <a className="card-explore__link" href="#">Book Now <i className="ti-arrow-right"></i></a>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </section>
          <section className="video-area">
            <div className="container">
              <div className="row justify-content-center align-items-center flex-column text-center">
                {/* <a id="play-home-video" className="" href="">
                      <span></span>
                    </a> */}
                <h3>Ми надаємо широкий вибір квитків</h3>
                <p>У різні куточки світу</p>
              </div>
            </div>
          </section>
          <section className="section-padding bg-porcelain">
            <div className="container">
              <div className="section-intro text-center pb-80px">
                <div className="section-intro__style">
                  <img src="img/home/bed-icon.png" alt="" />
                </div>
                <h2>Special Facilities</h2>
              </div>
              <div className="special-img mb-30px">
                <img className="img-fluid" src="img/home/special.png" alt="" />
              </div>

              <div className="row">
                <div className="col-md-6 col-lg-4 mb-4 mb-lg-0">
                  <div className="card card-special">
                    <div className="media align-items-center mb-1">
                      <span className="card-special__icon"><i className="ti-home"></i></span>
                      <div className="media-body">
                        <h4 className="card-special__title">Conference Room</h4>
                      </div>
                    </div>
                    <div className="card-body">
                      <p>Built purse maids cease her ham new seven among and. Pulled coming wooded tended it answer remain</p>
                    </div>
                  </div>
                </div>

                <div className="col-md-6 col-lg-4 mb-4 mb-lg-0">
                  <div className="card card-special">
                    <div className="media align-items-center mb-1">
                      <span className="card-special__icon"><i className="ti-bell"></i></span>
                      <div className="media-body">
                        <h4 className="card-special__title">Swimming Pool</h4>
                      </div>
                    </div>
                    <div className="card-body">
                      <p>Built purse maids cease her ham new seven among and. Pulled coming wooded tended it answer remain</p>
                    </div>
                  </div>
                </div>

                <div className="col-md-6 col-lg-4 mb-4 mb-lg-0">
                  <div className="card card-special">
                    <div className="media align-items-center mb-1">
                      <span className="card-special__icon"><i className="ti-car"></i></span>
                      <div className="media-body">
                        <h4 className="card-special__title">Sports Culb</h4>
                      </div>
                    </div>
                    <div className="card-body">
                      <p>Built purse maids cease her ham new seven among and. Pulled coming wooded tended it answer remain</p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </section>
        </main>
      </div>
      </React.Fragment>
    );
  }
}



// 2
// GetReducerData
function mapStateToProps(state) {
  console.log("mapStateToProps", state);
  return {
    countriesReducer: get(state, 'home.list.data.countries'),
    citiesReducer: get(state, 'home.cities'),
    hotelsReducer: get(state, 'home.hotels'),
    isLoading: get(state, 'home.list.loading')
  };
}

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
    }
  };
};
//1
//Call reducer
// const mapDispatch = {
//   getHomeData: () => {
//     return reducer.getHomeData();
//   },
//   getCityData: (countryId) => {
//     return reducer.getCityData(countryId);
//   },
//   getHotelData: (cityId) => {
//     return reducer.getHotelData(cityId);
//   }
// }

export default connect(mapStateToProps, mapDispatch)(HomePage);
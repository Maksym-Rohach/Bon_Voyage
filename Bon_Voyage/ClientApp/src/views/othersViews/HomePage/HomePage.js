import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import get from "lodash.get";
import { connect } from "react-redux";

import '../instruments/css/style.scss';
//import '../../../scss/customNav/custNavbar.scss'

import Banner1 from "../../../assets/img/welcomeBanner1.png";
import Banner2 from "../../../assets/img/welcomeBanner2.png";
import Banner3 from "../../../assets/img/welcomeBanner3.png";

import Header from './Header';
import Footer from "./Footer";

class HomePage extends Component {
  state = {
    isAuth: false,
    countries: [],
    cities: [],
    hotels: [],
    //randomPhotos:[],
    topTickets:[],
    hotTickets:[]
  }



    render() { 
        const {isAuth} = this.state;
        return (  
          <div className="home-page bg-white">
            <header className="header_area">
              {/* <div className="header-top">
            <div className="container">
                <div className="d-flex align-items-center">
                    <div id="logo">
                        <a href="index.html"><img src="img/Logo.png" alt="" title="" /></a>
                    </div>
                    <div className="ml-auto d-none d-md-block d-md-flex">
                        <div className="media header-top-info">
                            <span className="header-top-info__icon"><i className="fas fa-phone-volume"></i></span>
                            <div className="media-body">
                                <p>Have any question?</p>
                                <p>Free: <a href="tel:+12 365 5233">+12 365 5233</a></p>
                            </div>
                        </div>
                        <div className="media header-top-info">
                            <span className="header-top-info__icon"><i className="ti-email"></i></span>
                            <div className="media-body">
                                <p>Have any question?</p>
                                <p>Free: <a href="tel:+12 365 5233">+12 365 5233</a></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div> */}
              <div className="main_menu">

                {/* <div class="site-wrap">

                  <div class="site-mobile-menu site-navbar-target">
                    <div class="site-mobile-menu-header">
                      <div class="site-mobile-menu-close mt-3">
                        <span class="icon-close2 js-menu-toggle"></span>
                      </div>
                    </div>
                    <div class="site-mobile-menu-body"></div>
                  </div>



                  <div class="header-top bg-light">
                    <div class="col-6   text-left">
                      <a href="#" class="d-inline-block d-lg-none site-menu-toggle js-menu-toggle text-black"><span
                        class="icon-menu h3"></span></a>
                    </div>
                    <div class="site-navbar py-2 js-sticky-header site-navbar-target d-none pl-0 d-lg-block" role="banner">
                      <div class="container">
                        <div class="d-flex align-items-center">
                          <div class="mx-auto">
                            <nav>
                              <ul class="site-menu main-menu js-clone-nav mr-auto d-none pl-0 d-lg-block">
                                <li class="active">
                                  <a href="index.html" class="nav-link text-left">Home</a>
                                </li>
                                <li>
                                  <a href="about.html" class="nav-link text-left">About Us</a>
                                </li>
                                <li>
                                  <a href="services.html" class="nav-link text-left">Services</a>
                                </li>
                                <li>
                                  <a href="testimonials.html" class="nav-link text-left">Testimonials</a>
                                </li>
                                <li><a href="blog.html" class="nav-link text-left">Blog</a></li>
                                <li>
                                  <a href="contact.html" class="nav-link text-left">Contact</a>
                                </li>
                              </ul>
                            </nav>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>  */}







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
                        !isAuth ? 
                        ( <li className="nav-item"><a className="nav-link" href="/#/login">Вхід</a></li>,
                        <li className="nav-item"><a className="nav-link" href="#">Реєстрація</a></li>)             
                      : (<li className="nav-item"><a className="nav-link" href="#">Вийти</a></li>)
                      }
                        
                        <li className="nav-item">
                          <a className="nav-link" href="#">
                            {
                              
                            }
                          <i class="pi pi-shopping-cart" style={{'fontSize': '2em'}}></i>
                          </a></li>
                        </ul>
                    </div>                 
                </div>
            </nav>
             {/* <div className="search_input" id="search_input_box">
                <div className="container">
                    <form className="d-flex justify-content-between">
                        <input type="text" className="form-control" id="search_input" placeholder="Search Here" />
                        <button type="submit" className="btn"></button>
                        <span className="lnr lnr-cross" id="close_search" title="Close Search"></span>
                    </form>
                </div>
            </div>  */}
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
                      <div c  lassName="form-group">
                        <div className="form-select-custom">
                          <select name="CountriesSelect" id="">
                            <option value="" disabled selected default>Країни</option>
                            <option value="">США</option>
                            <option value="">Італія</option>
                          </select>
                        </div>
                      </div>
                    </div>
                    <div className="col-sm gutters-19">
                      <div className="form-group">
                        <div className="form-select-custom">
                          <select name="CitySelect" id="">
                            <option value="" disabled selected default>Місто</option>
                            <option value=""></option>
                            <option value=""></option>
                          </select>
                        </div>
                      </div>
                    </div>
                    <div className="col-sm gutters-19">
                      <div className="form-group">
                        <div className="form-select-custom">
                          <select name="HotelSelect" id="">
                            <option value="" disabled selected default>Готель</option>
                            <option value="8 AM">8 AM</option>
                            <option value="12 PM">12 PM</option>
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
              {/* <section className="section-margin">
                <div className="container">
                  <div className="section-intro text-center pb-20px">
                    <div className="section-intro__style">
                      <img src="img/home/bed-icon.png" alt="" />
                    </div>
                    <h2>Our Guest Love Us</h2>
                  </div>
                  <div className="owl-carousel owl-theme testi-carousel">
                    <div className="testi-carousel__item">
                      <div className="media">
                        <div className="testi-carousel__img">
                          <img src="img/home/testimonial1.png" alt="" />
                        </div>
                        <div className="media-body">
                          <p>Incidunt deleniti blanditiis quas aperiam recusandae consillo ullam quibusdam cum libero illo repell endus!</p>
                          <div className="testi-carousel__intro">
                            <h3>Robert Mack</h3>
                            <p>CEO & Founder</p>
                          </div>
                        </div>
                      </div>
                    </div>

                    <div className="testi-carousel__item">
                      <div className="media">
                        <div className="testi-carousel__img">
                          <img src="img/home/testimonial2.png" alt="" />
                        </div>
                        <div className="media-body">
                          <p>Incidunt deleniti blanditiis quas aperiam recusandae consillo ullam quibusdam cum libero illo repell endus!</p>
                          <div className="testi-carousel__intro">
                            <h3>David Alone</h3>
                            <p>CEO & Founder</p>
                          </div>
                        </div>
                      </div>
                    </div>

                    <div className="testi-carousel__item">
                      <div className="media">
                        <div className="testi-carousel__img">
                          <img src="img/home/testimonial3.png" alt="" />
                        </div>
                        <div className="media-body">
                          <p>Incidunt deleniti blanditiis quas aperiam recusandae consillo ullam quibusdam cum libero illo repell endus!</p>
                          <div className="testi-carousel__intro">
                            <h3>Adam Pallin</h3>
                            <p>CEO & Founder</p>
                          </div>
                        </div>
                      </div>
                    </div>

                    <div className="testi-carousel__item">
                      <div className="media">
                        <div className="testi-carousel__img">
                          <img src="img/home/testimonial1.png" alt="" />
                        </div>
                        <div className="media-body">
                          <p>Incidunt deleniti blanditiis quas aperiam recusandae consillo ullam quibusdam cum libero illo repell endus!</p>
                          <div className="testi-carousel__intro">
                            <h3>Robert Mack</h3>
                            <p>CEO & Founder</p>
                          </div>
                        </div>
                      </div>
                    </div>

                    <div className="testi-carousel__item">
                      <div className="media">
                        <div className="testi-carousel__img">
                          <img src="img/home/testimonial2.png" alt="" />
                        </div>
                        <div className="media-body">
                          <p>Incidunt deleniti blanditiis quas aperiam recusandae consillo ullam quibusdam cum libero illo repell endus!</p>
                          <div className="testi-carousel__intro">
                            <h3>David Alone</h3>
                            <p>CEO & Founder</p>
                          </div>
                        </div>
                      </div>
                    </div>

                    <div className="testi-carousel__item">
                      <div className="media">
                        <div className="testi-carousel__img">
                          <img src="img/home/testimonial3.png" alt="" />
                        </div>
                        <div className="media-body">
                          <p>Incidunt deleniti blanditiis quas aperiam recusandae consillo ullam quibusdam cum libero illo repell endus!</p>
                          <div className="testi-carousel__intro">
                            <h3>Adam Pallin</h3>
                            <p>CEO & Founder</p>
                          </div>
                        </div>
                      </div>
                    </div>

                    <div className="testi-carousel__item">
                      <div className="media">
                        <div className="testi-carousel__img">
                          <img src="img/home/testimonial1.png" alt="" />
                        </div>
                        <div className="media-body">
                          <p>Incidunt deleniti blanditiis quas aperiam recusandae consillo ullam quibusdam cum libero illo repell endus!</p>
                          <div className="testi-carousel__intro">
                            <h3>Robert Mack</h3>
                            <p>CEO & Founder</p>
                          </div>
                        </div>
                      </div>
                    </div>

                    <div className="testi-carousel__item">
                      <div className="media">
                        <div className="testi-carousel__img">
                          <img src="img/home/testimonial2.png" alt="" />
                        </div>
                        <div className="media-body">
                          <p>Incidunt deleniti blanditiis quas aperiam recusandae consillo ullam quibusdam cum libero illo repell endus!</p>
                          <div className="testi-carousel__intro">
                            <h3>David Alone</h3>
                            <p>CEO & Founder</p>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </section> */}
              {/* <section className="section-margin">
                <div className="container">
                  <div className="section-intro text-center pb-80px">
                    <div className="section-intro__style">
                      <img src="img/home/bed-icon.png" alt="" />
                    </div>
                    <h2>News & Events</h2>
                  </div>

                  <div className="row">
                    <div className="col-md-6 col-lg-4 mb-4 mb-md-0">
                      <div className="card card-news">
                        <div className="card-news__img">
                          <img className="card-img" src="img/home/explore1.png" alt="" />
                        </div>
                        <div className="card-body">
                          <h4 className="card-news__title"><a href="#">Hotel companies tipped the scales</a></h4>
                          <ul className="card-news__info">
                            <li><a href="#"><span className="news-icon"><i className="ti-notepad"></i></span> 20th Nov, 2018</a></li>
                            <li><a href="#"><span className="news-icon"><i className="ti-comment"></i></span> 03 Comments</a></li>
                          </ul>
                          <p>Not thoughts all exercise blessing Indulgence way everything joy alteration boisterous the attachment party we years to order</p>
                          <a className="card-news__link" href="#">Read More <i className="ti-arrow-right"></i></a>
                        </div>
                      </div>
                    </div>

                    <div className="col-md-6 col-lg-4 mb-4 mb-md-0">
                      <div className="card card-news">
                        <div className="card-news__img">
                          <img className="card-img" src="img/home/explore2.png" alt="" />
                        </div>
                        <div className="card-body">
                          <h4 className="card-news__title"><a href="#">Try your hand inaugural industry crossword</a></h4>
                          <ul className="card-news__info">
                            <li><a href="#"><span className="news-icon"><i className="ti-notepad"></i></span> 20th Nov, 2018</a></li>
                            <li><a href="#"><span className="news-icon"><i className="ti-comment"></i></span> 03 Comments</a></li>
                          </ul>
                          <p>Not thoughts all exercise blessing Indulgence way everything joy alteration boisterous the attachment party we years to order</p>
                          <a className="card-news__link" href="#">Read More <i className="ti-arrow-right"></i></a>
                        </div>
                      </div>
                    </div>

                    <div className="col-md-6 col-lg-4 mb-4 mb-md-0">
                      <div className="card card-news">
                        <div className="card-news__img">
                          <img className="card-img" src="img/home/explore3.png" alt="" />
                        </div>
                        <div className="card-body">
                          <h4 className="card-news__title"><a href="#">Hoteliers resolve to invest in guests</a></h4>
                          <ul className="card-news__info">
                            <li><a href="#"><span className="news-icon"><i className="ti-notepad"></i></span> 20th Nov, 2018</a></li>
                            <li><a href="#"><span className="news-icon"><i className="ti-comment"></i></span> 03 Comments</a></li>
                          </ul>
                          <p>Not thoughts all exercise blessing Indulgence way everything joy alteration boisterous the attachment party we years to order</p>
                          <a className="card-news__link" href="#">Read More <i className="ti-arrow-right"></i></a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </section> */}
            </main>
          </div>                        
                         
        );
    }
}


function mapStateToProps(state) {
  // console.log("mapStateToProps", state);
  // return {
  //   loading: get(state, 'login.post.loading'),
  //   failed: get(state, 'login.post.failed'),
  //   success: get(state, 'login.post.success'),
  //   errors: get(state, 'login.post.errors')
  // }
}

const mapDispatch = {
  // login: (model, history) => {
  //     return loginActions.login(model, history);
  // }
}
 
export default connect(mapStateToProps, mapDispatch)(HomePage);
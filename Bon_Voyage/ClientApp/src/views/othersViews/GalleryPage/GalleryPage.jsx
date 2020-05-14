import React, { Component } from "react";

import "../instruments/css/style.scss";
import "../instruments/vendors/linericon/style.css";
import mylogo from "../../../assets/img/Logo.png";
import g1 from "../instruments/img/gallery/g1.png";
import g2 from "../instruments/img/gallery/g2.png";
import bedicon from "../instruments/img/home/bed-icon.png";
import g3 from "../instruments/img/gallery/g3.png";
import g4 from "../instruments/img/gallery/g4.png";
import g5 from "../instruments/img/gallery/g5.png";
import g6 from "../instruments/img/gallery/g6.png";
import g7 from "../instruments/img/gallery/g7.png";

import { Link } from "react-router-dom";
import get from "lodash.get";
import { connect } from "react-redux";
import * as reducer from "./reducer";

import { serverUrl } from "../../../config";
import Loader from "../../../components/Loader/index";

class Gallery extends Component {
  state = {
    photos: [],
    isLoad: false,
  };

  //3
  // Call reducer
  componentWillMount = () => {
    this.props.getGalleryPhotos();
  };

  //4
  // Binding
  componentWillReceiveProps = (nextProps) => {
    //- Binding
    console.log(nextProps.photosReducer);
    this.setState({
      photos: nextProps.photosReducer,
      isLoad: nextProps.loadingReducer,
    });
  };

  render() {
    const { photos, isLoad } = this.state;

    const page = (
      <React.Fragment>
        <div className="home-page bg-white">
          <header className="header_area">
            <div className="main_menu">
              <nav className="navbar navbar-expand-lg navbar-light">
                <div className="container">
                  <Link className="navbar-brand logo_h" to="/">
                    <img src={mylogo} height="50px" alt="" />
                  </Link>
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
          <section className="contact-banner-area" id="gallery">
            <div className="container h-100">
              <div className="contact-banner">
                <div className="text-center">
                  <h1>Галерея</h1>
                  <nav aria-label="breadcrumb" className="banner-breadcrumb">
                    <ol className="breadcrumb">
                      <li className="breadcrumb-item">
                        <a href="/#/">Home</a>
                      </li>
                      <li
                        className="breadcrumb-item active"
                        aria-current="page"
                      >
                        Галерея
                      </li>
                    </ol>
                  </nav>
                </div>
              </div>
            </div>
          </section>

          <section className="section-margin">
            <div className="container">
              <div className="section-intro text-center pb-80px">
                <div className="section-intro__style">
                  <img src={bedicon} alt="" />
                </div>
                <h2>Наша Галерея</h2>
              </div>

              {photos != undefined ? (
                photos.map((item, index, array) => {
                  if (index < array.length / 4) {
                    console.log(index);
                    return (
                      <div class="row d-flex justify-content-center">
                        <div class="col-md-5">
                          <div class="row">
                            <div className="col-12 mb-4">
                              <a className="img-gal card-img">
                                <div className="single-imgs relative">
                                  <div className="overlay overlay-bg"></div>
                                  <div className="relative">
                                    <img
                                      className="card-img rounded-0"
                                      src={`${serverUrl}HotelImages/${
                                        photos[array.indexOf(item)].photo
                                      }`}
                                      alt=""
                                    />
                                  </div>
                                </div>
                              </a>
                            </div>
                            <div className="col-12 mb-4">
                              <a className="img-gal card-img">
                                <div className="single-imgs relative">
                                  <div className="overlay overlay-bg"></div>
                                  <div className="relative">
                                    <img
                                      className="card-img rounded-0"
                                      src={`${serverUrl}HotelImages/${
                                        photos[array.indexOf(item) + 1].photo
                                      }`}
                                      alt=""
                                    />
                                  </div>
                                </div>
                              </a>
                            </div>
                          </div>
                        </div>

                        <div class="col-md-5">
                          <div class="row">
                            <div className="col-12 mb-4">
                              <a className="img-gal card-img">
                                <div className="single-imgs relative">
                                  <div className="overlay overlay-bg"></div>
                                  <div className="relative">
                                    <img
                                      className="card-img rounded-0"
                                      src={`${serverUrl}HotelImages/${
                                        photos[array.indexOf(item) + 2].photo
                                      }`}
                                      alt=""
                                    />
                                  </div>
                                </div>
                              </a>
                            </div>
                            <div className="col-12 mb-4">
                              <a className="img-gal card-img">
                                <div className="single-imgs relative">
                                  <div className="overlay overlay-bg"></div>
                                  <div className="relative">
                                    <img
                                      className="card-img rounded-0"
                                      src={`${serverUrl}HotelImages/${
                                        photos[array.indexOf(item) + 3].photo
                                      }`}
                                      alt=""
                                    />
                                  </div>
                                </div>
                              </a>
                            </div>
                          </div>
                        </div>
                      </div>
                    );
                  }
                })
              ) : (
                <div></div>
              )}
            </div>
          </section>

          <footer className="footer-area section-gap">
            <div className="row">
              <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget"></div>
              <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
                >
              </div>
              <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget"></div>
              <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget"></div>
              <div className="col-xl-4 col-md-8 mb-4 mb-xl-0 single-footer-widget"></div>
            </div>
          </footer>
          <div className="footer-bottom row align-items-center text-center text-lg-left"></div>
        </div>
      </React.Fragment>
    );

    return isLoad ? <Loader /> : page;
  }
}

// 2
// GetReducerData
function mapStateToProps(state) {
  return {
    photosReducer: get(state, "gallery.photos.data"),
    
    loadingRecuer: get(state, "gallery.photos.loading"),
  };
}

//1
//Call reducer
const mapDispatch = (dispatch) => {
  return {
    getGalleryPhotos: () => {
      dispatch(reducer.getGalleryPhotos());
    },
  };
};

export default connect(mapStateToProps, mapDispatch)(Gallery);

import React, { Component } from "react";
import get from "lodash.get";
import { serverUrl } from "../../../config";
import "../instruments/css/style.scss";
import "../instruments/vendors/linericon/style.css";
import img1 from "../instruments/img/blog/main-blog/m-blog-1.jpg";
import mylogo from "../../../assets/img/Logo.png";
import { Link } from "react-router-dom";
import blog1 from "../instruments/img/blog/popular-post/post1.jpg";
import prev from "../instruments/img/blog/main-blog/m-blog-1.jpg";
import * as reducer from "./reducer";
import { connect } from "react-redux";

class Details extends Component {
  state = {
    name:'',
    mainPhoto:'',
    countryPhoto:'',
    hotelPhotos:[],
    description:'',
    country:'',
    city:'',

  };
 componentDidMount = () => {
  let tmp=this.props.match.params.id;
     this.props.GetHotelInfo(tmp);
     
 };
  componentWillReceiveProps = (nextProps) => {  
    console.log("MainPhoto : ",nextProps.hotel.mainPhoto);
    console.log("hotelphotos",nextProps.hotel.hotelPhotos)
    this.setState({
      mainPhoto: nextProps.hotel.mainPhoto,
      name:nextProps.hotel.name,    
      countryPhoto: nextProps.hotel.countryPhoto,
      description:nextProps.hotel.description,
      country:nextProps.hotel.country,
      city:nextProps.hotel.city,
      hotelPhotos:nextProps.hotel.hotelPhotos
    });
    
  };

  render() {
    const { hotel} = this.props;
    console.log("Hotel",hotel);
    const form = (
      <div className="home-page bg-white">
        <header className="header_area">
          <div className="main_menu">
            <nav className="navbar navbar-expand-lg navbar-light">
              <div className="container">
                <a className="navbar-brand logo_h" href="/#/">
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
                      <Link className="nav-link" to="/gallery-page">
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
                      
                        {" "}
                        <a href="tel:++38 067 557 8704">+067 557 8704</a>
                     
                    </div>
                  </div>
                  <div className="media header-top-info">
                    <span className="header-top-info__icon">
                      <i className="fa fa-envelope" aria-hidden="true"></i>
                    </span>
                    <div className="media-body">
                      <p>Маєте питання?</p>
                      <p>
                      <a href="bonvoyagevirus@gmail.com">bonvoyagevirus@gmail.com</a>
                      </p>
                    </div>
                  </div>
                </div>
              </div>
            </nav>
          </div>
        </header>

        <section className="blog-banner-area" id="blog">
          <div className="container h-100">
            <div className="blog-banner">
              <div className="text-center">
                <h1>Інформація про готель</h1>
                <nav aria-label="breadcrumb" className="banner-breadcrumb">
              
                </nav>
              </div>
            </div>
          </div>
        </section>

        <section className="blog_area single-post-area py-80px">
          <div className="container">
            <div className="row">
              <div className="col-lg-8 posts-list">
                <div className="single-post row">
                  <div className="col-lg-12">
                    <div className="feature-img">
                      <img className="img-fluid" src={`${serverUrl}HotelImages/${hotel.mainPhoto}`} alt="" />
                    </div>
                  </div>                 
                  <div className="col-lg-3  col-md-3">
                    <div className="blog_info text-right">
                      <ul className="blog_meta list">
                        <li>
                          <a href="#">
                           
                            <i className="lnr lnr-user"></i>
                          </a>
                        </li>
                        <li>
                          <a href="#">
                            
                            <i className="lnr lnr-calendar-full"></i>
                          </a>
                        </li>
                        <li>
                          <a href="#">
                           
                            <i className="lnr lnr-eye"></i>
                          </a>
                        </li>
                        <li>
                          <a href="#">
                          
                            <i className="lnr lnr-bubble"></i>
                          </a>
                        </li>
                      </ul>
                    </div>
                  </div>
                  <div className="col-lg-9 col-md-9 blog_details">
                    <h2>{hotel.name}</h2>
                    <p className="excert">
                      {hotel.description}
                    </p>                 
                  </div>
                  <div className="col-lg-12">
                  
                    <div className="row">
                      <div className="col-6">
                        <img className="img-fluid" src={`${serverUrl}HotelImages/1280_${this.state.hotelPhotos[3]}`} alt="" />
                      </div>
                      <div className="col-6">
                        <img className="img-fluid" src={`${serverUrl}HotelImages/1280_${this.state.hotelPhotos[2]}`} />
                      </div>
                      <div className="col-lg-12 mt-4">                                           
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-lg-4">
                <div className="blog_right_sidebar">
                  <aside className="single_sidebar_widget author_widget mb-3">
                    <img
                      className="author_img"
                      src={`${serverUrl}HotelImages/250_${this.state.hotelPhotos[1]}`}
                      alt=""
                    />
                    <h4>Готель</h4>          
                  </aside>
                 
                 <aside class="single_sidebar_widget post_category_widget">												
													<ul class="list cat-list">
															<li>
																	<a href="#" class="d-flex justify-content-between">
																			<p>Назва готеля</p>
																			<p>{hotel.name}</p>
																	</a>
                                  <a href="#" class="d-flex justify-content-between">
																			<p>Кількість зірок</p>
																			<p>{hotel.stars}</p>
																	</a>
                                  <a href="#" class="d-flex justify-content-between">
																			<p>Країна</p>
																			<p>{hotel.country}</p>
																	</a>
                                  <a href="#" class="d-flex justify-content-between">
																			<p>Місто</p>
																			<p>{hotel.city}</p>
																	</a>
															</li>
														
													</ul>
													<div class="br"></div>
											</aside>
                   </div>
              </div>
            </div>
          </div>
        </section>

        <footer className="footer-area section-gap">
          <div className="container">
            <div className="row">
              <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget"></div>
              <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget"></div>
              <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget"></div>
              <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget"></div>
              <div className="col-xl-4 col-md-8 mb-4 mb-xl-0 single-footer-widget"></div>
            </div>
          </div>
        </footer>
      </div>
    );

    return form;
  }
}

function mapStateToProps(state) {
  console.log("mapstate",state)
  return {

    hotel:get(state,"details.list.data")

  };
}
const mapDispatch=(dispatch)=>{
  return{
    GetHotelInfo:(tmp)=>{
      dispatch(reducer.GetHotelInfo(tmp));
    }
  };
};

export default connect(mapStateToProps,mapDispatch)(Details);

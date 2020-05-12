import React, { Component } from "react";
import "../instruments/css/style.scss";
import "../instruments/vendors/linericon/style.css";
import img1 from "../instruments/img/blog/main-blog/m-blog-1.jpg";
import mylogo from "../../../assets/img/Logo.png";
import { Link } from "react-router-dom";
import blog1 from "../instruments/img/blog/popular-post/post1.jpg";
import author from "../instruments/img/blog/author.png";

class Details extends Component {
  state = {};

  render() {
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
                        Контакти
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
                        Контакти
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
                        Free: <a href="tel:+38 096 6666666">+38 096 6666666</a>
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
                  <ol className="breadcrumb">
                    <li className="breadcrumb-item">
                      <Link to="/#">Головна</Link>
                    </li>
                    <li className="breadcrumb-item">
                      <Link to="/details-page">Деталі</Link>
                    </li>
                    <li className="breadcrumb-item active" aria-current="page">
                      Д
                    </li>
                  </ol>
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
                      <img className="img-fluid" src={img1} alt="" />
                    </div>
                  </div>
                  <div className="col-lg-3  col-md-3">
                    <div className="blog_info text-right">
                      <ul className="blog_meta list">
                        <li>
                          <a href="#">
                            Mark wiens
                            <i className="lnr lnr-user"></i>
                          </a>
                        </li>
                        <li>
                          <a href="#">
                            12 Dec, 2017
                            <i className="lnr lnr-calendar-full"></i>
                          </a>
                        </li>
                        <li>
                          <a href="#">
                            1.2M Views
                            <i className="lnr lnr-eye"></i>
                          </a>
                        </li>
                        <li>
                          <a href="#">
                            06 Comments
                            <i className="lnr lnr-bubble"></i>
                          </a>
                        </li>
                      </ul>
                    </div>
                  </div>
                  <div className="col-lg-9 col-md-9 blog_details">
                    <h2>Astronomy Binoculars A Great Alternative</h2>
                    <p className="excert">
                      MCSE boot camps have its supporters and its detractors.
                      Some people do not understand why you should have to spend
                      money
                    </p>
                    <p>
                      Boot camps have its supporters and its detractors. Some
                      people do not understand why you should have to spend
                      money on boot
                    </p>
                    <p>
                      Boot camps have its supporters and its detractors. Some
                      people do not understand why you should have to spend
                      money on boot
                    </p>
                  </div>
                  <div className="col-lg-12">
                    <div className="quotes">
                      MCSE boot camps have its supporters and its detractors.
                      Some people do not understand why you should have to spend
                      money
                    </div>
                    <div className="row">
                      <div className="col-6">
                        <img className="img-fluid" src={img1} alt="" />
                      </div>
                      <div className="col-6">
                        <img className="img-fluid" src={img1} alt="" />
                      </div>
                      <div className="col-lg-12 mt-4">
                        <p>
                          MCSE boot camps have its supporters and its
                          detractors. Some people do not understand why you
                          should have to spend money
                        </p>
                        <p>
                          MCSE boot camps have its supporters and its
                          detractors. Some people do not understand why you
                          should have to spend money
                        </p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-lg-4">
                <div className="blog_right_sidebar">
                  <aside className="single_sidebar_widget author_widget">
                    <img
                      className="author_img rounded-circle"
                      src={author}
                      alt=""
                    />
                    <h4>Charlie Barber</h4>
                    <p>Senior blog writer</p>

                    <p>
                      Boot camps have its supporters andit sdetractors. Some
                      people do not understand why you should have to spend
                      money on boot camp when you can get. Boot camps have
                      itssuppor ters andits detractors.
                    </p>
                  </aside>
                  <aside className="single_sidebar_widget ads_widget">
                    <a href="#">
                      <img
                        className="img-fluid"
                        src="img/blog/add.jpg"
                        alt=""
                      />
                    </a>
                  </aside>
                  <aside className="single-sidebar-widget tag_cloud_widget">
                    {" "}
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

export default Details;

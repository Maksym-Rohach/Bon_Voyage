import React, { Component } from 'react';
import Iframe from 'react-iframe'
import { Link } from 'react-router-dom';
import '../instruments/css/style.scss';
import '../instruments/vendors/linericon/style.css'
import mylogo from '../../../assets/img/Logo.png';

class Contact extends Component {
  state={}
  render(){
    return(
      
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
      <div className="collapse navbar-collapse offset" id="navbarSupportedContent">
        <ul className="nav navbar-nav menu_nav">
          <li className="nav-item active"><Link className="nav-link" to="/">Головна</Link></li>
          <li className="nav-item"> <Link className="nav-link" to="/contact-page">Контакти</Link></li>
          <li className="nav-item"><Link className="nav-link" to="/gallery-page">Галерея</Link></li>
        </ul>       
      </div>
      <div className="ml-auto d-none d-md-block d-md-flex" >
            <div className="media header-top-info">
              <span className="header-top-info__icon"><i className="fa fa-phone"></i></span>
              <div className="media-body">
                <p>Маєте питання?</p>
                <p>Free: <a href="tel:++38 096 6666666">++38 096 6666666</a></p>
              </div>
            </div>
            <div className="media header-top-info">
              <span className="header-top-info__icon"><i class="fa fa-envelope" aria-hidden="true"></i></span>
              <div className="media-body">
                <p>Have any question?</p>
                <p>Free: <a href="tel:+38 096 6666666">+38 096 6666666</a></p>
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
          <h1>Контакти</h1>
          <nav aria-label="breadcrumb" className="banner-breadcrumb">
            <ol className="breadcrumb">
              <li className="breadcrumb-item"><a href="#">Головна</a></li>
              <li className="breadcrumb-item active" aria-current="page">Контакти</li>
            </ol>
          </nav>
        </div>
      </div>
    </div>
  </section>
   
  
  
  <section class="section-margin">
    <div class="container">
   
      <div class="d-none d-sm-block mb-5 pb-4">
        <div id="map" style={{height: '420px'}}>
        <Iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3580.155688092591!2d26.25886499832669!3d50.61685488613916!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x472f134609e1331f:0x4b4b27390f364d81!2z0JrQvtC80L8n0Y7RgtC10YDQvdCwINCQ0LrQsNC00LXQvNGW0Y8g0KjQkNCT!5e0!3m2!1sru!2sua!4v1588261875083!5m2!1sru!2sua" 
        width="1100" height="480" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></Iframe>
        </div>
        
       
      </div>
     


      <div class="row">
        <div class="col-md-4 col-lg-3 mb-4 mb-md-0">
          <div class="media contact-info">
            <span class="contact-info__icon"><i class="fa fa-home" aria-hidden="true"></i></span>
            <div class="media-body">
              <h3>Україна</h3>
              <p>м.Рівне , вул.Соборна 666</p>
            </div>
          </div>
          <div class="media contact-info">
            <span class="contact-info__icon"><i class="fa fa-headphones" aria-hidden="true"></i></span>
            <div class="media-body">
              <h3><a href="tel:+38 096 6666666">+38 096 6666666</a></h3>
              <p>З понеділка по пятницю з 8:00 До 20:00</p>
            </div>
          </div>
          <div class="media contact-info">
            <span class="contact-info__icon"><i class="fa fa-envelope" aria-hidden="true"></i></span>
            <div class="media-body">
              <h3><a href="mailto:support@colorlib.com">bonvoyagevirus@gmail.com</a></h3>
              <p>Присилайте нам на електронну пошту свої питання</p>
            </div>
          </div>
        </div>
        <div class="col-md-8 col-lg-9">
          <form class="row contact_form" action="contact_process.php" method="post" id="contactForm"
              novalidate="novalidate">
              <div class="col-md-6">
                  <div class="form-group" >
                      <input type="text" class="form-control" id="name" name="name" placeholder="Введіть своє ім`я" />
                  </div>
                  <div class="form-group">
                      <input type="email" class="form-control" id="email" name="email" placeholder="Введіть свою електронну пошту" />
                  </div>
                  <div class="form-group">
                      <input type="text" class="form-control" id="subject" name="subject" placeholder="Введіть тему" />
                  </div>
              </div>
              <div class="col-md-6">
                  <div class="form-group">
                      <textarea class="form-control different-control" name="message" id="message" rows="5" placeholder="Напишіть своє питання"></textarea>
                  </div>
              </div>
              <div class="col-md-12 text-right">
              <Link to="/client/message"> 
                  <button type="submit" value="submit" class="button-contact"><span>Відправити</span></button>
                  </Link>
              </div>
          </form>
        </div>
      </div>
    </div>
  </section>
    
    
  
  
  <footer className="footer-area section-gap">
    <div className="container">
      <div className="row">
        <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
         
          
        </div>
        <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
        
        </div>
        <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
        
        </div>
        <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
        
        </div>
        <div className="col-xl-4 col-md-8 mb-4 mb-xl-0 single-footer-widget">
          
          
        </div>
      </div>
    </div>
  </footer>
  </div>

    );
  }
}  
    
  
 
export default Contact;

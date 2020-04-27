import React, { Component } from 'react';
import '../instruments/css/style.scss';


class Contact extends Component {
  state={}
  render(){
    return(
      <React.Fragment >

    <header className="header_area">
    <div className="header-top">
      <div className="container">
        <div className="d-flex align-items-center">
          <div id="logo">
            <a href="index.html"><img src="img/Logo.png" alt="" title=""/></a>
          </div>
          <div className="ml-auto d-none d-md-block d-md-flex" >
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
    </div>
    </header>  

    <div className="main_menu">
      <nav className="navbar navbar-expand-lg navbar-light">
        <div className="container">
          <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"> 
            <span className="icon-bar"></span>
            <span className="icon-bar"></span>
            <span className="icon-bar"></span>
          </button>
        
          <div className="collapse navbar-collapse offset" id="navbarSupportedContent">
            <ul className="nav navbar-nav menu_nav">
              <li className="nav-item"><a className="nav-link" href="index.html">Home</a></li>
              <li className="nav-item"><a className="nav-link" href="about.html">About</a></li>
              <li className="nav-item"><a className="nav-link" href="properties.html">Properties</a></li>
              <li className="nav-item"><a className="nav-link" href="gallery.html">Gallery</a></li>
              <li className="nav-item submenu dropdown">
                <a href="#" className="nav-link dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true"
                aria-expanded="false">Blog</a>
                <ul className="dropdown-menu">
                  <li className="nav-item"><a className="nav-link" href="blog.html">Blog</a></li>
                  <li className="nav-item"><a className="nav-link" href="blog-single.html">Blog Details</a></li>
                </ul>
              </li>
              <li className="nav-item active"><a className="nav-link" href="contact.html">Contact</a></li>
            </ul>
          </div>
  
          <ul className="social-icons ml-auto">
            <li><a href="#"><i className="fab fa-facebook-f"></i></a></li>
            <li><a href="#"><i className="fab fa-linkedin-in"></i></a></li>
            <li><a href="#"><i className="fab fa-twitter"></i></a></li>
            <li><a href="#"><i className="fab fa-google-plus-g"></i></a></li>
            <li><a href="#"><i className="fas fa-rss"></i></a></li>
          </ul>
        </div>
      </nav>
    </div>
  
  <section className="contact-banner-area" id="contact">
    <div className="container h-100">
      <div className="contact-banner">
        <div className="text-center">
          <h1>Contact Us</h1>
          <nav aria-label="breadcrumb" className="banner-breadcrumb">
            <ol className="breadcrumb">
              <li className="breadcrumb-item"><a href="#">Home</a></li>
              <li className="breadcrumb-item active" aria-current="page">Contact Us</li>
            </ol>
          </nav>
        </div>
      </div>
    </div>
  </section>
   
  
  
      <div className="row" />
        <div className="col-md-4 col-lg-3 mb-4 mb-md-0">
          <div className="media contact-info">
            <span className="contact-info__icon"><i className="ti-home"></i></span>
            <div className="media-body">
              <h3>California United States</h3>
              <p>Santa monica bullevard</p>
            </div>
          </div>
          <div className="media contact-info">
            <span className="contact-info__icon"><i className="ti-headphone"></i></span>
            <div className="media-body">
              <h3><a href="tel:454545654">00 (440) 9865 562</a></h3>
              <p>Mon to Fri 9am to 6pm</p>
            </div>
          </div>
          <div className="media contact-info">
            <span className="contact-info__icon"><i className="ti-email"></i></span>
            <div className="media-body">
              <h3><a href="mailto:support@colorlib.com">support@colorlib.com</a></h3>
              <p>Send us your query anytime!</p>
            </div>
          </div>
        </div>
        <div className="col-md-8 col-lg-9"/>
          <form className="row contact_form" id="contactForm">
              <div className="col-md-6" />
                  <div className="form-group" />
                      <input type="text" className="form-control" id="name" name="name" placeholder="Enter your name"/> 
                  
                  <div className="form-group" />
                      <input type="email" className="form-control" id="email" name="email" placeholder="Enter email address"/>
                 
                  <div className="form-group" />
                      <input type="text" className="form-control" id="subject" name="subject" placeholder="Enter Subject"/> 
                 
              
              <div className="col-md-6">
                  <div className="form-group">
                      <textarea className="form-control different-control" name="message" id="message" rows="5" placeholder="Enter Message"></textarea>
                  </div>
              </div>
              <div className="col-md-12 text-right">
                  <button type="submit" value="submit" className="button-contact"><span>Send Message</span></button>
              </div>
          </form>
    
    
  
  
  <footer className="footer-area section-gap">
    <div className="container">
      <div className="row">
        <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
          <h4>Top Products</h4>
          <ul>
            <li><a href="/#/">Managed Website</a></li>
            <li><a href="/#/">Manage Reputation</a></li>
            <li><a href="/#/">Power Tools</a></li>
            <li><a href="/#/">Marketing Service</a></li>
          </ul>
        </div>
        <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
          <h4>Quick Links</h4>
          <ul>
            <li><a href="/#/">Jobs</a></li>
            <li><a href="/#/">Brand Assets</a></li>
            <li><a href="/#/">Investor Relations</a></li>
            <li><a href="/#/">Terms of Service</a></li>
          </ul>
        </div>
        <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
          <h4>Features</h4>
          <ul>
            <li><a href="/#/">Jobs</a></li>
            <li><a href="/#/">Brand Assets</a></li>
            <li><a href="/#/">Investor Relations</a></li>
            <li><a href="/#/">Terms of Service</a></li>
          </ul>
        </div>
        <div className="col-xl-2 col-sm-6 mb-4 mb-xl-0 single-footer-widget">
          <h4>Resources</h4>
          <ul>
            <li><a href="/#/">Guides</a></li>
            <li><a href="/#/">Research</a></li>
            <li><a href="/#/">Experts</a></li>
            <li><a href="/#/">Agencies</a></li>
          </ul>
        </div>
        <div className="col-xl-4 col-md-8 mb-4 mb-xl-0 single-footer-widget">
          <h4>Newsletter</h4>
          <p>You can trust us. we only send promo offers,</p>
          <div className="form-wrap" id="mc_embed_signup">
            <form target="_blank" 
             method="get" className="form-inline">
              <input className="form-control" name="EMAIL" placeholder="Your Email Address"
                type="email" /> 
              <button className="click-btn btn btn-default text-uppercase">subscribe</button>
              <div style={{position : 'absolute'}}>
                <input name="b_36c4fd991d266f23781ded980_aefe40901a" type="text" /> 
               
              </div>
  
              <div className="info"></div>
            </form>
          </div>
        </div>
      </div>
      <div className="footer-bottom row align-items-center text-center text-lg-left">
  
  
        <div className="col-lg-4 col-md-12 text-center text-lg-right footer-social">
          <a href="/#/"><i className="fab fa-facebook-f"></i></a>
          <a href="/#/"><i className="fab fa-twitter"></i></a>
          <a href="/#/"><i className="fab fa-dribbble"></i></a>
          <a href="/#/"><i className="fab fa-behance"></i></a>
        </div>
      </div>
    </div>
  </footer>
  </React.Fragment>

    );
  }
}  
    
  
 
export default Contact;

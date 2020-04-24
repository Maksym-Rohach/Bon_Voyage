import React, { Component } from 'react';
import './loader.css';
class Loader extends Component {
    state = {}
    render() {
        return (
            // <div className="eclipse" >
            //    <div className="spiner">
            //    <div className="spinner-grow spinner-grow-lg  text-info" role="status">
            //     <span className="sr-only">Loading...</span>
            //    </div>
              
            // </div>
           
            // </div>
            <div className="eclipse">
                <div className="spiner">
            <div class="cssload-loader">
	<div class="cssload-inner cssload-one"></div>
	<div class="cssload-inner cssload-two"></div>
	<div class="cssload-inner cssload-three"></div>
</div>
</div>
</div>
        );
    }
}

export default Loader;
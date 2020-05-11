import React, { Component } from "react";
import * as reducer from "./reducer";
import { connect } from "react-redux";


class generateHotelPhotosSeeder extends Component {
  state = {};

  onUpload = (e) => {
    let length = Object.keys(e.target.files).length;
    let photosBase64 = [];

    for (let i = 0; i < length; i++) {
      let file = e.target.files[i];
      this.getBase64(file,photosBase64);
    }

    setTimeout(() => {

      let model = {
        photosBase64:photosBase64
      }
      console.log(model);
  
      this.props.sendPhotos(model);
    },1000);

  };

  getBase64 = (file,arr) => {
    return new Promise(function(resolve, reject) {
        var reader = new FileReader();
        reader.onload = () => 
        {
          resolve(arr.push(reader.result)) 
        };
        reader.readAsDataURL(file);
    });
}


  render() {
    return (
      <React.Fragment>       
        <input
          id="input-b3"
          name="input-b3[]"
          type="file"
          class="file"
          multiple
          data-show-upload="false"
          data-show-caption="true"
          data-msg-placeholder="Select {files} for upload..."
          onChange={(e) => this.onUpload(e)}
        ></input>
      </React.Fragment>
    );
  }
}

const mapDispatch = (dispatch) => {
  return {
    sendPhotos: (photos) => {
        dispatch(reducer.sendPhotos(photos));
    },
  };
};

export default connect(null,mapDispatch)(generateHotelPhotosSeeder);
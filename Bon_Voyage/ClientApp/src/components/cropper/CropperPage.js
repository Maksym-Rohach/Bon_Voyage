import React, { Component } from "react";
import classnames from "classnames";
import "cropperjs/dist/cropper.css";
import "./Modal.css";
import Cropper from "react-cropper";
import { Card, CardBody, CardFooter } from "reactstrap";

class CropperPage extends Component {
  state = {
    src: "",
    modal: false
  }; 

  onChange = e => {
    e.preventDefault();
    let files;
    if (e.dataTransfer) {
      files = e.dataTransfer.files;
    } else if (e.target) {
      files = e.target.files;
    }
    if (files && files[0]) {
      if (files[0].type.match(/^image\//)) {
        const reader = new FileReader();
        reader.onload = () => {
          this.toggle(e);
          this.setState({ src: reader.result });
        };
        reader.readAsDataURL(files[0]);
      } else {
        alert("Невірний тип файлу");
      }
    } else {
      alert("Будь ласка виберіть файл");
    }
  };

  cropImage = e => {
    e.preventDefault();
    if (typeof this.cropper.getCroppedCanvas() === "undefined") {
      return;
    }
    this.setState({
      src: "",
      modal: false
    });
    this.props.getCroppedImage(this.cropper.getCroppedCanvas().toDataURL());
  };

  optionCropImage = (e, option, value) => {
    e.preventDefault();

    if (typeof this.cropper.getCroppedCanvas() === "undefined") {
      return;
    }
    switch (option) {
      case "rotate":
        this.cropper.rotate(value);
        break;
      case "zoom":
        this.cropper.zoom(value);
        break;
      default:
        break;
    }
  };

  handleClick = e => {
    this.refs.inputFile.click();
  };

  toggle = e => {
    e.preventDefault();
    this.setState(prevState => ({
      modal: !prevState.modal
    }));
  };

  render() {
    return (
      <div className="">
        <div className={classnames({ "d-none": this.props.isHidden, '': !this.props.isHidden })}>
          <label htmlFor="files" className="btn btn-primary ">
            Виберіть фото
          </label>
          <input
            id="files"
            style={{visibility: "hidden"}}
            ref="inputFile"
            type="file"
            onChange={this.onChange}
            onClick={event => {
              event.target.value = null;
            }}
          />
        </div>
        <div className={classnames("modal", { open: this.state.modal })}>
          <div className="fluid-container">
            <div className="col-12 col-lg-8">
              <Card>
                <CardBody>
                  <div style={{ width: "100%" }}>
                    {this.props.isForAvatar === true ? (
                      <Cropper
                        style={{ height: 400, width: "100%" }}
                        aspectRatio={1 / 1}
                        preview=".img-preview"
                        guides={false}
                        viewMode={1}
                        dragMode="move"
                        src={this.state.src}
                        ref={cropper => {
                          this.cropper = cropper;
                        }}
                      />
                    ) : (
                      <Cropper
                        style={{ height: 400, width: "100%" }}
                        preview=".img-preview"
                        guides={false}
                        viewMode={0}
                        dragMode="move"
                        autoCropArea={1}
                        src={this.state.src}
                        ref={cropper => {
                          this.cropper = cropper;
                        }}
                      />
                    )}
                  </div>
                </CardBody>
                <CardFooter>
                  <div className="row">
                    <div className="col">
                      <button className="btn btn-success" onClick={this.cropImage}>
                        Обрізати фото
                      </button>
                      <button className="btn btn-danger" onClick={this.toggle}>
                        Скасувати
                      </button>
                    </div>
                    <div className="order-last">
                      <div>
                        <button className="btn btn-info" onClick={e => this.optionCropImage(e, "rotate", -90)}>
                          <i className="fa fa-rotate-left" />
                        </button>
                        <button className="btn btn-info" onClick={e => this.optionCropImage(e, "rotate", 90)}>
                          <i className="fa fa-rotate-right" />
                        </button>

                        <button className="btn btn-info" onClick={e => this.optionCropImage(e, "zoom", 0.1)}>
                          <i className="fa fa-search-plus" />
                        </button>
                        <button className="btn btn-info" onClick={e => this.optionCropImage(e, "zoom", -0.1)}>
                          <i className="fa fa-search-minus" />
                        </button>
                      </div>
                    </div>
                  </div>
                </CardFooter>
              </Card>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default CropperPage;

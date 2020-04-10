import React, { Component } from "react";
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import CropperPage from '../cropper/CropperPage';
import {serverUrl} from '../../config';
import {
    Button,
    Card,
    CardBody,
    CardGroup,
    Col,
    Form,
    Row,
  } from "reactstrap";
class ChangeImage extends Component {
  state = {
    image: '',
    croppedImage: ''  ,
    isLoading: false 
  };

  componentWillMount = () =>{
    this.props.getImage();
  }

  triggerChildInput = () => {
    this.refs.cropperPage.handleClick();
  };

  getCroppedImage = img => {
    this.setState(
      {
        isLoading: true,
        croppedImage: img
      },
      this.changeImage
    );
  };

  changeImage = () => {
    this.props.changeImage({photo: this.state.croppedImage});
   };

  render() {
      const { image }=this.props;
    return (
      <Card className="p-2">
        <CardBody>
          <Form onSubmit={this.onSubmitForm}>
            <Col className="xs-4">
              <CardGroup className="mb-3">
                <Card>
                  <CardBody>
                      <img
                  src={`${serverUrl}${image}?t=${new Date().getTime()}`}
                 /> 
                 </CardBody>
                </Card>
              </CardGroup>
            </Col>
            <Row>
              <Col xs="6">
                <Button color="primary" className="px-4" 
                onClick={this.triggerChildInput}>
                  Change Picture
                </Button>
              </Col>
            </Row>
          </Form>
        </CardBody>
        <CropperPage ref="cropperPage" getCroppedImage={this.getCroppedImage} isHidden={true} isForAvatar={true} />
      </Card>
    );
  }
}

const mapStateToProps = state => {
    return {
      errors: get(state, 'changeImage.list.errors'),
      image: get(state, 'changeImage.list.image')
    };
  }

  const mapDispatchToProps = (dispatch) => {
    return {
        changeImage: filter => {
          dispatch(getListActions.changeImage(filter));
        },
          getImage: () => {
            dispatch(getListActions.getImage());
      }
    }
  }
  export default connect(mapStateToProps,mapDispatchToProps)(ChangeImage);


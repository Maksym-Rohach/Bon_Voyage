import React from "react";
import classNames from "classnames";
import { Bar } from "react-chartjs-2";
import * as getListActions from "./reducer";
import { connect } from "react-redux";
import get from "lodash.get";
import ChangeImage from "../../../components/ChangeImage/ChangeImage.jsx";
import ChangePassword from "../../../components/ChangePassword/ChangePassword.jsx";
import ChangeInfo from "../../../components/ChangeInfo";

import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardGroup,
  Col,
  Container,
  Form,
  Input,
  InputGroup,
  InputGroupAddon,
  InputGroupText,
  Row,
} from "reactstrap";

class ClientProfileView extends React.Component {
  state = {};

  // componentDidMount = () => {
  //   this.props.getClientProfileViewData();
  // };
  //style={{backgroundColor:'rgba(52, 52, 52, 0.8)'}}
  render() {
    const { clientProfile } = this.props;
    console.log("render", clientProfile);
    const form = (
      <div className="app flex-row">
        <Container>
          <Row className="justify-content-center mt-5">
            <Card>
            <Row className="justify-content-center mt-5">
            <Col>
              <CardGroup>
                <ChangeImage />
              </CardGroup>
            </Col>
            <Col>
              <CardGroup>
                <ChangePassword />
              </CardGroup>
            </Col>
            <Col>
              <CardGroup>
                <ChangeInfo />
              </CardGroup>
            </Col>
            </Row>
            </Card>
          </Row>
        </Container>
      </div>
    );
    return form;
  }
}

const mapStateToProps = (state) => {
  return {
    listClients: get(state, "clientprofile.list.data"),
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    getClientProfileViewData: (filter) => {
      dispatch(getListActions.getClientProfileViewData(filter));
    },
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(ClientProfileView);

import React from "react";
import classNames from "classnames";
import { Bar } from "react-chartjs-2";
import * as getListActions from "./reducer";
import { connect } from "react-redux";
import get from "lodash.get";
import ChangeImage from "../../../components/ChangeImage/ChangeImage.jsx";
import ChangePassword from "../../../components/ChangePassword/ChangePassword.jsx";

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

class ManagerProfileView extends React.Component {
  state = {};

  componentDidMount = () => {
    this.props.getManagerProfileViewData();
  };

  render() {
    const { managerProfile } = this.props;
    console.log("render", managerProfile);
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
            </Row>
            <Col className="col-6">
              <CardGroup>
                <Card className="p-2">
                  <CardBody>
                    <Form onSubmit={this.onSubmitForm}>
                      <Col className="xs-3">
                        <InputGroup className="mb-3">
                          <Input
                            type="name"
                            placeholder="Name"
                            id="name"
                            autocomplete="new-password"
                            name="name"
                            value={this.state.name}
                            onChange={this.handleChange}
                          />
                          {}
                        </InputGroup>
                        <InputGroup className="mb-3">
                          <Input
                            type="surname"
                            placeholder="Surname"
                            id="surname"
                            autocomplete="new-password"
                            name="surname"
                            value={this.state.surname}
                            onChange={this.handleChange}
                          />
                          {}
                        </InputGroup>
                        <InputGroup className="mb-3">
                          <Input
                            type="email"
                            placeholder="Email"
                            id="email"
                            autocomplete="new-password"
                            name="email"
                            value={this.state.email}
                            onChange={this.handleChange}
                          />
                          {}
                        </InputGroup>
                        <InputGroup className="mb-3">
                          <Input
                            type="phonenumber"
                            placeholder="Phone Number"
                            id="phonenumber"
                            autocomplete="new-password"
                            name="phonenumber"
                            value={this.state.phonenumber}
                            onChange={this.handleChange}
                          />
                          {}
                        </InputGroup>
                        <InputGroup className="mb-3">
                          <Input
                            disabled
                            type="registerdate"
                            placeholder="Register Date"
                            id="registerdate"
                            autocomplete="new-password"
                            name="registerdate"
                            value={this.state.registerdate}
                            onChange={this.handleChange}
                          />
                          {}
                        </InputGroup>
                        <InputGroup className="mb-3">
                          <span class="input-group-text" id="basic-addon1">
                            $
                          </span>
                          <Input
                            disabled
                            type="salary"
                            placeholder="Salary"
                            id="salary"
                            autocomplete="new-password"
                            name="salary"
                            value={this.state.salary}
                            onChange={this.handleChange}
                          />
                          {}
                        </InputGroup>
                      </Col>
                      <Row>
                        <Col xs="6">
                          <Button color="primary" className="px-4">
                            Change Profile Data
                          </Button>
                        </Col>
                      </Row>
                    </Form>
                  </CardBody>
                </Card>
              </CardGroup>
            </Col>
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
    listManagers: get(state, "managerprofile.list.data"),
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    getManagerProfileViewData: (filter) => {
      dispatch(getListActions.getManagerProfileViewData(filter));
    },
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(ManagerProfileView);

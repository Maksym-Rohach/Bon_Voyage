import React from "react";
import classNames from "classnames";
import { Bar } from "react-chartjs-2";
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";

import {
  Button,
  ButtonGroup,
  Card,
  CardHeader,
  CardBody,
  CardTitle,
  Row,
  Col,
} from "reactstrap";

let chart3_2_options = {
  maintainAspectRatio: false,
  legend: {
    display: false
  },
  tooltips: {
    backgroundColor: "#f5f5f5",
    titleFontColor: "#333",
    bodyFontColor: "#666",
    bodySpacing: 4,
    xPadding: 12,
    mode: "nearest",
    intersect: 0,
    position: "nearest"
  },
  responsive: true,
  scales: {
    yAxes: [
      {
        gridLines: {
          drawBorder: false,
          color: "rgba(225,78,202,0.1)",
          zeroLineColor: "transparent"
        },
        ticks: {
          suggestedMin: 60,
          suggestedMax: 120,
          padding: 20,
          fontColor: "#9e9e9e"
        }
      }
    ],
    xAxes: [
      {
        gridLines: {
          drawBorder: false,
          color: "rgba(225,78,202,0.1)",
          zeroLineColor: "transparent"
        },
        ticks: {
          padding: 20,
          fontColor: "#9e9e9e"
        }
      }
    ]
  }
}

let chart3_1_options = {
  maintainAspectRatio: false,
  legend: {
    display: false
  },
  tooltips: {
    backgroundColor: "#f5f5f5",
    titleFontColor: "#333",
    bodyFontColor: "#666",
    bodySpacing: 4,
    xPadding: 12,
    mode: "nearest",
    intersect: 0,
    position: "nearest"
  },
  responsive: true,
  scales: {
    yAxes: [
      {
        gridLines: {
          drawBorder: false,
          color: "rgba(225,78,202,0.1)",
          zeroLineColor: "transparent"
        },
        ticks: {
          suggestedMin: 60,
          suggestedMax: 120,
          padding: 20,
          fontColor: "#9e9e9e"
        }
      }
    ],
    xAxes: [
      {
        gridLines: {
          drawBorder: false,
          color: "rgba(225,78,202,0.1)",
          zeroLineColor: "transparent"
        },
        ticks: {
          padding: 20,
          fontColor: "#9e9e9e"
        }
      }
    ]
  }
}

class PersonsChart extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      bigChartData: "data1",
      ageState: [],
      gendersState: [],
      size: 0
    };
  }

  static getDerivedStateFromProps(nextProps, prevState){
    return {
      ageState: nextProps.age,
      gendersState: nextProps.gender,
      size: nextProps.size
    };
  }
  setBgChartData = name => {
    this.setState({
      bigChartData: name
    });
  };

  generateData = () =>{
    this.props.getPersonsData();
  }
  render() {
    const { ageState, gendersState, size } = this.state;

const gender = ["MAN", "WOMEN"];
const age = ["<18", "18-25", "25-40", "40-50", "50-65", "65+"];
let chartExample2 = {
  data: canvas => {
    let ctx = canvas.getContext("2d");

    let gradientStroke = ctx.createLinearGradient(0, 230, 0, 50);

    gradientStroke.addColorStop(1, "rgba(72,72,176,0.1)");
    gradientStroke.addColorStop(0.4, "rgba(72,72,176,0.0)");
    gradientStroke.addColorStop(0, "rgba(119,52,169,0)"); //purple colors

    return {
      labels: gender,
      datasets: [
        {
          label: "Quantity",
          fill: true,
          backgroundColor: gradientStroke,
          hoverBackgroundColor: gradientStroke,
          borderColor: "#d048b6",
          borderWidth: 2,
          borderDash: [],
          borderDashOffset: 0.0,
          data: gendersState,
        }
      ]
    };
  },
  options: chart3_2_options
};

    let chartExample3 = {
      data: canvas => {
        let ctx = canvas.getContext("2d");
    
        let gradientStroke = ctx.createLinearGradient(0, 230, 0, 50);
    
        gradientStroke.addColorStop(1, "rgba(72,72,176,0.1)");
        gradientStroke.addColorStop(0.4, "rgba(72,72,176,0.0)");
        gradientStroke.addColorStop(0, "rgba(119,52,169,0)"); //purple colors
    
        return {
          labels: age,
          datasets: [
            {
              label: "Quantity",
              fill: true,
              backgroundColor: gradientStroke,
              hoverBackgroundColor: gradientStroke,
              borderColor: "#34a65f",
              borderWidth: 2,
              borderDash: [],
              borderDashOffset: 0.0,
              data: ageState
            }
          ]
        };
      },
      options: chart3_1_options
    };

    return (
      <React.Fragment>
      <div className="content">
        <Row>
          <Col xs="12" lg="4">
            <Card className="card-chart">
              <CardHeader>
                <Row>
                  <Col className="text-left" sm="6">
                    <CardTitle tag="h2" className="text-primary">Genders</CardTitle>
                    <CardTitle tag="h3">
                    <i className="tim-icons icon-bell-55 text-primary" />{" "}
                    {size}
                  </CardTitle>
                  </Col>  
                  <Col sm="6">
                    <ButtonGroup
                      className="btn-group-toggle float-right"
                      data-toggle="buttons"
                    >
                      <Button
                        tag="label"
                        className={classNames("btn-simple", {
                          active: this.state.bigChartData === "data1"
                        })}
                        color="primary"
                        id="0"
                        size="sm"
                        onClick={() => this.setBgChartData("data1")}
                      >
                        <input
                          defaultChecked
                          className="d-none"
                          name="options"
                          type="radio"
                        />
                        <span
                        onClick={this.generateData}>
                        Generate data
                        </span>
                        <span className="d-block d-sm-none">
                          <i className="tim-icons icon-single-02" />
                        </span>
                      </Button>
                      </ButtonGroup>
                      </Col>               
                </Row>
              </CardHeader>
                <CardBody>
                  <div className="chart-area">
                    <Bar
                      data={chartExample2.data}
                      options={chartExample2.options}
                    />
                  </div>
                </CardBody>
                </Card>
            </Col>
            <Col xs="12" lg="8">
            <Card className="card-chart">
              <CardHeader>
                <Row>
                <Col className="text-left" sm="6">
                    <CardTitle tag="h2" className="text-success">AGE</CardTitle>
                    <CardTitle tag="h3">
                    <i className="tim-icons icon-bell-55 text-success" />{" "}
                    {size}
                  </CardTitle>
                  </Col>                                    
                </Row>
              </CardHeader>
                <CardBody>
                  <div className="chart-area">
                    <Bar
                      data={chartExample3.data}
                      options={chartExample3.options}
                    />
                  </div>
                </CardBody>
                </Card>
            </Col>
          </Row>
          </div>
        </React.Fragment>
    );
  }
}

const mapStateToProps = state => {
  return {
    age: get(state, "persons.list.data.date"),
    gender: get(state, "persons.list.data.gender"),
    size: get(state, "persons.list.data.size"),
    isListLoading: get(state, "persons.list.loading"),  
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    getPersonsData: filter => {
      dispatch(getListActions.getPersonsData(filter));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(PersonsChart);

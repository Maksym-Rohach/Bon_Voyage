import React from "react";
import classNames from "classnames";
import { Line } from "react-chartjs-2";
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";

import {
  Card,
  CardHeader,
  CardBody,
  CardTitle,
  Row,
  Col,
  ButtonGroup,
  Button
} from "reactstrap";

let chart1_2_options = {
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
        barPercentage: 1.6,
        gridLines: {
          drawBorder: false,
          color: "rgba(29,140,248,0.0)",
          zeroLineColor: "transparent"
        },
        ticks: {
          suggestedMin: 60,
          suggestedMax: 125,
          padding: 20,
          fontColor: "#9a9a9a"
        }
      }
    ],
    xAxes: [
      {
        barPercentage: 1.6,
        gridLines: {
          drawBorder: false,
          color: "rgba(29,140,248,0.1)",
          zeroLineColor: "transparent"
        },
        ticks: {
          padding: 20,
          fontColor: "#9a9a9a"
        }
      }
    ]
  }
};

class CommentsChart extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      bigChartData: "data1",
      isLoading: true, 
      datesState: [],
      commentsState: [],
      size: 0
    };
  }

  setBgChartData = name => {
    this.setState({
      bigChartData: name
    });
  };
  
  generateData =()=> {
      this.props.getCommentsData();
  }

  static getDerivedStateFromProps(nextProps, prevState){
    if(nextProps !== prevState){
      return {     
        datesState: nextProps.date,
        commentsState: nextProps.comments,
        size: nextProps.size
      };
    }
    
  }

  render() {
    const { datesState, commentsState, size } = this.state;
    
    let chartExample1 = {
      data1: canvas => {
        let ctx = canvas.getContext("2d");
    
        let gradientStroke = ctx.createLinearGradient(0, 230, 0, 50);
    
        gradientStroke.addColorStop(1, "rgba(29,140,248,0.2)");
        gradientStroke.addColorStop(0.4, "rgba(29,140,248,0.0)");
        gradientStroke.addColorStop(0, "rgba(29,140,248,0)"); //blue colors
    
        return {        
          labels: datesState,
          datasets: [
            {
              label: "Comments",
              fill: true,
              backgroundColor: gradientStroke,
              borderColor: "#1f8ef1",
              borderWidth: 2,
              borderDash: [],
              borderDashOffset: 0.0,
              pointBackgroundColor: "#1f8ef1",
              pointBorderColor: "rgba(255,255,255,0)",
              pointHoverBackgroundColor: "#1f8ef1",
              pointBorderWidth: 20,
              pointHoverRadius: 4,
              pointHoverBorderWidth: 15,
              pointRadius: 4,
              data: commentsState
            }
          ]
        };
      },
      options: chart1_2_options
    }
  
    return (
      <React.Fragment>
        <div className="content">
          <Row>
            <Col xs="12">
              <Card className="card-chart">
                <CardHeader>
                  <Row>
                  <Col className="text-left" sm="6">
                    <CardTitle tag="h2" className="text-info">Comments</CardTitle>
                    <CardTitle tag="h3">
                    <i className="tim-icons icon-bell-55 text-info" />{" "}
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
                          color="info"
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
                    <Line
                      data={chartExample1[this.state.bigChartData]}
                      options={chartExample1.options}
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
    comments: get(state, "comments.list.data.comment"),
    date: get(state, "comments.list.data.date"),
    size: get(state, "comments.list.data.size"),
    isListLoading: get(state, "comments.list.loading"),  
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    getCommentsData: filter => {
      dispatch(getListActions.getCommentsData(filter));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(CommentsChart);
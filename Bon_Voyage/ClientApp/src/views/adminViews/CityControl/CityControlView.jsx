import React, { Component } from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Button } from "primereact/button";
import * as reducer from "./reducer";
import { Link } from 'react-router-dom';
import get from "lodash.get";
import { connect } from "react-redux";

class CityControl extends Component {
    state = { cities: {} };

    //3
  // Call reducer
  componentWillMount = () => {
    this.props.getCityData();  
  }
  componentWillReceiveProps = (nextProps) => { //- Binding    
    console.log(nextProps);
    this.setState({
        cities:nextProps.cityReducer
    });
  }
    render() {
        let header = (
            <div className="p-clearfix" style={{ lineHeight: "1.87em" }}>
                Список міст{" "}
                <Button icon="pi pi-refresh" style={{ float: "right" }} />
            </div>
        );

        const page = (
            <React.Fragment>
                <div className="mt-3">
                    <div className="content-section introduction">
                        <div className="feature-intro">
                            <h1> </h1>
                            <p> </p>
                        </div>
                    </div>

                    <div className="content-section implementation">
                        <DataTable value={this.state.cities} header={header}>
                            <Column
                                field="name"
                                header="Місто"
                                style={{ textAlign: "center" }}
                            />

                        </DataTable>
                    </div>
                </div>
            </React.Fragment>
        );
        return page;
    }
    
}

// GetReducerData
function mapStateToProps(state) {
    console.log('mapStateToProps', state)
    return {
        cityReducer: get(state, 'cityControl.list.data'),
    };
}
const mapDispatch = (dispatch) => {
    return {
        getCityData: () => {
            dispatch(reducer.getCityData());
        },
    }
}


export default connect(mapStateToProps, mapDispatch)(CityControl);
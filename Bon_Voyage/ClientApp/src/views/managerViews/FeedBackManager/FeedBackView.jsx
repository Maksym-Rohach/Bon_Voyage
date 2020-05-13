import React, { Component } from 'react';
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Card } from 'primereact/card';
class FeedBackManager extends Component {
    state = { 
     }

    componentDidMount = () => {
        this.props.getmessage();
    }

    render() { 
        const { listFeedBack } = this.props;
        console.log("render", listFeedBack);
        return ( 
            <React.Fragment>
                
            </React.Fragment>
          );
    }
}
const mapStateToProps = state => {
    console.log("mapStateToProps",state)
    return {
        listFeedBack: get(state, 'feedback.list.data'),
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        getmessage:() => {
            dispatch(getListActions.getmessage());
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(FeedBackManager);
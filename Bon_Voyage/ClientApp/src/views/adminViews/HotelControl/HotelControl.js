import React, { Component } from 'react';
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import {DataTable} from 'primereact/datatable';
import {Column} from 'primereact/column';
import {Button} from 'primereact/button';
import {Dialog} from 'primereact/dialog';

class HotelControl extends Component {
    state = { 
     }

    componentDidMount = () => {
      this.props.getHotelControlData();
    }

    actionTemplate(rowData, column) {
        return <div>
            <Button type="button" icon="pi pi-cog" className="p-button-secondary p-button-rounded" onClick={(e) => this.setState({visible: true})}></Button>

        <Dialog header="" visible={this.state.visible} style={{width: '50vw'}} modal={true} onHide={() => this.setState({visible: false})}>
        </Dialog>
        </div>;
    }

    dialogTemplate(rowData, column){
        return <Dialog header="" visible={this.state.visible} style={{width: '50vw'}} modal={true} onHide={() => this.setState({visible: false})}>
        </Dialog>;
    }

    render() { 

        const { listHotels }= this.props;
        console.log("render",listHotels);

        var header = <div className="p-clearfix" style={{'lineHeight':'1.87em'}}>Список готелів<Button icon="pi pi-refresh" style={{'float':'right'}}/></div>;

        return ( 
            <DataTable value={listHotels} header={header}>
            <Column field="name" header="Назва" />
            <Column field="stars" header="Кількість *" />
            <Column field="city.name" header="Місто" />
            <Column field="isClosed" header="Працює" />
            <Column header="Змінити" body={this.actionTemplate} style={{textAlign:'center', width: '6em'}}/>
        </DataTable>
         );
    }
}

const mapStateToProps = state => {
    return {
        listHotels: get(state, 'hotels.list.data'), 
    };
  }

  const mapDispatchToProps = (dispatch) => {
    return {
        getHotelControlData: filter => {
        dispatch(getListActions.getHotelControlData(filter));
      }
    }
  }
 
export default connect(mapStateToProps, mapDispatchToProps) (HotelControl);
import React, { Component } from 'react';
import * as getListActions from './reducer';
import * as postListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Card } from 'primereact/card';
import {InputTextarea} from 'primereact/inputtextarea';
import {Dialog} from 'primereact/dialog';

import {Button} from 'primereact/button';
class FeedBackManager extends Component {
    state = {
        id:"",
        value:"",
        email:"",


        showModal:false,
    }

    componentDidMount = () => {
        this.props.getmessage();
    }



    sendAnswer = () => {
       let model = {
            id:this.state.id,
            userEmail:this.state.email,
            message:this.state.value,
        }
        
        console.log(model);
        this.props.answermessage(model);
        window.location.reload();
        this.setState({value:""});

    }




    renderFooter(name) {
        return (
            <div>
                <Button label="Відповісти" icon="pi pi-check" onClick={() => this.sendAnswer()} />
                <Button label="Відмінити" icon="pi pi-times" onClick={() =>this.setState({showModal:false,value:""})} className="p-button-secondary"/>
            </div>
        );
    }

    actionTemplate = (rowData) => {
        console.log(rowData);
        return <div>
            <Button type="button" label="Відповісти" onClick={e => this.setState({showModal:true,email:rowData.userEmail,id:rowData.id})} icon="pi pi-check" style={{marginRight: '.5em'}}></Button>          
        </div>;
    }
    answerTemplate = (rowData,column) => {
        return <div>
            <InputTextarea rows={5} cols={30} value={this.state.value} onChange={e=>this.setState({value:e.target.value})}/>
        </div>
    }
    render() {
        const { listFeedBack } = this.props;
        console.log("render", listFeedBack);
        return (
            <React.Fragment>
                <Card className="mt-5">
                    <DataTable value={listFeedBack} paginator={true} ref={(el) => this.dt = el} rows={10} first={this.state.first} onPage={(e) => this.setState({ first: e.first })}>
                        <Column field="userEmail" filterPlaceholder="Search" style={{ textAlign: 'center' }} header="Email покупця" />
                        <Column field="theme" style={{ textAlign: 'center' }} header="Тема"/>
                        <Column field="date" style={{ textAlign: 'center' }} header="Дата звернення" />
                        <Column field="description" style={{ textAlign: 'center' }} header="Опис проблеми" />
                        {/* <Column field="" body={x =>this.answerTemplate()} style={{ textAlign: 'center' }} header="Відповідь" /> */}
                        <Column field="" body={x =>this.actionTemplate(x)} style={{ textAlign: 'center' }} header="Відправити"/>
                    </DataTable>
                </Card>



                <Dialog header="Відповідь" visible={this.state.showModal} style={{ width: '50vw' }} onHide={() => this.setState({ showModal: false })} footer={this.renderFooter('displayBasic')}>
                    <div>
                        <InputTextarea rows={5} cols={128} value={this.state.value} onChange={e => this.setState({ value: e.target.value })} />
                    </div>
                </Dialog>
            </React.Fragment>
        );
    }
}
const mapStateToProps = state => {
    console.log("mapStateToProps", state)
    return {
        listFeedBack: get(state, 'feedback.list.messages'),
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        getmessage: () => {
            dispatch(getListActions.getmessage());
        },
        answermessage:(model)=>{
            dispatch(postListActions.answerMessage(model))
        }
    }
}


export default connect(mapStateToProps, mapDispatchToProps)(FeedBackManager);
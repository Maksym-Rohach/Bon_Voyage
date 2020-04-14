import React, { Component } from 'react';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import { InputText } from 'primereact/inputtext';
import * as reducer from './reducer';
import { connect } from 'react-redux'; 
import get from "lodash.get";
import { Input } from 'reactstrap';


class ChangeInfo extends Component {
    state = {
        Name: "",
        SurName: "",
        Email: "",
        PhoneNumber: "",
        error: ""
    }

    onSubmitForm = (e) => {
        e.preventDefault();
        const { Name, SurName, Email, PhoneNumber } = this.state;

        const model = {
            NewName: Name,
            NewSurName: SurName,
            NewEmail: Email,
            NewPhoneNumber: PhoneNumber
        };
        this.props.changeInfo(model);
    }

    handleChange = e => {
        this.setState({ [e.target.name]: e.target.value });
      };

    // 3
    // Метод викликається до рендера
    // Потрібен, щоб викликати метод редюсера, щоб з самого початку були дані
    componentWillMount = () => {
        this.props.getInfo();
    }

    // 4
    // Тут ми біндимо дані з реюсера
    // Цей метод редюсер викликає, коли хтось в ньому щось змінює (допустім дістає юзерів)
    componentWillReceiveProps = (nextProps) => { //- Binding 
        console.log("Binding", nextProps)
        this.setState({
            Name: nextProps.getInfoReducer.name,
            SurName: nextProps.getInfoReducer.surName,
            Email: nextProps.getInfoReducer.email,
            Phone: nextProps.getInfoReducer.phoneNumber
        });
    }

    render() {

        const { Name,SurName,Email,Phone } = this.state;

        return (
            <form onSubmit={this.onSubmitForm}>
                <label className="p-float-label m-3 d-flex justify-content-center">Зміна данних</label>
                <span className="p-float-label m-3">
                    <InputText id="float-input" name="Name" type="text" size="30" value={this.state.value} onChange={this.handleChange} />
                    <label htmlFor="float-input">{Name}</label>
                </span>
                <span className="p-float-label m-3">
                    <InputText id="float-input" name="SurName" type="text" size="30" value={this.state.value} onChange={this.handleChange}/>
                    <label htmlFor="float-input">{SurName}</label>
                </span>
                <span className="p-float-label m-3">
                    <InputText id="float-input" name="Email" type="email" size="30"  value={this.state.value} onChange={this.handleChange}/>
                    <label htmlFor="float-input">{Email}</label>
                </span>
                <span className="p-float-label m-3">
                    <InputText id="float-input" name="PhoneNumber" type="text" size="30" value={this.state.value} onChange={this.handleChange}/>
                    <label htmlFor="float-input">{Phone}</label>
                </span>
                <Button className="p-float-label m-3" label="Save" icon="pi pi-check" />
            </form>
        );
    }
}

// 2
// Доступаємося до полів редюсера
// state - це весь store зі всіма редюсерами
function mapStateToProps(state) {
    return {
        getInfoReducer: get(state, 'changeInfoReducer.infoList.data')
    };

}

// 1
// Отримуєм методи з редюсера 
const mapDispatch = {
    getInfo: () => {
        return reducer.getInfo();
    },
    changeInfo: (model) => {
        return reducer.changeInfo(model);
    }
}
export default connect(mapStateToProps, mapDispatch)(ChangeInfo);



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
            PhoneNumber: nextProps.getInfoReducer.phoneNumber
        });
    }

    render() {

        const { Name, SurName, Email, PhoneNumber } = this.state;
        const { errors } = this.props;
        console.log("RENDER", errors);
        return (
            <form onSubmit={this.onSubmitForm}>
                <label className="p-float-label m-3 d-flex justify-content-center">Зміна данних</label>
                <span className="p-float-label m-3">
                    <InputText id="float-input" name="Name" type="text" size="30" value={Name} onChange={this.handleChange} />
                    {Name.length <= 0 ? <label htmlFor="float-input">Ім'я</label> : <div></div>}
                </span>
                <span className="p-float-label m-3">
                    <InputText id="float-input" name="SurName" type="text" size="30" value={SurName} onChange={this.handleChange} />
                    {SurName.length <= 0 ? <label htmlFor="float-input">Прізвище</label> : <div></div>}
                </span>
                <span className="p-float-label m-3">
                    <InputText id="float-input" name="Email" type="text" size="30" value={Email} onChange={this.handleChange} />
                    {Email.length <= 0 ? <label htmlFor="float-input">Пошта</label> : <div></div>}
                </span>
                <span className="p-float-label m-3">
                    <InputText id="float-input" name="PhoneNumber" type="text" size="30" value={PhoneNumber != null ? PhoneNumber : ""} onChange={this.handleChange} />
                    {PhoneNumber != null ?
                        (PhoneNumber.length <= 0 ? <label htmlFor="float-input">Телефон</label> : <div></div>) :
                        (<label htmlFor="float-input">Телефон</label>)
                    }
                </span>
                <Button className="p-float-label m-3" label="Зберегти" icon="pi pi-check" />
            </form>
        );
    }
}

// 2
// Доступаємося до полів редюсера
// state - це весь store зі всіма редюсерами
function mapStateToProps(state) {
    return {
        errors: get(state, 'changePassword.list.errors'),
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



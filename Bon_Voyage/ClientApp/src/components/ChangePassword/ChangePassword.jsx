import React, { Component } from 'react';
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import { InputText } from 'primereact/inputtext';
import * as getListActions from './reducer';
import { connect } from 'react-redux';
import get from "lodash.get";

class ChangePassword extends Component {
    state = {
        oldPassword: "",
        newPassword: "",
        confPassword: "",
        error: ""
    }

    onSubmitForm = (e) => {
        e.preventDefault();
        const { oldPassword, newPassword, confPassword } = this.state;
        let Regex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[-=+!@#\$%\^&\*])(?=.{8,})");

        if (oldPassword === '' || newPassword === '' || confPassword === '') {
            this.setState({ error: "Поле є обов'язковим" });
        }
        else if (!Regex.test(newPassword)) {
            this.setState({ error: "New password error" });
        }
        else if (confPassword !== newPassword) {
            this.setState({ error: "Паролі не співпадають" });
        }
        else {
            this.setState({ error: "" });

            const model = {
                oldPassword: oldPassword,
                newPassword: newPassword
            };

            this.props.changePassword(model);
        }
    }

    render() {
        return (
                    <form onSubmit={this.onSubmitForm}>
                    <label className="p-float-label m-3 d-flex justify-content-center">Change Password</label>
                        <span className="p-float-label m-3">
                            <InputText id="float-input" type="text" size="30" value={this.state.oldPassword} onChange={(e) => this.setState({ oldPassword: e.target.value })} />
                            <label htmlFor="float-input">Старий пароль</label>
                        </span>
                        <span className="p-float-label  m-3">
                            <InputText id="float-input" type="text" size="30" value={this.state.newPassword} onChange={(e) => this.setState({ newPassword: e.target.value })} />
                            <label htmlFor="float-input">Новий пароль</label>
                        </span>
                        <span className="p-float-label  m-3">
                            <InputText id="float-input" type="text" size="30" value={this.state.confPassword} onChange={(e) => this.setState({ confPassword: e.target.value })} />
                            <label htmlFor="float-input">Підтвердіть пароль</label>
                        </span>
                        <Button className="p-float-label m-3" label="Save" icon="pi pi-check" />
                    </form>
        );
    }
}

const mapStateToProps = state => {
    return {
      errors: get(state, 'changePassword.list.errors'),
    };
  }

  const mapDispatchToProps = (dispatch) => {
    return {
        changePassword: filter => {
          dispatch(getListActions.changePassword(filter));
        }
      }
    }
  export default connect(mapStateToProps,mapDispatchToProps)(ChangePassword);
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
    errorsState: {},
    errorServer:""
  }

  onSubmitForm = (e) => {
    e.preventDefault();
    const { oldPassword, newPassword, confPassword } = this.state;
    let errorsState = {};
    let Regex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[-=+!@#\$%\^&\*])(?=.{8,})");

    if (oldPassword === '' || newPassword === '' || confPassword === '') {
      errorsState.oldPassword = "Поле є обов'язковим";
    }
    if (!Regex.test(newPassword)) {
      errorsState.newPassword = "Новий пароль не валідний";
    }
    if (confPassword !== newPassword) {
      errorsState.confPassword = "Паролі не співпадають";
    }
    const isValid = Object.keys(errorsState).length === 0
    if (isValid) {
        const model = {
          oldPassword: oldPassword,
          newPassword: newPassword
        };

        this.props.changePassword(model);
      }
      else{
        this.setState({errorsState});
      }
    }
    static getDerivedStateFromProps(nextProps) {
    
      return { errorsServer: nextProps.errors };
  }

  setStateByErrors = (name, value) => {
    if (!!this.state.errorsState[name]) {
      let errorsState = Object.assign({}, this.state.errorsState);
      delete errorsState[name];
      this.setState(
        {
          [name]: value,
          errorsState
        }
      )
    }
    else {
      this.setState(
        { [name]: value })
    }
  }
    render() {
      const { errorsState, errorServer } = this.state;
      return (
        <form onSubmit={this.onSubmitForm}>
          {!!errorServer ? <div>{errorServer}</div> : ""}
          <label className="p-float-label m-3 d-flex justify-content-center">Зміна паролю</label>
          <span className="p-float-label m-3">
            <InputText
              id="float-input"
              type="text"
              size="30"
              value={this.state.oldPassword}
              onChange={(e) => this.setState({ oldPassword: e.target.value })}
            />
            {!!errorsState.oldPassword ? <div>{errorsState.oldPassword}</div> : ""}
            <label htmlFor="float-input">Старий пароль</label>
          </span>
          <span className="p-float-label  m-3">
            <InputText
              id="float-input"
              type="text"
              size="30"
              value={this.state.newPassword}
              onChange={(e) => this.setState({ newPassword: e.target.value })}
            />
            {!!errorsState.newPassword ? <div>{errorsState.newPassword}</div> : ""}
            <label htmlFor="float-input">Новий пароль</label>
          </span>
          <span className="p-float-label  m-3">
            <InputText
              id="float-input"
              type="text"
              size="30"
              value={this.state.confPassword}
              onChange={(e) => this.setState({ confPassword: e.target.value })}
            />
            {!!errorsState.confPassword ? <div>{errorsState.confPassword}</div> : ""}
            <label htmlFor="float-input">Підтвердіть пароль</label>
          </span>
          <Button className="p-float-label m-3" label="Save" icon="pi pi-check" />
        </form>
      );
    }
  }

  const mapStateToProps = state => {
    console.log("STATE", state);
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
  export default connect(mapStateToProps, mapDispatchToProps)(ChangePassword);
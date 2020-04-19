import update from "../../../helpers/update";
import RegisterService from "./RegisterService";
import isEmpty from "lodash/isEmpty";
import setAuthorizationToken from "../../../utils/setAuthorizationToken";
import jwt from "jsonwebtoken";
import redirectStatusCode from "../../../services/redirectStatusCode";
import history from "../../../utils/history";
import {push} from "connected-react-router";
import * as Login from "../LoginPage/reducer";
import {serverUrl} from '../../../config';
import axios from "axios";

export const REGISTER_POST_STARTED = "REGISTER_POST_STARTED";
export const REGISTER_POST_SUCCESS = "REGISTER_POST_SUCCESS";
export const REGISTER_POST_FAILED = "REGISTER_POST_FAILED";
export const REGISTER_SET_CURRENT_USER = "REGISTER/SET_CURRENT_USER";

const initialState = {
    post: {
      loading: false,
      success: false,
      failed: false,
      errors: {}
    },
    isAuthenticated: false,
    user: {
      id: "",
      name: "",
      image: "",
      roles: {}
    }
  };
  
  export const registerReducer = (state = initialState, action) => {
    let newState = state;
  
    switch (action.type) {
      case REGISTER_POST_STARTED: {
        newState = update.set(state, "post.loading", true);
        newState = update.set(newState, "post.success", false);
        newState = update.set(newState, "post.errors", {});
        newState = update.set(newState, "post.failed", false);
        break;
      }
      case REGISTER_SET_CURRENT_USER: {
        return {
          ...state,
          isAuthenticated: !isEmpty(action.user),
          user: action.user
        };
      }
      case REGISTER_POST_SUCCESS: {
        newState = update.set(state, "post.loading", false);
        newState = update.set(newState, "post.failed", false);
        newState = update.set(newState, "post.errors", {});
        newState = update.set(newState, "post.success", true);
        break;
      }
      case REGISTER_POST_FAILED: {
        newState = update.set(state, "post.loading", false);
        newState = update.set(newState, "post.success", false);
        newState = update.set(newState, "post.errors", action.errors);
        newState = update.set(newState, "post.failed", true);
        break;
      }
      default: {
        return newState;
      }
    }
  
    return newState;
  };
  
//   export const Register = model => {
//     return dispatch => {
//       //dispatch(RegisterActions.started());
//       RegisterService.Register(model)
//         .then(
//           response => {
//             Login.loginByJWT(response.data,dispatch);
//           },
//           err => {
//             throw err;
//           }
//         )
//         .catch(err => {
//           //dispatch(RegisterActions.failed(err.response));
//           //console.log(err);
//           //redirectStatusCode(err.response.status);
//         });
//     };
//};
export function Register(data) {
    const url = 'https://localhost:44365/api/registration/register';
    console.log("Return token - ", data);
    return dispatch => {
        return axios.post(url, data)
            .then(res => {
              console.log("Register data - ",res.data);
              Login.loginByJWT(res.data, dispatch);
            })
            .catch(err => {
              console.log("ERROR",err);
            });
    }
}

  
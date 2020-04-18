import update from "../../../helpers/update";
import LoginService from "./LoginService";
import isEmpty from "lodash/isEmpty";
import setAuthorizationToken from "../../../utils/setAuthorizationToken";
import jwt from "jsonwebtoken";
import redirectStatusCode from "../../../services/redirectStatusCode";
import history from "../../../utils/history";
import {push} from "connected-react-router";

export const LOGIN_POST_STARTED = "LOGIN_POST_STARTED";
export const LOGIN_POST_SUCCESS = "LOGIN_POST_SUCCESS";
export const LOGIN_POST_FAILED = "LOGIN_POST_FAILED";
export const LOGIN_SET_CURRENT_USER = "login/SET_CURRENT_USER";



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
    roles: []
  }
};

export const loginReducer = (state = initialState, action) => {
  let newState = state;

  switch (action.type) {
    case LOGIN_POST_STARTED: {
      newState = update.set(state, "post.loading", true);
      newState = update.set(newState, "post.success", false);
      newState = update.set(newState, "post.errors", {});
      newState = update.set(newState, "post.failed", false);
      break;
    }
    case LOGIN_SET_CURRENT_USER: {
      return {
        ...state,
        isAuthenticated: !isEmpty(action.user),
        user: action.user
      };
    }
    case LOGIN_POST_SUCCESS: {
      newState = update.set(state, "post.loading", false);
      newState = update.set(newState, "post.failed", false);
      newState = update.set(newState, "post.errors", {});
      newState = update.set(newState, "post.success", true);
      break;
    }
    case LOGIN_POST_FAILED: {
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

export const login = model => {
  return dispatch => {
    dispatch(loginActions.started());
    LoginService.login(model)
      .then(
        response => {
          dispatch(loginActions.success());
          loginByJWT(response.data, dispatch);
          const pushUrl = getUrlToRedirect();       
          dispatch(push(pushUrl));
        },
        err => {
          throw err;
        }
      )
      .catch(err => {
        dispatch(loginActions.failed(err.response));
        console.log(err);
        redirectStatusCode(err.response.status);
      });
  };
};

function getUrlToRedirect() {
  var user = jwt.decode(localStorage.jwtToken);
  //let roles =[];
  let roles = user.roles;
  let path = "";
  console.log("getUrlToRedirect", user);
  if (Array.isArray(roles)) {
    for (let i = 0; i < roles.length; i++) {
      if (roles[i] == "Client") {
        path = "/client/profile";
        break;
      } else if (roles[i] === "Manager") {
        path = "/manager/profile";
        break;
      } else if (roles[i] === "Admin") {
        path = "/admin";
        break;
      } 
    }
  } else {
    if (roles == "Client") {
      path = "/client/profile";
    } else if (roles === "Manager") {
      path = "/manager/profile";
    } else if (roles === "Admin") {
      path = "/admin";
    }
  }

  return path;
}

export const loginActions = {
  started: () => {
    return {
      type: LOGIN_POST_STARTED
    };
  },

  success: () => {
    return {
      type: LOGIN_POST_SUCCESS
    };
  },

  failed: response => {
    return {
      type: LOGIN_POST_FAILED,
      errors: response
    };
  },

  setCurrentUser: user => {
    ////console.log('LOGIN_SET_CURRENT_USER: ', user);
    return {
      type: LOGIN_SET_CURRENT_USER,
      user
    };
  }
};

export function logout() {
  return dispatch => {
    logoutByJWT(dispatch);
  };
}

export const loginByJWT = (tokens, dispatch) => {
  const { token, refToken } = tokens;
  console.log('Hello app Token: ', token);
  var user = jwt.decode(token);


  console.log("token -",jwt.decode(token));
  if (!Array.isArray(user.roles)) {
    user.roles = Array.of(user.roles);
  }

  localStorage.setItem("jwtToken", token);
  setAuthorizationToken(token);
  dispatch(loginActions.setCurrentUser(user));
};

export const logoutByJWT = dispatch => {
  localStorage.removeItem("jwtToken");
  //localStorage.removeItem("refreshToken");
  setAuthorizationToken(false);
  dispatch(loginActions.setCurrentUser({}));
};

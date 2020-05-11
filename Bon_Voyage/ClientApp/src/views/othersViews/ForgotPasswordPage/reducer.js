import update from "../../../helpers/update";
import ForgotPasswordService from "./ForgotPasswordService";


export const FORGOT_POST_STARTED = "FORGOT_POST_STARTED";
export const FORGOT_POST_SUCCESS = "FORGOT_POST_SUCCESS";
export const FORGOT_POST_FAILED = "FORGOT_POST_FAILED";

const initialState = {
  post: {
    loading: false,
    success: false,
    failed: false,
    errors: {}
  }
};


export function ForgotPassword(data) {
  return (dispatch) => {
    dispatch(getListActions.started());
    ForgotPasswordService.forgotPassword(data)
      .then((response) => {
        console.log("response", response);
        dispatch(getListActions.success(response));
      }, err => { throw err; })
      .catch(err => {
        dispatch(getListActions.failed(err.response));
      });
  }
}


export const getListActions = {
  started: () => {
    return {
      type: FORGOT_POST_STARTED
    }
  },
  success: () => {
    return {
      type: FORGOT_POST_SUCCESS,
    }
  },
  failed: (error) => {
    console.log("Error : ", error)
    return {
      type: FORGOT_POST_FAILED,
      errors: error.data
    }
  }
}


export const ForgotPasswordReducer = (state = initialState, action) => {
  let newState = state;
  switch (action.type) {
    case FORGOT_POST_STARTED: {
      newState = update.set(state, "post.loading", true);
      newState = update.set(newState, "post.success", false);
      newState = update.set(newState, "post.errors", {});
      newState = update.set(newState, "post.failed", false);
      break;
    }
    case FORGOT_POST_SUCCESS: {
      newState = update.set(state, "post.loading", false);
      newState = update.set(newState, "post.failed", false);
      newState = update.set(newState, "post.errors", {});
      newState = update.set(newState, "post.success", true);
      break;
    }
    case FORGOT_POST_FAILED: {
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

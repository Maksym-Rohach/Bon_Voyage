import update from "../../../helpers/update";
import NewPasswordService from "../NewPasswordPage/NewPasswordService";


export const NEW_PASSWORD_POST_STARTED = "NEW_PASSWORD_POST_STARTED";
export const NEW_PASSWORD_POST_SUCCESS = "NEW_PASSWORD_POST_SUCCESS";
export const NEW_PASSWORD_POST_FAILED = "NEW_PASSWORD_POST_FAILED";

const initialState = {
    post: {
      loading: false,
      success: false,
      failed: false,
      errors: {}
    } 
  };
  
  export const NewPasswordReducer = (state = initialState, action) => {
    let newState = state;
    switch (action.type) {
      case NEW_PASSWORD_POST_STARTED: {
        newState = update.set(state, "post.loading", true);
        newState = update.set(newState, "post.success", false);
        newState = update.set(newState, "post.errors", {});
        newState = update.set(newState, "post.failed", false);
        break;        
      }
      case NEW_PASSWORD_POST_SUCCESS: {
        newState = update.set(state, "post.loading", false);
        newState = update.set(newState, "post.failed", false);
        newState = update.set(newState, "post.errors", {});
        newState = update.set(newState, "post.success", true);
        break;
      }
      case NEW_PASSWORD_POST_FAILED: {
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
  
  export const getListActions = {
    started: () => {
        return {
            type: NEW_PASSWORD_POST_STARTED
        }
    },  
    success: () => {
        return {
            type: NEW_PASSWORD_POST_SUCCESS,      
        }
    },  
    failed: (error) => {
      console.log("Error : ",error)
        return {           
            type: NEW_PASSWORD_POST_FAILED,
            errors: error.data
        }
    }
  }
  

export function newPassword(data) {
  return (dispatch) => {
    dispatch(getListActions.started());
    NewPasswordService.newPassword(data)
        .then((response) => {
          console.log("response",response);
            dispatch(getListActions.success(response));               
        }, err=> { throw err; })
        .catch(err=> {
          dispatch(getListActions.failed(err.response));
        });
}
}
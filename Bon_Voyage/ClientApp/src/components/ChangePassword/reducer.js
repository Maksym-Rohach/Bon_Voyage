import ChangePasswordService from './ChangePasswordService';
import update from '../../helpers/update';
export const PASSWORD_STARTED = "PASSWORD_STARTED";
export const PASSWORD_SUCCESS = "PASSWORD_SUCCESS";
export const PASSWORD_FAILED = "PASSWORD_FAILED";


const initialState = {
    list: {
        errors:'',
        loading: false,
        success: false,
        failed: false,
    },   
}

export const changePassword = (model) => {
    return (dispatch) => {
        dispatch(getListActions.started());
        ChangePasswordService.changePassword(model)
            .then((response) => {
                dispatch(getListActions.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
              dispatch(getListActions.failed(err.response));
            });
    }
}

export const getListActions = {
    started: () => {
        return {
            type: PASSWORD_STARTED
        }
    },  
    success: () => {
        return {
            type: PASSWORD_SUCCESS,
        }
    },  
    failed: (error) => {
        console.log("error", error);
        return {           
            type: PASSWORD_FAILED,
            errors: error.data
        }
    }
  }

export const changePasswordReducer = (state = initialState, action) => { 
  let newState = state;

  switch (action.type) {

      case PASSWORD_STARTED: {
          newState = update.set(state, 'list.loading', true);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', false);
          break;
      }
      case PASSWORD_SUCCESS: {
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.failed', false);
          newState = update.set(newState, 'list.success', true);      
          break;
      }
      case PASSWORD_FAILED: {
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', true);
          newState = update.set(newState, "list.errors", action.errors);
          break;
      }
      default: {
          return newState;
      }
  }
  return newState;
}
import ManagerControlService from './ManagerControlService';
import update from '../../../helpers/update';
export const MANAGER_CONTROL_STARTED = "MANAGER_CONTROL_STARTED";
export const MANAGER_CONTROL_SUCCESS = "MANAGER_CONTROL_SUCCESS";
export const MANAGER_CONTROL_FAILED = "MANAGER_CONTROL_FAILED";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },   
}

export const getManagerControlData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        ManagerControlService.getAllManagers()
            .then((response) => {            
                dispatch(getListActions.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
              dispatch(getListActions.failed(err));
            });
    }
}

export const getListActions = {
    started: () => {
        return {
            type: MANAGER_CONTROL_STARTED
        }
    },  
    success: (data) => {
        return {
            type: MANAGER_CONTROL_SUCCESS,
            payload: data.data
        }
    },  
    failed: (error) => {
        return {           
            type: MANAGER_CONTROL_FAILED,
            error: error,
        }
    }
  }

export const managerControlReducer = (state = initialState, action) => { 
  let newState = state;

  switch (action.type) {

      case MANAGER_CONTROL_STARTED: {
          newState = update.set(state, 'list.loading', true);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', false);
          break;
      }
      case MANAGER_CONTROL_SUCCESS: {
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.failed', false);
          newState = update.set(newState, 'list.success', true);
          newState = update.set(newState, 'list.data', action.payload);         
          break;
      }
      case MANAGER_CONTROL_FAILED: {
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', true);
          break;
      }
      default: {
          return newState;
      }
  }
  return newState;
}
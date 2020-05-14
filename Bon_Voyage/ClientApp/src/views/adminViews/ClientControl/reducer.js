import ClientControlService from './ClientControlService';
import update from '../../../helpers/update';
export const CLIENT_CONTROL_STARTED = "CLIENT_CONTROL_STARTED";
export const CLIENT_CONTROL_SUCCESS = "CLIENT_CONTROL_SUCCESS";
export const CLIENT_CONTROL_FAILED = "CLIENT_CONTROL_FAILED";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },   
}

export const getClientControlData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        ClientControlService.getAllClients()
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
            type: CLIENT_CONTROL_STARTED
        }
    },  
    success: (data) => {
        return {
            type: CLIENT_CONTROL_SUCCESS,
            payload: data.data
        }
    },  
    failed: (error) => {
        return {           
            type: CLIENT_CONTROL_FAILED,
            error: error,
        }
    }
  }

  export const clientControlReducer = (state = initialState, action) => { 
    let newState = state;
  
    switch (action.type) {
  
        case CLIENT_CONTROL_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case CLIENT_CONTROL_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.data', action.payload);         
            break;
        }
        case CLIENT_CONTROL_FAILED: {
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
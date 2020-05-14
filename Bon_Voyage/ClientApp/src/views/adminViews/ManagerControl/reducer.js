import ManagerControlService from './ManagerControlService';
import update from '../../../helpers/update';
import { CREATE_AIRPORT_STARTED } from '../AirportControl/reducer';
export const MANAGER_CONTROL_STARTED = "MANAGER_CONTROL_STARTED";
export const MANAGER_CONTROL_SUCCESS = "MANAGER_CONTROL_SUCCESS";
export const MANAGER_CONTROL_FAILED = "MANAGER_CONTROL_FAILED";

export const MANAGER_CREATE_STARTED = "MANAGER_CREATE_STARTED";
export const MANAGER_CREATE_SUCCESS = "MANAGER_CREATE_SUCCESS";
export const MANAGER_CREATE_FAILED = "MANAGER_CREATE_FAILED";
export const MANAGER_CREATE_CLEAR = "MANAGER_CREATE_CLEAR";

const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },
    createResult: {
        data: [],
        loading: false,
        success: false,
        failed: false,
        errors: {},
    }
}

export const getManagerControlData = () => {
    return (dispatch) => {
        dispatch(getManagerListActions.started());
        ManagerControlService.getAllManagers()
            .then((response) => {
                dispatch(getManagerListActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                dispatch(getManagerListActions.failed(err));
            });
    }
}

export const createManager = (model) => {
    return (dispatch) => {
        dispatch(createManagerListActions.started());
        ManagerControlService.createManager(model)
            .then((response) => {
                ManagerControlService.getAllManagers()
                    .then((response) => {
                        dispatch(getManagerListActions.success(response));
                    }, err => { throw err; })
                    .catch(err => {
                        dispatch(getManagerListActions.failed(err));
                    });
                dispatch(createManagerListActions.success(response))
            }, err => { throw err; })
            .catch((err) => {
                if (err.response !== undefined){
                    dispatch(createManagerListActions.failed(err.response.data)); 
                    console.log(err.response.data);
                }                    
                else { dispatch(createManagerListActions.failed(err)) }
            })
    }
}

export const clearErrors=()=>{
    return (dispatch) => {
        dispatch(createManagerListActions.clear());
    }
}

export const getManagerListActions = {
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

export const createManagerListActions = {
    started: () => {
        return {
            type: MANAGER_CREATE_STARTED
        }
    },
    success: (data) => {
        return {
            type: MANAGER_CREATE_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: MANAGER_CREATE_FAILED,
            error: error,
        }
    },
    clear: () => {
        return {
            type: MANAGER_CREATE_CLEAR,
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
        case MANAGER_CREATE_STARTED: {
            newState = update.set(state, 'createResult.loading', true);
            newState = update.set(newState, 'createResult.success', false);
            newState = update.set(newState, 'createResult.failed', false);
            break;
        }
        case MANAGER_CREATE_SUCCESS: {
            newState = update.set(state, 'createResult.loading', false);
            newState = update.set(newState, 'createResult.failed', false);
            newState = update.set(newState, 'createResult.success', true);
            newState = update.set(newState, 'createResult.errors', {status:true});
            break;
        }
        case MANAGER_CREATE_FAILED: {
            newState = update.set(state, 'createResult.loading', false);
            newState = update.set(newState, 'createResult.success', false);
            newState = update.set(newState, 'createResult.failed', true);
            newState = update.set(newState, 'createResult.errors', action.error);
            break;
        }
        case MANAGER_CREATE_CLEAR: {
            newState = update.set(state, 'createResult.loading', false);
            newState = update.set(newState, 'createResult.failed', false);
            newState = update.set(newState, 'createResult.success', false);
            newState = update.set(newState, 'createResult.errors', undefined);
            break;
        }
        default: {
            return newState;
        }
    }
    return newState;
}
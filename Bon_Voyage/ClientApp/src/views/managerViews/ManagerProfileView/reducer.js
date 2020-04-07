import ManagerProfileViewService from './ManagerProfileViewService';
import update from '../../../helpers/update';
export const MANAGER_PROFILE_STARTED = "MANAGER_PROFILE_STARTED";
export const MANAGER_PROFILE_SUCCESS = "MANAGER_PROFILE_SUCCESS";
export const MANAGER_PROFILE_FAILED = "MANAGER_PROFILE_FAILED";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },
}

export const getManagerProfileViewData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        ManagerProfileViewService.getManagerProfile()
            .then((response) => {
                dispatch(getListActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                dispatch(getListActions.failed(err));
            });
    }
}

export const getListActions = {
    started: () => {
        return {
            type: MANAGER_PROFILE_STARTED
        }
    },
    success: (data) => {
        return {
            type: MANAGER_PROFILE_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: MANAGER_PROFILE_FAILED,
            error: error,
        }
    }
}

export const managerProfileViewReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case MANAGER_PROFILE_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case MANAGER_PROFILE_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.data', action.payload);
            break;
        }
        case MANAGER_PROFILE_FAILED: {
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
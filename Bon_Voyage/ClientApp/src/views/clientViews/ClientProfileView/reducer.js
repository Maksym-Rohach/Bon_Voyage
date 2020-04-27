import ClientProfileViewService from './ClientProfileViewService';
import update from '../../../helpers/update';
export const CLIENT_PROFILE_STARTED = "CLIENT_PROFILE_STARTED";
export const CLIENT_PROFILE_SUCCESS = "CLIENT_PROFILE_SUCCESS";
export const CLIENT_PROFILE_FAILED = "CLIENT_PROFILE_FAILED";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },
}

export const getClientProfileViewData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        ClientProfileViewService.getClientProfile()
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
            type: CLIENT_PROFILE_STARTED
        }
    },
    success: (data) => {
        return {
            type: CLIENT_PROFILE_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: CLIENT_PROFILE_FAILED,
            error: error,
        }
    }
}

export const clientProfileViewReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case CLIENT_PROFILE_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case CLIENT_PROFILE_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.data', action.payload);
            break;
        }
        case CLIENT_PROFILE_FAILED: {
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
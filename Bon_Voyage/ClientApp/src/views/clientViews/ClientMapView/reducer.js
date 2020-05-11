import ClientMapViewService from './ClientMapViewService';
import update from '../../../helpers/update';
export const CLIENT_MAP_STARTED = "CLIENT_MAP_STARTED";
export const CLIENT_MAP_SUCCESS = "CLIENT_MAP_SUCCESS";
export const CLIENT_MAP_FAILED = "CLIENT_MAP_FAILED";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },
}

export const getListActions = {
    started: () => {
        return {
            type: CLIENT_MAP_STARTED
        }
    },
    success: (data) => {
        return {
            type: CLIENT_MAP_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: CLIENT_MAP_FAILED,
            error: error,
        }
    }
}

export const clientMapViewReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case CLIENT_MAP_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case CLIENT_MAP_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.data', action.payload);
            break;
        }
        case CLIENT_MAP_FAILED: {
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
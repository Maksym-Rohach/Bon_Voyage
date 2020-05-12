import ClientMessageViewService from './ClientMessageViewService';
import ClientMessageView from './ClientMessageView';
import update from '../../../helpers/update';
export const CLIENT_MESSAGE_STARTED = "CLIENT_MESSAGE_STARTED";
export const CLIENT_MESSAGE_SUCCESS = "CLIENT_MESSAGE_SUCCESS";
export const CLIENT_MESSAGE_FAILED = "CLIENT_MESSAGE_FAILED";


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
            type: CLIENT_MESSAGE_STARTED
        }
    },
    success: (data) => {
        return {
            type: CLIENT_MESSAGE_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: CLIENT_MESSAGE_FAILED,
            error: error,
        }
    }
}

export const sendmessage = (model) => {
    return (dispatch) => {
        dispatch(getListActions.started());
        ClientMessageViewService.sendmessage(model)
            .then((response) => {
                console.log("Response",response);
                dispatch(getListActions.success());
            }, err => { throw err; })
            .catch(err => {
                dispatch(getListActions.failed(err));
            });
    }
}

export const clientMessageViewReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case CLIENT_MESSAGE_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case CLIENT_MESSAGE_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.data', action.payload);
            break;
        }
        case CLIENT_MESSAGE_FAILED: {
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
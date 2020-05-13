import FeedBackViewService from './FeedBackService';
import update from '../../../helpers/update';
export const FEEDBACK_STARTED = "FEEDBACK_STARTED";
export const FEEDBACK_SUCCESS = "FEEDBACK_SUCCESS";
export const FEEDBACK_FAILED = "FEEDBACK_FAILED";

const initialState = {
    list: {
        messages: [],
        loading: false,
        success: false,
        failed: false,
    },
}

export const getListActions = {
    started: () => {
        return {
            type: FEEDBACK_STARTED
        }
    },
    success: (data) => {
        return {
            type: FEEDBACK_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: FEEDBACK_FAILED,
            error: error,
        }
    }
}

export const getmessage = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        FeedBackViewService.getFeedBack()
            .then((response) => {
                console.log("Response",response);
                dispatch(getListActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                console.log("Catch",err.response)
                dispatch(getListActions.failed(err));
            });
    }
}

export const FeedBackReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case FEEDBACK_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case FEEDBACK_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.message', action.payload);
            break;
        }
        case FEEDBACK_FAILED: {
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
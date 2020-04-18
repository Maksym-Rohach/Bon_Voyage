import HotDealTicketsService from './HotDealTicketsService';
import update from '../../../helpers/update';
export const HOT_DEAL_STARTED = "HOT_DEAL_STARTED";
export const HOT_DEAL_SUCCESS = "HOT_DEAL_SUCCESS";
export const HOT_DEAL_FAILED = "HOT_DEAL_FAILED";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },
}

export const getHotDealTicketsData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        HotDealTicketsService.getHotDealTickets()
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
            type: HOT_DEAL_STARTED
        }
    },
    success: (data) => {
        return {
            type: HOT_DEAL_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: HOT_DEAL_FAILED,
            error: error,
        }
    }
}

export const hotDealTicketsReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case HOT_DEAL_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case HOT_DEAL_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.data', action.payload);
            break;
        }
        case HOT_DEAL_FAILED: {
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
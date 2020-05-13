import FavoriteTicketsService from './FavoriteTicketsService';
import update from '../../../helpers/update';

export const TICKET_STARTED = "TICKET_STARTED";
export const TICKET_SUCCESS = "TICKET_SUCCESS";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
    },
}

export const getClientProfileViewData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        FavoriteTicketsService.GetTickets()
            .then((response) => {
                dispatch(getListActions.success(response));
            }, err => { throw err; })
    }
}

export const getListActions = {
    started: () => {
        return {
            type: TICKET_STARTED
        }
    },
    success: (data) => {
        return {
            type: TICKET_SUCCESS,
            payload: data.data
        }
    }
}

export const clientProfileViewReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case CLIENT_PROFILE_STARTED:
            {
                newState = update.set(state, 'list.loading', true);
                newState = update.set(newState, 'list.success', false);
                newState = update.set(newState, 'list.failed', false);
                break;
            }
        case CLIENT_PROFILE_SUCCESS:
            {
                newState = update.set(state, 'list.loading', false);
                newState = update.set(newState, 'list.failed', false);
                newState = update.set(newState, 'list.success', true);
                newState = update.set(newState, 'list.data', action.payload);
                break;
            }
        default:
            {
                return newState;
            }
    }
    return newState;
}
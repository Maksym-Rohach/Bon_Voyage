import FavoriteTicketsService from './FavoriteTicketsService';
import update from '../../../helpers/update';

export const TICKET_STARTED = "TICKET_STARTED";
export const TICKET_SUCCESS = "TICKET_SUCCESS";

export const TICKET_BUY_SUCCESS = "TICKET_BUY_SUCCESS";

const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
    },
    addSuccess: false,
}

export const getTicketsData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        FavoriteTicketsService.GetTickets()
            .then((response) => {
                dispatch(getListActions.success(response));
            }, err => { throw err; })
    }
}

export const buyTicket = (model) => {
    return (dispatch) => {
        FavoriteTicketsService.BuyTicket(model)
            .then((response) => {
                console.log(response);
                dispatch(buyTicketListActions.success());
            })
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

export const buyTicketListActions = {
    success: (data) => {
        return {
            type: TICKET_BUY_SUCCESS,
        }
    }
}


export const cartTicketReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case TICKET_STARTED:
            {
                newState = update.set(state, 'list.loading', true);
                newState = update.set(newState, 'list.success', false);
                newState = update.set(newState, 'list.failed', false);
                break;
            }
        case TICKET_SUCCESS:
            {
                newState = update.set(state, 'list.loading', false);
                newState = update.set(newState, 'list.failed', false);
                newState = update.set(newState, 'list.success', true);
                newState = update.set(newState, 'list.data', action.payload);
                break;
            }

        case TICKET_BUY_SUCCESS:
            {
                newState = update.set(state, 'addSuccess', true);
            }
        default:
            {
                return newState;
            }
    }
    return newState;
}
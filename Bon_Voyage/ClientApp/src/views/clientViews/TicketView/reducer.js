import TicketViewService from './TicketViewService';
import update from '../../../helpers/update';
export const TICKET_STARTED = "TICKET_STARTED";
export const TICKET_SUCCESS = "TICKET_SUCCESS";
export const TICKET_FAILED = "TICKET_FAILED";

export const FILTER_STARTED = "FILTER_STARTED";
export const FILTER_SUCCESS = "FILTER_SUCCESS";
export const FILTER_FAILED = "FILTER_FAILED";

export const HOTEL_STARTED = "HOTEL_STARTED";
export const HOTEL_SUCCESS = "HOTEL_SUCCESS";
export const HOTEL_FAILED = "HOTEL_FAILED";

export const TICKET_BUY_STARTED = "TICKET_BUY_STARTED";
export const TICKET_BUY_SUCCESS = "TICKET_BUY_SUCCESS";
export const TICKET_BUY_FAILED = "TICKET_BUY_FAILED";

const initialState = {
    list: {
        filters: {},
        hotels: [],
        data: [],
        loading: false,
        success: false,
        failed: false,
    },
}

export const getTicketsData = (indx, filters) => {
    return (dispatch) => {
        dispatch(getListActions.started());
        TicketViewService.getTicketsWithFiltres(indx, filters)
            .then((response) => {
                dispatch(getListActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                console.log(err.response.data);
                dispatch(getListActions.failed(err));
            });
    }
}

export const getFiltersData = () => {
    return (dispatch) => {
        dispatch(getFilterListActions.started());
        TicketViewService.getFiltersData()
            .then((response) => {
                dispatch(getFilterListActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                dispatch(getFilterListActions.failed(err));
            });
    }
}

export const getHotelsData = (countryId) => {
    return (dispatch) => {
        dispatch(getHotelListActions.started());
        TicketViewService.getHotelsData(countryId)
            .then((response) => {
                dispatch(getHotelListActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                dispatch(getHotelListActions.failed(err));
            });
    }
}

export const buyTicket = (ticketId, indx, filters) => {
    return (dispatch) => {
        dispatch(buyTicketListActions.started());
        TicketViewService.buyTicket(ticketId)
            .then((response) => {                
                TicketViewService.getFiltersData(indx, filters)
                    .then((response) => {
                        dispatch(getListActions.success(response));
                    }, err => { throw err; })
                    .catch(err => {
                        dispatch(getListActions.failed(err));
                    });
                    dispatch(buyTicketListActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                dispatch(buyTicketListActions.failed(err));
            });
    }
}

export const getFilterListActions = {
    started: () => {
        return {
            type: FILTER_STARTED
        }
    },
    success: (data) => {
        return {
            type: FILTER_SUCCESS,
            payload: data
        }
    },
    failed: (error) => {
        return {
            type: FILTER_FAILED,
            errors: error
        }
    }
}

export const getHotelListActions = {
    started: () => {
        return {
            type: HOTEL_STARTED
        }
    },
    success: (data) => {
        return {
            type: HOTEL_SUCCESS,
            payload: data
        }
    },
    failed: (error) => {
        return {
            type: HOTEL_FAILED,
            errors: error
        }
    }
}

export const buyTicketListActions = {
    started: () => {
        return {
            type: HOTEL_STARTED
        }
    },
    success: (data) => {
        return {
            type: HOTEL_SUCCESS,
            payload: data
        }
    },
    failed: (error) => {
        return {
            type: HOTEL_FAILED,
            errors: error
        }
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
            payload: data
        }
    },
    failed: (error) => {
        return {
            type: TICKET_FAILED,
            errors: error
        }
    }
}

export const ticketReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case TICKET_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case TICKET_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.data', action.payload);
            break;
        }
        case TICKET_FAILED: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', true);
            break;
        }
        case FILTER_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case FILTER_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.filters', action.payload);
            break;
        }
        case FILTER_FAILED: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', true);
            break;
        }
        case HOTEL_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case HOTEL_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.hotels', action.payload);
            break;
        }
        case HOTEL_FAILED: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', true);
            break;
        }
        case TICKET_BUY_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case TICKET_BUY_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            break;
        }
        case TICKET_BUY_FAILED: {
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
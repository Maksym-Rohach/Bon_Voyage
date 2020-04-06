import AirportControlService from './AirportControlService';
import update from '../../../helpers/update';
import AirportControl from './AirportControl';
export const AIRPORT_CONTROL_STARTED = "AIRPORT_CONTROL_STARTED";
export const AIRPORT_CONTROL_SUCCESS = "AIRPORT_CONTROL_SUCCESS";
export const AIRPORT_CONTROL_FAILED = "AIRPORT_CONTROL_FAILED";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },
}

export const getAirportControlData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        AirportControlService.getAllAirports()
            .then((response) => {
                dispatch(getListActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                dispatch(getListActions.failed(err));
            });
    }
}

export const createAirport = (model) => {
    return (dispatch) => {
        dispatch(getListActions.started);
        AirportControlService.createAirport(model)
            .then((response) => {
                dispatch(getListActions.success(response));
            })
            .catch(err => {
                dispatch(getListActions.failed(err));
            })
    }
}

export const getListActions = {
    started: () => {
        return {
            type: AIRPORT_CONTROL_STARTED
        }
    },
    success: (data) => {
        return {
            type: AIRPORT_CONTROL_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: AIRPORT_CONTROL_FAILED,
            error: error,
        }
    }
}

export const airportControlReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case AIRPORT_CONTROL_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case AIRPORT_CONTROL_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.data', action.payload);
            break;
        }
        case AIRPORT_CONTROL_FAILED: {
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
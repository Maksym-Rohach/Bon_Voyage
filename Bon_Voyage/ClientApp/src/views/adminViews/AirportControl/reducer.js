import AirportControlService from './AirportControlService';
import update from '../../../helpers/update';
import AirportControl from './AirportControl';
export const AIRPORT_CONTROL_STARTED = "AIRPORT_CONTROL_STARTED";
export const AIRPORT_CONTROL_SUCCESS = "AIRPORT_CONTROL_SUCCESS";
export const AIRPORT_CONTROL_FAILED = "AIRPORT_CONTROL_FAILED";

export const CITY_CONTROL_STARTED = "CITY_CONTROL_STARTED";
export const CITY_CONTROL_SUCCESS = "CITY_CONTROL_SUCCESS";
export const CITY_CONTROL_FAILED = "CITY_CONTROL_FAILED";

export const COUNTRY_CONTROL_STARTED = "COUNTRY_CONTROL_SUCCESS";
export const COUNTRY_CONTROL_SUCCESS = "COUNTRY_CONTROL_SUCCESS";
export const COUNTRY_CONTROL_FAILED = "COUNTRY_CONTROL_SUCCESS";


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
        dispatch(getAirportListActions.started());
        AirportControlService.getAllAirports()
            .then((response) => {
                dispatch(getAirportListActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                dispatch(getAirportListActions.failed(err));
            });
    }
}

export const createAirport = (model) => {
    return (dispatch) => {
        dispatch(getAirportListActions.started);
        AirportControlService.createAirport(model)
            .then((response) => {
                dispatch(getAirportListActions.success(response));
            })
            .catch(err => {
                dispatch(getAirportListActions.failed(err));
            })
    }
}

export const getCountries = () => {
    return (dispatch) => {
        dispatch(getAirportListActions.started);
        AirportControlService.getCountries()
            .then((response) => {
                console.log(response)
                dispatch(getCountryListActions.success(response));
            })
            .catch(err => {
                dispatch(getCountryListActions.failed(err));
            })
    }
}

export const getAirportListActions = {
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

export const getCountryListActions = {
    started: () => {
        return {
            type: COUNTRY_CONTROL_STARTED
        }
    },
    success: (data) => {
        return {
            type: CITY_CONTROL_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: CITY_CONTROL_FAILED,
            error: error,
        }
    }
}

export const getCityListActions = {
    started: () => {
        return {
            type: CITY_CONTROL_STARTED
        }
    },
    success: (data) => {
        return {
            type: CITY_CONTROL_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: CITY_CONTROL_FAILED,
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

export const countryControlReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case COUNTRY_CONTROL_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case COUNTRY_CONTROL_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.data', action.payload);
            break;
        }
        case COUNTRY_CONTROL_FAILED: {
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
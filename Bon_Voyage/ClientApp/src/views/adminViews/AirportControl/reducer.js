import AirportControlService from './AirportControlService';
import update from '../../../helpers/update';
import AirportControl from './AirportControl';
export const AIRPORT_CONTROL_STARTED = "AIRPORT_CONTROL_STARTED";
export const AIRPORT_CONTROL_SUCCESS = "AIRPORT_CONTROL_SUCCESS";
export const AIRPORT_CONTROL_FAILED = "AIRPORT_CONTROL_FAILED";

export const CREATE_AIRPORT_STARTED = "CREATE_AIRPORT_STARTED";
export const CREATE_AIRPORT_SUCESS = "CREATE_AIRPORT_SUCESS";
export const CREATE_AIRPORT_FAILED = "CREATE_AIRPORT_FAILED";
export const CREATE_AIRPORT_CLEAR ="CREATE_AIRPORT_CLEAR";

export const CITY_CONTROL_STARTED = "CITY_CONTROL_STARTED";
export const CITY_CONTROL_SUCCESS = "CITY_CONTROL_SUCCESS";
export const CITY_CONTROL_FAILED = "CITY_CONTROL_FAILED";

const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
        errors: undefined
    },
    cities: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    }
}

export const clearErrors = () =>{
    return (dispatch) => {
        dispatch(createAirportListActions.clear());
    }
    
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
        dispatch(createAirportListActions.started());
        AirportControlService.createAirport(model)
            .then((response) => {
                AirportControlService.getAllAirports()
                    .then((response) => {
                        dispatch(getAirportListActions.success(response));
                    }, err => { throw err; })
                    .catch(err => {
                        dispatch(getAirportListActions.failed(err));
                    });          
            }, err => { throw err; })
            .catch((err) => {
                if (err.response !== undefined)
                    dispatch(createAirportListActions.failed(err.response.data));
                else { dispatch(createAirportListActions.failed(err)) }
            })
    }
}

export const getCitiesByCountry = (countryId) => {
    return (dispatch) => {
        dispatch(getCityListActions.started);
        AirportControlService.getCityByCountry(countryId)
            .then((response) => {
                dispatch(getCityListActions.success(response));
            })
            .catch(err => {
                dispatch(getCityListActions.failed(err));
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

export const createAirportListActions = {
    started: () => {
        return {
            type: CREATE_AIRPORT_STARTED
        }
    },
    success: (data) => {
        return {
            type: CREATE_AIRPORT_SUCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: CREATE_AIRPORT_FAILED,
            error: error,
        }
    },
    clear:()=>{
        return{
            type:CREATE_AIRPORT_CLEAR
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
            error: error
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
        case CREATE_AIRPORT_STARTED: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case CREATE_AIRPORT_SUCESS: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.errors', undefined);
            break;
        }
        case CREATE_AIRPORT_FAILED: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', true);
            newState = update.set(newState, 'list.errors', action.error);
            break;
        }
        case CREATE_AIRPORT_CLEAR: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.errors', undefined);
            break;
        }
        case CITY_CONTROL_STARTED: {
            newState = update.set(state, 'cities.loading', true);
            newState = update.set(newState, 'cities.success', false);
            newState = update.set(newState, 'cities.failed', false);
            break;
        }
        case CITY_CONTROL_SUCCESS: {
            newState = update.set(state, 'cities.loading', false);
            newState = update.set(newState, 'cities.failed', false);
            newState = update.set(newState, 'cities.success', true);
            newState = update.set(newState, 'cities.data', action.payload);
            break;
        }
        case CITY_CONTROL_FAILED: {
            newState = update.set(state, 'cities.loading', false);
            newState = update.set(newState, 'cities.success', false);
            newState = update.set(newState, 'cities.failed', true);
            break;
        }
        default: {
            return newState;
        }
    }
    return newState;
}
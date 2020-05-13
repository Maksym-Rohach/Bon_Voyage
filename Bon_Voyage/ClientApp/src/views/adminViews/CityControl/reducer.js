import CityControlService from './CityControlService';
import update from '../../../helpers/update';

export const CITY_STARTED = "CITY_STARTED";
export const CITY_SUCCESS = "CITY_SUCCESS";
export const CITY_FAILED = "CITY_FAILED";

const initialState = {
    cities: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    }
}

export const getCityData = () => {
    return (dispatch) => {
        dispatch(getCityListActions.started());
        CityControlService.getAllCities()
            .then((response) => {
                dispatch(getCityListActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                dispatch(getCityListActions.failed(err));
            });
    }
}

export const getCityListActions = {
    started: () => {
        return {
            type: CITY_STARTED
        }
    },
    success: (data) => {
        return {
            type: CITY_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: CITY_FAILED,
            error: error
        }
    }
}

export const cityControlReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case CITY_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case CITY_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.data', action.payload);
            break;
        }
        case CITY_FAILED: {
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
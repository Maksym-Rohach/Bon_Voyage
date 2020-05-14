import HotelControlService from './HotelControlService';
import update from '../../../helpers/update';
import { HotelsActions } from '../../managerViews/AddTicketView/reducer';
export const HOTEL_CONTROL_STARTED = "HOTEL_CONTROL_STARTED";
export const HOTEL_CONTROL_SUCCESS = "HOTEL_CONTROL_SUCCESS";
export const HOTEL_CONTROL_FAILED = "HOTEL_CONTROL_FAILED";

export const HOTEL_ADD_STARTED = "HOTEL_ADD_STARTED";
export const HOTEL_ADD_SUCCESS = "HOTEL_ADD_SUCCESS";
export const HOTEL_ADD_FAILED = "HOTEL_ADD_FAILED";
export const HOTEL_ADD_CLEAR = "HOTEL_ADD_CLEAR";

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

export const getHotelControlData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        HotelControlService.getAllHotels()
            .then((response) => {            
                dispatch(getListActions.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
              dispatch(getListActions.failed(err));
            });
    }
}

export const addHotel = (hotel) => {
    return (dispatch) => {
        dispatch(addHotelListActions.started()); // Set started action
        HotelControlService.addHotel(hotel) // Get data from service
            .then((response) => {     
                HotelControlService.getAllHotels()
                .then((response) => {
                    dispatch(addHotelListActions.success(response));
                    dispatch(addHotelListActions.clear())
                }, err => {throw err; })
                .catch(err => {
                    dispatch(addHotelListActions.failed(err));
                });
                dispatch(addHotelListActions.success(response))
            }, err=> { throw err; })
            .catch(err=> {    
                if (err.response !== undefined){
                    dispatch(addHotelListActions.failed(err.response.data));
                    console.log(err.response.data);
                }        
                else{dispatch(addHotelListActions.failed(err)) }
            })
            
    }
}

export const getCitiesByCountry = (countryId) => {
    return (dispatch) => {
        dispatch(getCityListActions.started);
        HotelControlService.getCityByCountry(countryId)
            .then((response) => {
                dispatch(getCityListActions.success(response));
            })
            .catch(err => {
                dispatch(getCityListActions.failed(err));
            })
    }
}

export const clearErrors = () =>{
    return (dispatch) => {
        dispatch(addHotelListActions.clear());
    }
}

export const getListActions = {
    started: () => {
        return {
            type: HOTEL_CONTROL_STARTED
        }
    },  
    success: (data) => {
        return {
            type: HOTEL_CONTROL_SUCCESS,
            payload: data.data
        }
    },  
    failed: (error) => {
        return {           
            type: HOTEL_CONTROL_FAILED,
            error: error,
        }
    }
  }

  export const addHotelListActions = {
    started: () => {
        return {
            type: HOTEL_ADD_STARTED
        }
    },
    success: (data) => {
        return {
            type: HOTEL_ADD_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: HOTEL_ADD_FAILED,
            error: error,
        }
    },
    clear: () => {
        return {
            type: HOTEL_ADD_CLEAR,
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

  export const hotelControlReducer = (state = initialState, action) => { 
    let newState = state;
  
    switch (action.type) {
  
        case HOTEL_CONTROL_STARTED: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case HOTEL_CONTROL_SUCCESS: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.data', action.payload);         
            break;
        }
        case HOTEL_CONTROL_FAILED: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', true);
            break;
        }
        case HOTEL_ADD_STARTED: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', false);
            break;
        }
        case HOTEL_ADD_SUCCESS: {
            newState = update.set(state, 'list.loading', true);
            newState = update.set(newState, 'list.failed', false);
            newState = update.set(newState, 'list.success', true);
            newState = update.set(newState, 'list.errors', {status:true});
            break;
        }
        case HOTEL_ADD_FAILED: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', true);
            newState = update.set(newState, 'list.errors', action.error);
            break;
        }
        case HOTEL_ADD_CLEAR: {
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
import HotelControlService from './HotelControlService';
import update from '../../../helpers/update';
import { HotelsActions } from '../../managerViews/AddTicketView/reducer';
export const HOTEL_CONTROL_STARTED = "HOTEL_CONTROL_STARTED";
export const HOTEL_CONTROL_SUCCESS = "HOTEL_CONTROL_SUCCESS";
export const HOTEL_CONTROL_FAILED = "HOTEL_CONTROL_FAILED";

export const COUNTRIES_STARTED = "COUNTRIES_STARTED";
export const COUNTRIES_SUCCESS = "COUTRIES_SUCCESS";
export const COUNTRIES_FAILED = "COUNTRIES_FAILED";
export const CITIES_SUCCESS = "CITIES_SUCCESS";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },   
    countries: {
        data:[],
        loading: false,
        success: false,
        failed: false,
    },
    cities:[]
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
        dispatch(HotelsActions.started()); // Set started action
        HotelControlService.addHotel(hotel) // Get data from service
            .then((response) => {       
                console.log("Add hotel - ",response);
                dispatch(HotelsActions.success(response)); // Set success action
            }, err=> { throw err; })
            .catch(err=> {            
                console.log("Add hotel error - ",err.response);
              dispatch(HotelsActions.failed(err.response));
            });
            
    }
}

export const getCountryData = () => {
    return (dispatch) => {
        dispatch(CountriesActions.started());
        HotelControlService.GetCountries()     
            .then((response) => {            
                dispatch(CountriesActions.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
                console.log('GetCountryData error - ' + err);
                dispatch(CountriesActions.failed(err.response));
            });
            
    }
}

export const getCityData = (countryId) => {
    return (dispatch) => {
        HotelControlService.GetCities(countryId)
            .then((response) => {
                dispatch(CitiesActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                console.log('GetCitiesData error - ' + err);
            });
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

  export const CountriesActions = {
    started: () => {
        return {
            type: COUNTRIES_STARTED
        }
    },
    success: (data) => {
        return {
            type: COUNTRIES_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: COUNTRIES_FAILED,
            error: error,
        }
    }
}

export const CitiesActions = {
    success: (data) => {
        return {
            type: CITIES_SUCCESS,
            payload: data.data
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
        default: {
            return newState;
        }
    }
    return newState;
  }
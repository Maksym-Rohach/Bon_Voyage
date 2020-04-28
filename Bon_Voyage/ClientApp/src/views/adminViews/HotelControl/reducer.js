import HotelControlService from './HotelControlService';
import update from '../../../helpers/update';
export const HOTEL_CONTROL_STARTED = "HOTEL_CONTROL_STARTED";
export const HOTEL_CONTROL_SUCCESS = "HOTEL_CONTROL_SUCCESS";
export const HOTEL_CONTROL_FAILED = "HOTEL_CONTROL_FAILED";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },   
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
import AddTicketService from './AddTicketService';
import update from '../../../helpers/update';

export const TICKET_STARTED = "TICKET_STARTED";
export const TICKET_SUCCESS = "TICKET_SUCCESS";
export const TICKET_FAILED = "TICKET_FAILED";

export const COUNTRIES_SUCCESS = "COUTRIES_SUCCESS";
export const AIRPORTS_SUCCESS = "AIRPORTS_SUCCESS";
export const CITIES_SUCCESS = "CITIES_SUCCESS";
export const HOTELS_SUCCESS = "HOTELS_SUCCESS";
export const ROOM_TYPES_SUCCESS = "ROOM_TYPE_SUCCESS";




const initialState = {
    ticketStat: {
        answer: [],
        loading: false,
        success: false,
        failed: false,
    },   
    countries:[],
    airports:[],
    cities:[],
    hotels:[],
    roomTypes:[]
}



//--------------------Methods----------------------



export const addTicket = (ticket) => {
    return (dispatch) => {
        dispatch(TicketActions.started()); // Set started action
        AddTicketService.addTicket(ticket) // Get data from service
            .then((response) => {       
                console.log("Add ticket - ",response);
                dispatch(TicketActions.success(response)); // Set success action
            }, err=> { throw err; })
            .catch(err=> {            
              dispatch(TicketActions.failed(err));
            });
            
    }
}

export const getCountryData = () => {
    return (dispatch) => {
        AddTicketService.GetCountries()     
            .then((response) => {            
                dispatch(CountriesActions.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
                console.log('GetCountryData error - ' + err);
            });
            
    }
}

export const getAirportsData = (countryId) => {
    return (dispatch) => {
        AddTicketService.GetAirports(countryId)
            .then((response) => {
                dispatch(AirportsActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                console.log('GetAirportsData error - ' + err);
            });
    }
}

export const getCitiesData = (countryId) => {
    return (dispatch) => {
        AddTicketService.getCitiesData(countryId)
            .then((response) => {
                dispatch(CitiesActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                console.log('GetCitiesData error - ' + err);
            });
    }
}

export const getHotelsData = (cityId) => {
    return (dispatch) => {
        AddTicketService.getHotelsData(cityId)
            .then((response) => {
                dispatch(HotelsActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                console.log('GetHotelsData error - ' + err);
            });
    }
}

export const getRoomTypesData = () => {
    return (dispatch) => {
        AddTicketService.getRoomTypesData()
            .then((response) => {
                dispatch(roomTypesAction.success(response));
            }, err => { throw err; })
            .catch(err => {
                console.log('GetRoomTypesData error - ' + err);
            });
    }
}


//--------------------Actions----------------------



export const TicketActions = {
    started: () => {
        return {
            type: TICKET_STARTED
        }
    },
    success: () => {
        return {
            type: TICKET_SUCCESS,
        }
    },
    failed: (error) => {
        return {
            type: TICKET_FAILED,
            error: error,
        }
    }
}

export const CountriesActions = {
    success: (data) => {
        return {
            type: COUNTRIES_SUCCESS,
            payload: data.data
        }
    }
}

export const AirportsActions = {
    success: (data) => {
        return {
            type: AIRPORTS_SUCCESS,
            payload: data.data
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

export const HotelsActions = {
    success: (data) => {
        return {
            type: HOTELS_SUCCESS,
            payload: data.data
        }
    }
}

export const roomTypesAction = {
    success: (data) => {
        return {
            type: ROOM_TYPES_SUCCESS,
            payload: data.data
        }
    }
}



//--------------------Reducer----------------------



export const homePageReducer = (state = initialState, action) => { 
  let newState = state;
  switch (action.type) {
      case TICKET_STARTED: {
          newState = update.set(state, 'list.loading', true);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', false);
          break;
      }
      case TICKET_SUCCESS: {
          newState = update.set(state, 'ticketStat.loading', false);
          newState = update.set(newState, 'ticketStat.failed', false);
          newState = update.set(newState, 'ticketStat.success', true);
          break;
      }
      case TICKET_FAILED: {
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', true);
          newState = update.set(newState, 'ticketStat.answer', action.payload);         
          break;
      }

      case COUNTRIES_SUCCESS: {
          newState = update.set(newState,'countries',action.payload);
          break;
      }
      case AIRPORTS_SUCCESS: {
          newState = update.set(newState, 'airports', action.payload);
          break;
      }
      case CITIES_SUCCESS: {
          newState = update.set(newState, 'cities', action.payload);
          break;
      }
      case HOTELS_SUCCESS: {
          newState = update.set(newState, 'hotels', action.payload);
          break;
      }
      case ROOM_TYPES_SUCCESS: {
          newState = update.set(newState, 'roomTypes', action.payload);
          break;
      }


      default: {
          return newState;
      }
  }
  return newState;
}
import AddTicketService from './AddTicketService';
import update from '../../../helpers/update';

export const TICKET_STARTED = "TICKET_STARTED";
export const TICKET_SUCCESS = "TICKET_SUCCESS";
export const TICKET_FAILED = "TICKET_FAILED";

export const COUNTRIES_STARTED = "COUNTRIES_STARTED";
export const COUNTRIES_SUCCESS = "COUTRIES_SUCCESS";
export const COUNTRIES_FAILED = "COUNTRIES_FAILED";

export const AIRPORTS_SUCCESS = "AIRPORTS_SUCCESS";
export const CITIES_SUCCESS = "CITIES_SUCCESS";
export const HOTELS_SUCCESS = "HOTELS_SUCCESS";
export const ROOM_TYPES_SUCCESS = "ROOM_TYPE_SUCCESS";
export const COMFORTS_SUCCESS = "COMFORTS_SUCCESS";

export const CLEAR_SUCCESS = "CLEAR_SUCCESS";



const initialState = {
    ticketStat: {
        answer: {},
        errors:{},
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
    airports:[],
    cities:[],
    hotels:[],
    roomTypes:[],
    comforts:[]
}


//--------------------Methods----------------------



export const addTicket = (ticket) => {
    return (dispatch) => {
        dispatch(TicketActions.started()); // Set started action
        AddTicketService.CreateTicket(ticket) // Get data from service
            .then((response) => {       
                console.log("Add ticket - ",response);
                dispatch(TicketActions.success(response)); // Set success action
            }, err=> { throw err; })
            .catch(err=> {            
                console.log("Add ticket error - ",err.response);
              dispatch(TicketActions.failed(err.response));
            });
            
    }
}

export const getCountryData = () => {
    return (dispatch) => {
        dispatch(CountriesActions.started());
        AddTicketService.GetCountries()     
            .then((response) => {            
                dispatch(CountriesActions.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
                console.log('GetCountryData error - ' + err);
                dispatch(CountriesActions.failed(err.response));
            });
            
    }
}

export const getAirportData = (countryId) => {
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

export const getCityData = (countryId) => {
    return (dispatch) => {
        AddTicketService.GetCities(countryId)
            .then((response) => {
                dispatch(CitiesActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                console.log('GetCitiesData error - ' + err);
            });
    }
}

export const getHotelData = (cityId) => {
    return (dispatch) => {
        AddTicketService.GetHotels(cityId)
            .then((response) => {
                dispatch(HotelsActions.success(response));
            }, err => { throw err; })
            .catch(err => {
                console.log('GetHotelsData error - ' + err);
            });
    }
}

export const getRoomTypeData = () => {
    return (dispatch) => {
        AddTicketService.GetRoomTypes()
            .then((response) => {
                dispatch(roomTypesAction.success(response));
            }, err => { throw err; })
            .catch(err => {
                console.log('GetRoomTypesData error - ' + err);
            });
    }
}

export const getComfortData = () => {
    return (dispatch) => {
        AddTicketService.GetComforts()
            .then((response) => {
                dispatch(comfortsAction.success(response));
            }, err => { throw err; })
            .catch(err => {
                console.log('GetComfortsData error - ' + err);
            });
    }
}

export const clearTicketState = () => {
    return (dispatch) => {
        dispatch(clearActions.success());
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
            error: error.data,
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

export const comfortsAction = {
    success: (data) => {
        return {
            type: COMFORTS_SUCCESS,
            payload: data.data
        }
    }
}

export const clearActions = {
    success: () => {
        return{
            type : CLEAR_SUCCESS
        }
    }
};

//--------------------Reducer----------------------



export const addTicketReducer = (state = initialState, action) => { 
  let newState = state;

  switch (action.type) {
      case TICKET_STARTED: {
          newState = update.set(state, 'ticketStat.loading', true);
          newState = update.set(newState, 'ticketStat.success', false);
          newState = update.set(newState, 'ticketStat.failed', false);
          break;
      }
      case TICKET_SUCCESS: {
          newState = update.set(state, 'ticketStat.loading', false);
          newState = update.set(newState, 'ticketStat.failed', false);
          newState = update.set(newState, 'ticketStat.success', true);
          newState = update.set(newState, 'ticketStat.answer',action.payload);
          break;
      }
      case TICKET_FAILED: {
          newState = update.set(state, 'ticketStat.loading', false);
          newState = update.set(newState, 'ticketStat.success', false);
          newState = update.set(newState, 'ticketStat.failed', true);
          newState = update.set(newState, 'ticketStat.errors', action.error);         
          break;
      }

      case COUNTRIES_STARTED: {
          newState = update.set(state, 'countries.loading', true);
          newState = update.set(newState, 'countries.success', false);
          newState = update.set(newState, 'countries.failed', false);
          break;
      }
      case COUNTRIES_SUCCESS: {
          newState = update.set(state, 'countries.loading', false);
          newState = update.set(newState, 'countries.success', true);
          newState = update.set(newState, 'countries.failed', false);
          newState = update.set(newState,'countries.data',action.payload);
          break;
      }
      case COUNTRIES_FAILED: {
        newState = update.set(state, 'countries.loading', false);
        newState = update.set(newState, 'countries.success', false);
        newState = update.set(newState, 'countries.failed', true);
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
      case COMFORTS_SUCCESS: {
          newState = update.set(newState, 'comforts', action.payload);
          break;
      }
      case CLEAR_SUCCESS: {
          console.log("clear");
          newState = update.set(state, 'ticketStat.loading', false);
          newState = update.set(newState, 'ticketStat.success', false);
          newState = update.set(newState, 'ticketStat.failed', false);
          newState = update.set(newState, 'ticketStat.errors', {});
          break;
      }

      default: {
          return newState;
      }
  }
  return newState;
}
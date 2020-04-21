import CountryControlService from './CountryControlService';
import update from '../../../helpers/update';

export const GET_COUNTRY_STARTED = "GET_COUNTRY_STARTED";
export const GET_COUNTRY_SUCCESS = "GET_COUNTRY_SUCCESS";
export const GET_COUNTRY_FAILED = "GET_COUNTRY_FAILED";

export const CREATE_COUNTRY_STARTED = "CREATE_COUNTRY_STARTED";
export const CREATE_COUNTRY_SUCCESS = "CREATE_COUNTRY_SUCCESS";
export const CREATE_COUNTRY_FAILED = "CREATE_COUNTRY_FAILED";

export const CHANGE_COUNTRY_STARTED = "CHANGE_COUNTRY_STARTED";
export const CHANGE_COUNTRY_SUCCESS = "CHANGE_COUNTRY_SUCCESS";
export const CHANGE_COUNTRY_FAILED = "CHANGE_COUNTRY_FAILED";

export const DELETE_COUNTRY_STARTED = "DELETE_COUNTRY_STARTED";
export const DELETE_COUNTRY_SUCCESS = "DELETE_COUNTRY_SUCCESS";
export const DELETE_COUNTRY_FAILED = "DELETE_COUNTRY_FAILED";

export const CLEAR_SUCCESS = "CLEAR_SUCCESS";

const initialState = {
    countries: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },   
    createCountry: {
        error: {},
        loading: false,
        success: false,
        failed: false,
    },  
    changeCountry: {
        error: {},
        loading: false,
        success: false,
        failed: false,
    },  
    deleteCountry: {
        error: {},
        loading: false,
        success: false,
        failed: false,
    },  
}


//----------------------------FUNCTIONS-------------------------------

export const getCountries = () => {
    return (dispatch) => {
        dispatch(getCountriesListActions.started()); // Set started action
        CountryControlService.getAllCountry() // Get data from service
            .then((response) => {       
                dispatch(getCountriesListActions.success(response)); // Set success action
            }, err => { throw err; })
            .catch(err => {
                console.log(`GetCountries error`,err);
                dispatch(getCountriesListActions.failed(err.response));
            });
            
    }
}

export const createCountry = (country) => {
    return (dispatch) => {
        dispatch(createCountryListActions.started()); // Set started action
        CountryControlService.createCountry(country) // Get data from service
            .then((response) => {       
                dispatch(createCountryListActions.success(response)); // Set success action
            }, err => { throw err; })
            .catch(err => {
                console.log(`Create country error`,err);
                dispatch(createCountryListActions.failed(err.response));
            });
            
    }
}

export const changeCountry = (country) => {
    return (dispatch) => {
        dispatch(changeCountryListActions.started()); // Set started action
        CountryControlService.changeCountry(country) // Get data from service
            .then((response) => {       
                dispatch(changeCountryListActions.success(response)); // Set success action
            }, err => { throw err; })
            .catch(err => {
                console.log(`Change country error`,err);
                dispatch(changeCountryListActions.failed(err.response));
            });
            
    }
}

export const deleteCountry = (country) => {
    return (dispatch) => {
        dispatch(deleteCountryListActions.started()); // Set started action
        CountryControlService.deleteCountry(country) // Get data from service
            .then((response) => {       
                dispatch(deleteCountryListActions.success(response)); // Set success action
            }, err => { throw err; })
            .catch(err => {
                console.log(`Delete country error`,err);
                dispatch(deleteCountryListActions.failed(err.response));
            });
            
    }
}


export const clearState = () => {
    return (dispatch) => {
       dispatch(clearListActions.success());
    }
}


//----------------------------LIST ACTION-------------------------------


export const getCountriesListActions = {
    started: () => {
        return {
            type: GET_COUNTRY_STARTED
        }
    },
    success: (data) => {
        return {
            type: GET_COUNTRY_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: GET_COUNTRY_FAILED,
            error: error,
        }
    }
}

export const createCountryListActions = {
    started: () => {
        return {
            type: CREATE_COUNTRY_STARTED
        }
    },
    success: (data) => {
        return {
            type: CREATE_COUNTRY_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: CREATE_COUNTRY_FAILED,
            error: error,
        }
    }
}

export const changeCountryListActions = {
    started: () => {
        return {
            type: CHANGE_COUNTRY_STARTED
        }
    },
    success: (data) => {
        return {
            type: CHANGE_COUNTRY_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: CHANGE_COUNTRY_FAILED,
            error: error,
        }
    }
}

export const deleteCountryListActions = {
    started: () => {
        return {
            type: DELETE_COUNTRY_STARTED
        }
    },
    success: (data) => {
        return {
            type: DELETE_COUNTRY_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        return {
            type: DELETE_COUNTRY_FAILED,
            error: error,
        }
    }
}


export const clearListActions = {
    success: () => {
        return {
            type: CLEAR_SUCCESS,
        }
    }
}



//----------------------------REDUCER-------------------------------


export const homePageReducer = (state = initialState, action) => { 
  let newState = state;
  switch (action.type) {
      case GET_COUNTRY_STARTED: {
          newState = update.set(state, 'countries.loading', true);
          newState = update.set(newState, 'countries.success', false);
          newState = update.set(newState, 'countries.failed', false);
          break;
      }
      case GET_COUNTRY_SUCCESS: {
          newState = update.set(state, 'countries.loading', false);
          newState = update.set(newState, 'countries.failed', false);
          newState = update.set(newState, 'countries.success', true);
          newState = update.set(newState, 'countries.data', action.payload);
          break;
      }
      case GET_COUNTRY_FAILED: {
          newState = update.set(state, 'countries.loading', false);
          newState = update.set(newState, 'countries.success', false);
          newState = update.set(newState, 'countries.failed', true);
          break;
      }


      case CREATE_COUNTRY_STARTED: {
          newState = update.set(state, 'createCountry.loading', true);
          newState = update.set(newState, 'createCountry.success', false);
          newState = update.set(newState, 'createCountry.failed', false);
          break;
      }
      case CREATE_COUNTRY_SUCCESS: {
          newState = update.set(state, 'createCountry.loading', false);
          newState = update.set(newState, 'createCountry.failed', false);
          newState = update.set(newState, 'createCountry.success', true);
          break;
      }
      case CREATE_COUNTRY_FAILED: {
          newState = update.set(state, 'createCountry.loading', false);
          newState = update.set(newState, 'createCountry.success', false);
          newState = update.set(newState, 'createCountry.failed', true);
          newState = update.set(newState, 'createCountry.error',action.error);
          break;
      }


      case CHANGE_COUNTRY_STARTED: {
          newState = update.set(state, 'changeCountry.loading', true);
          newState = update.set(newState, 'changeCountry.success', false);
          newState = update.set(newState, 'changeCountry.failed', false);
          break;
      }
      case CHANGE_COUNTRY_SUCCESS: {
          newState = update.set(state, 'changeCountry.loading', false);
          newState = update.set(newState, 'changeCountry.failed', false);
          newState = update.set(newState, 'changeCountry.success', true);
          break;
      }
      case CHANGE_COUNTRY_FAILED: {
          newState = update.set(state, 'changeCountry.loading', false);
          newState = update.set(newState, 'changeCountry.success', false);
          newState = update.set(newState, 'changeCountry.failed', true);
          newState = update.set(newState, 'changeCountry.error',action.error);
          break;
      }


      case DELETE_COUNTRY_STARTED: {
          newState = update.set(state, 'deleteCountry.loading', true);
          newState = update.set(newState, 'deleteCountry.success', false);
          newState = update.set(newState, 'deleteCountry.failed', false);
          break;
      }
      case DELETE_COUNTRY_SUCCESS: {
          newState = update.set(state, 'deleteCountry.loading', false);
          newState = update.set(newState, 'deleteCountry.failed', false);
          newState = update.set(newState, 'deleteCountry.success', true);
          break;
      }
      case DELETE_COUNTRY_FAILED: {
          newState = update.set(state, 'deleteCountry.loading', false);
          newState = update.set(newState, 'deleteCountry.success', false);
          newState = update.set(newState, 'deleteCountry.failed', true);
          newState = update.set(newState, 'deleteCountry.error',action.error);
          break;
      }
      
      case CLEAR_SUCCESS: {
          newState = update.set(state, 'countries.loading', false);
          newState = update.set(newState, 'countries.success', false);
          newState = update.set(newState, 'countries.failed', false);

          newState = update.set(state, 'createCountry.loading', false);
          newState = update.set(newState, 'createCountry.success', false);
          newState = update.set(newState, 'createCountry.failed', false);

          newState = update.set(state, 'changeCountry.loading', false);
          newState = update.set(newState, 'changeCountry.success', false);
          newState = update.set(newState, 'changeCountry.failed', false);

          newState = update.set(state, 'deleteCountry.loading', false);
          newState = update.set(newState, 'deleteCountry.success', false);
          newState = update.set(newState, 'deleteCountry.failed', false);
          break;
      }

      default: {
          return newState;
      }
  }
  return newState;
}
import HomePageService from './HomePageService';
import update from '../../../helpers/update';

export const INFO_STARTED = "INFO_STARTED";
export const INFO_SUCCESS = "INFO_SUCCESS";
export const INFO_FAILED = "INFO_FAILED";

export const CITY_STARTED = "CITY_STARTED";
export const CITY_SUCCESS = "CITY_SUCCESS";
export const CITY_FAILED = "CITY_FAILED";

export const HOTEL_STARTED = "HOTEL_STARTED";
export const HOTEL_SUCCESS = "HOTEL_SUCCESS";
export const HOTEL_FAILED = "HOTEL_FAILED";

export const CLEAR_SUCCESS = "CLEAR_SUCCESS";

const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },   
    cities: [],
    hotels: [],

    randomPhotos:[],
    topHotels:[],
    hotTickets:[]
}

// 
export const getHomeData = () => {
    return (dispatch) => {
        dispatch(getHomeListActions.started()); // Set started action
        HomePageService.GetHomeInfo() // Get data from service
            .then((response) => {       
                dispatch(getHomeListActions.success(response)); // Set success action
            }, err=> { throw err; })
            .catch(err=> {
                console.log(`Error - ${err}`);
              dispatch(getHomeListActions.failed(err));
            });
            
    }
}

export const getCityData = (countryId) =>{
    return (dispatch) => {
        HomePageService.GetCities(countryId)     
            .then((response) => {            
                dispatch(getCityListActions.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
                console.log('GetCityData error - ' + err);
              //dispatch(getCityListActions.failed(err));
            });
            
    }
}

export const getHotelData = (cityId) =>{
    return (dispatch) => {
        HomePageService.GetHotels(cityId)     
            .then((response) => {                        
                dispatch(getHotelListActions.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
                console.log('GetHotelsData error - ' + err);
              //dispatch(getCityListActions.failed(err));
            });
            
    }
}

export const clearData = () => {
    return (dispatch) => {
       dispatch(clearListActions.success());
    }
}


export const getHomeListActions = {
    started: () => {
        return {
            type: INFO_STARTED
        }
    },  
    success: (data) => {
        return {
            type: INFO_SUCCESS,
            payload: data.data
        }
    },  
    failed: (error) => {
        return {           
            type: INFO_FAILED,
            error: error,
        }
    }
  }

export const getCityListActions = {
    // started: () => {
    //     return {
    //         type: CITY_STARTED
    //     }
    // },
    success: (data) => {
        return {
            type: CITY_SUCCESS,
            payload: data.data
        }
    },
    // failed: (error) => {
    //     return {
    //         type: CITY_FAILED,
    //         error:error
    //     }
    // },,
}

export const getHotelListActions = {
    success: (data) => {       
        return {
            type: HOTEL_SUCCESS,
            payload: data.data
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


export const homePageReducer = (state = initialState, action) => { 
  let newState = state;
  switch (action.type) {
      case INFO_STARTED: {
          newState = update.set(state, 'list.loading', true);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', false);
          break;
      }
      case INFO_SUCCESS: {
          console.log(action.payload);
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.failed', false);
          newState = update.set(newState, 'list.success', true);
          newState = update.set(newState, 'list.data', action.payload.countries);  
          newState = update.set(newState, 'randomPhotos', action.payload.random3Photos);  
          newState = update.set(newState, 'topHotels', action.payload.topHotels);  
          newState = update.set(newState, 'hotTickets', action.payload.hotTickets);  
          break;
      }
      case INFO_FAILED: {
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', true);
          break;
      }

      case CITY_SUCCESS: {         
            newState = update.set(newState, 'cities', action.payload);            
          break;
      }

      case HOTEL_SUCCESS: {
          newState = update.set(newState, 'hotels', action.payload);
          break;
      }

      case CLEAR_SUCCESS: {
        //   newState = update.set(newState, 'list.data', []);
          newState = update.set(newState, 'cities', []);
          newState = update.set(newState, 'hotels', []);
          break;
      }

      default: {
          return newState;
      }
  }
  return newState;
}
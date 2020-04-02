import HomePageService from './HomePageService';
import update from '../../../helpers/update';

export const INFO_STARTED = "INFO_STARTED";
export const INFO_SUCCESS = "INFO_SUCCESS";
export const INFO_FAILED = "INFO_FAILED";

// export const CITY_STARTED = "CITY_STARTED";
// export const CITY_SUCCESS = "CITY_SUCCESS";
// export const CITY_FAILED = "CITY_FAILED";

// export const INFO_STARTED = "INFO_STARTED";
// export const INFO_SUCCESS = "INFO_SUCCESS";
// export const INFO_FAILED = "INFO_FAILED";

const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },   
    cities: [],
    hotels: []

}

export const getHomeData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        HomePageService.GetHomeInfo()
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
            type: INFO_STARTED
        }
    },  
    success: (data) => {
        return {
            type: INFO_SUCCESS,
            payload: data
        }
    },  
    failed: (error) => {
        return {           
            type: INFO_FAILED,
            error: error,
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
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.failed', false);
          newState = update.set(newState, 'list.success', true);
          newState = update.set(newState, 'list.data', action.payload);         
          break;
      }
      case INFO_FAILED: {
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
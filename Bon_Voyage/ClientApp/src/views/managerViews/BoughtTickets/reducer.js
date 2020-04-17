import BoughtTicketsService from './BoughtTicketsService';
import update from '../../../helpers/update';
export const BOUGHT_TICKETS_STARTED = "BOUGHT_TICKETS_STARTED";
export const BOUGHT_TICKETS_SUCCESS = "BOUGHT_TICKETS_SUCCESS";
export const BOUGHT_TICKETS_FAILED = "BOUGHT_TICKETS_FAILED";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },   
}

export const getBoughtTicketsData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        BoughtTicketsService.getBoughtTickets()
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
            type: BOUGHT_TICKETS_STARTED
        }
    },  
    success: (data) => {
        return {
            type: BOUGHT_TICKETS_SUCCESS,
            payload: data.data
        }
    },  
    failed: (error) => {
        return {           
            type: BOUGHT_TICKETS_FAILED,
            error: error,
        }
    }
  }

export const boughtTicketsReducer = (state = initialState, action) => { 
  let newState = state;

  switch (action.type) {

      case BOUGHT_TICKETS_STARTED: {
          newState = update.set(state, 'list.loading', true);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', false);
          break;
      }
      case BOUGHT_TICKETS_SUCCESS: {
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.failed', false);
          newState = update.set(newState, 'list.success', true);
          newState = update.set(newState, 'list.data', action.payload);         
          break;
      }
      case BOUGHT_TICKETS_FAILED: {
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
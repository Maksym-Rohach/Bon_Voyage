import PersonsChartService from './PersonsChartService';
import update from '../../../helpers/update';
export const PERSONS_STARTED = "PERSONS_STARTED";
export const PERSONS_SUCCESS = "PERSONS_SUCCESS";
export const PERSONS_FAILED = "PERSONS_FAILED";


const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },   
}

export const getPersonsData = (model) => {
    return (dispatch) => {
        dispatch(getListActions.started());
        PersonsChartService.getPersons(model)
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
            type: PERSONS_STARTED
        }
    },  
    success: (data) => {
        return {
            type: PERSONS_SUCCESS,
            payload: data
        }
    },  
    failed: (error) => {
        return {           
            type: PERSONS_FAILED,
            errors: error
        }
    }
  }

export const personsChartReducer = (state = initialState, action) => { 
  let newState = state;

  switch (action.type) {

      case PERSONS_STARTED: {
          newState = update.set(state, 'list.loading', true);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', false);
          break;
      }
      case PERSONS_SUCCESS: {
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.failed', false);
          newState = update.set(newState, 'list.success', true);
          newState = update.set(newState, 'list.data', action.payload);         
          break;
      }
      case PERSONS_FAILED: {
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
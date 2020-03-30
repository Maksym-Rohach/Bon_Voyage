import HomePageService from './HomePageService';
import update from '../../../helpers/update';

export const INFO_STARTED = "INFO_STARTED";
export const INFO_SUCCESS = "INFO_SUCCESS";
export const INFO_FAILED = "INFO_FAILED";



const initialState = {
    list: {
        data: [],
        loading: false,
        success: false,
        failed: false,
    },   
}

export const getCommentsData = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        CommentsChartService.getComments()
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
            type: COMMENTS_STARTED
        }
    },  
    success: (data) => {
        return {
            type: COMMENTS_SUCCESS,
            payload: data
        }
    },  
    failed: (error) => {
        return {           
            type: COMMENTS_FAILED,
            error: error,
        }
    }
  }

export const commentsChartReducer = (state = initialState, action) => { 
  let newState = state;

  switch (action.type) {

      case COMMENTS_STARTED: {
          newState = update.set(state, 'list.loading', true);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', false);
          break;
      }
      case COMMENTS_SUCCESS: {
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.failed', false);
          newState = update.set(newState, 'list.success', true);
          newState = update.set(newState, 'list.data', action.payload);         
          break;
      }
      case COMMENTS_FAILED: {
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
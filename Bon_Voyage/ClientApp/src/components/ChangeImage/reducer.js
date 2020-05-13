import ChangeImageService from './ChangeImageService';
import update from '../../helpers/update';
export const IMAGE_STARTED = "IMAGE_STARTED";
export const IMAGE_SUCCESS = "IMAGE_SUCCESS";
export const IMAGE_FAILED = "IMAGE_FAILED";


const initialState = {
    list: {
        image: '',
        loading: false,
        success: false,
        failed: false,
    },   
}

export const getImage = () => {
    return (dispatch) => {
        dispatch(getListActions.started());
        ChangeImageService.getImage()
            .then((response) => {
                dispatch(getListActions.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
              dispatch(getListActions.failed(err.response));
            });
    }
}

export const changeImage = (model) => {
    return (dispatch) => {
        dispatch(getListActions.started());
        ChangeImageService.changeImage(model)
            .then((response) => {
                dispatch(getListActions.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
              dispatch(getListActions.failed(err.response));
            });
    }
}

export const getListActions = {
    started: () => {
        return {
            type: IMAGE_STARTED
        }
    },  
    success: (data) => {
        return {
            type: IMAGE_SUCCESS,
            payload: data.data
        }
    },  
    failed: (error) => {
        return {           
            type: IMAGE_FAILED,
            errors: error.data
        }
    }
  }

export const changeImageReducer = (state = initialState, action) => { 
  let newState = state;

  switch (action.type) {

      case IMAGE_STARTED: {
          newState = update.set(state, 'list.loading', true);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', false);
          break;
      }
      case IMAGE_SUCCESS: {
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.failed', false);
          newState = update.set(newState, 'list.success', true);
          newState = update.set(newState, 'list.image', action.payload);         
          break;
      }
      case IMAGE_FAILED: {
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', true);
          newState = update.set(newState, "list.errors", action.errors);
          break;
      }
      default: {
          return newState;
      }
  }
  return newState;
}
import GalleryPageService from './GalleryPageService';
import update from '../../../helpers/update';

export const PHOTOS_STARTED = "PHOTOS_STARTED";
export const PHOTOS_SUCCESS = "PHOTOS_SUCCESS";
export const PHOTOS_FAILED = "PHOTOS_FAILED";

const initialState = {
   photos:{
       data:[],
       loading: false,
       success: false,
       failed: false,
   }
}

// 
export const getGalleryPhotos = () =>{
    return (dispatch) => {
        GalleryPageService.GetPhotos()     
            .then((response) => {            
                dispatch(GalleryListAction.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
                console.log('GetGalleryPhotos error - ' + err);
            //   dispatch(getCityListActions.failed(err));
            });
            
    }
}

export const GalleryListAction = {
    started: () => {
        return {
            type: PHOTOS_STARTED
        }
    },  
    success: (data) => {
        console.log("data",data)
        return {
            type: PHOTOS_SUCCESS,
            payload: data.data
        }
    },  
    failed: (error) => {
        return {           
            type: PHOTOS_FAILED,
            error: error,
        }
    }
  }


export const GalleryReducer = (state = initialState, action) => { 
  let newState = state;
  switch (action.type) {
      case PHOTOS_STARTED: {
          newState = update.set(state, 'photos.loading', true);
          newState = update.set(newState, 'photos.success', false);
          newState = update.set(newState, 'photos.failed', false);
          break;
      }
      case PHOTOS_SUCCESS: {
          newState = update.set(state, 'photos.loading', false);
          newState = update.set(newState, 'photos.success', true);
          newState = update.set(newState, 'photos.failed', false);
          newState = update.set(newState, 'photos.data', action.payload);
          break;
      }
      case PHOTOS_FAILED: {
          newState = update.set(state, 'photos.loading', false);
          newState = update.set(newState, 'photos.success', false);
          newState = update.set(newState, 'photos.failed', true);
          break;
      }
      default: {
          return newState;
      }
  }
  return newState;
}
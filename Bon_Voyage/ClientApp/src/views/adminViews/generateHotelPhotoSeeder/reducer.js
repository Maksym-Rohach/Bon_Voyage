import GenerateHotelPhotoService from './generateHotelPhotosService';
import update from '../../../helpers/update';

export const SEND_SUCCESS = "SEND_SUCCESS";


const initialState = {
   success:false,
}


//----------------------------FUNCTIONS-------------------------------

export const sendPhotos = (photos) => {
    return (dispatch) => {
        GenerateHotelPhotoService.SendNudes(photos) // Get data from service
            .then((response) => {       
                dispatch(sendListActions.success()); // Set success action
            }, err => { throw err; })
            .catch(err => {
                console.log(`Send photos error`,err.response);
            });
    }
}


export const sendListActions = {
    success: (data) => {
        return {
            type: SEND_SUCCESS,
        }
    },
}


//----------------------------REDUCER-------------------------------


export const countryControlReducer = (state = initialState, action) => { 
  let newState = state;
  switch (action.type) {   
      case SEND_SUCCESS: {
          newState = update.set(newState, 'success', true);
          break;
      }

      default: {
          return newState;
      }
  }
  return newState;
}
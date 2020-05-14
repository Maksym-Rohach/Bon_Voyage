import DetailsPageService from '../DetailsPage/DetailsService';
import update from '../../../helpers/update';

export const HOTEL_STARTED = "HOTEL_STARTED";
export const HOTEL_SUCCESS = "HOTEL_SUCCESS";
export const HOTEL_FAILED = "HOTEL_FAILED";



const initialState = {
    list: {
        data: {},
        loading: false,
        success: false,
        failed: false,
    },   
}



export const GetHotelInfo = (HotelId) =>{
    return (dispatch) => {
        DetailsPageService.GetHotelInfo(HotelId)     
            .then((response) => {      
                console.log("responce",response)                  
                dispatch(getHotelListActions.success(response));               
            }, err=> { throw err; })
            .catch(err=> {
                console.log('GetHotelsInfo  error - ' + err);          
            });
            
    }
}



export const getHotelListActions = {
    success: (data) => {   
        console.log("Prprp",data.data)    
        return {
            type: HOTEL_SUCCESS,
            payload: data.data
        }
    }
}



export const detailsPageReducer = (state = initialState, action) => { 
  let newState = state;
  switch (action.type) {
      case HOTEL_STARTED: {
          newState = update.set(state, 'list.loading', true);
          newState = update.set(newState, 'list.success', false);
          newState = update.set(newState, 'list.failed', false);
          break;
      }
      case HOTEL_SUCCESS: {
          console.log(action.payload);
          newState = update.set(state, 'list.loading', false);
          newState = update.set(newState, 'list.failed', false);
          newState = update.set(newState, 'list.success', true);
          newState = update.set(newState, 'list.data', action.payload);         
          break;
      }           
      default: {
          return newState;
      }
  }
  return newState;
}
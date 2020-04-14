import ChangeInfoService from './ChangeInfoService';
import update from '../../helpers/update';

export const INFO_STARTED = "INFO_STARTED";
export const INFO_SUCCESS = "INFO_SUCCESS";
export const INFO_FAILED = "INFO_FAILED";

export const GET_INFO_STARTED = "GET_INFO_STARTED";
export const GET_INFO_SUCCESS = "GET_INFO_SUCCESS";
export const GET_INFO_FAILED = "GET_INFO_FAILED";


const initialState = {
    infoList:{
        errors: {},
        data: {},
        loading: false,
        success: false,
        failed: false,
    },
    list: {
        errors: {},
        loading: false,
        success: false,
        failed: false,
    },
}



export const getInfo = () => { // Викликаємо метод, який стукається на сервак
    return (dispatch) => {
        dispatch(getInfoListActions.started()); // Почав загружати данн
        ChangeInfoService.getInfo() // Стукаємося до сервака
            .then((response) => { // Якщо приходить OK
                dispatch(getInfoListActions.success(response)); // Ставимо статус Success, говоримо що данні прийшли успішно
            }, err => { throw err; })
            .catch(err => { // Якщо приходить ошибка
                dispatch(getInfoListActions.failed(err.response)); // Якщо приходить BadRequest і стукаємося в редюсер (changeInfoReducer)
            });
    }
}

export const changeInfo = (model) => {
    return (dispatch) => {
        dispatch(getListActions.started());
        ChangeInfoService.changeInfo(model)
            .then((response) => {
                console.log("Response",response);
                dispatch(getListActions.success());
            }, err => { throw err; })
            .catch(err => {
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
    success: () => {
        return {
            type: INFO_SUCCESS,
            // payload: data.data
        }
    },
    failed: (error) => {
        console.log("Change info",error);
        return {
            type: INFO_FAILED,
            errors: error
        }
    }
}

export const getInfoListActions = {
    started: () => {
        return {
            type: GET_INFO_STARTED
        }
    },
    success: (data) => {
        return {
            type: GET_INFO_SUCCESS,
            payload: data.data
        }
    },
    failed: (error) => {
        console.log("Get_Info error",error);
        return {
            type: GET_INFO_FAILED,
            errors: error
        }
    }
}



export const changeInfoReducer = (state = initialState, action) => {
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
            break;
        }
        case INFO_FAILED: {
            newState = update.set(state, 'list.loading', false);
            newState = update.set(newState, 'list.success', false);
            newState = update.set(newState, 'list.failed', true);
            newState = update.set(newState, "list.errors", action.errors);
            break;
        }

        case GET_INFO_STARTED: {
            newState = update.set(state, 'infoList.loading', true);
            newState = update.set(newState, 'infoList.success', false);
            newState = update.set(newState, 'infoList.failed', false);
            break;
        }
        case GET_INFO_SUCCESS: {
            newState = update.set(state, 'infoList.loading', false);
            newState = update.set(newState, 'infoList.failed', false);
            newState = update.set(newState, 'infoList.success', true);
            newState = update.set(newState, 'infoList.data', action.payload);
            break;
        }
        case GET_INFO_FAILED: {
            newState = update.set(state, 'infoList.loading', false);
            newState = update.set(newState, 'infoList.success', false);
            newState = update.set(newState, 'infoList.failed', true);
            newState = update.set(newState, "infoList.errors", action.errors);
            break;
        }

        default: {
            return newState;
        }
    }
    return newState;
}

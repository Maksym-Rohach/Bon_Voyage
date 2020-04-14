import axios from "axios";
import {serverUrl} from '../../config';

export default class ChangePasswordService {
    static changePassword(model) {    
        return axios.post(`${serverUrl}api/change/change-password`, model)
    };
}
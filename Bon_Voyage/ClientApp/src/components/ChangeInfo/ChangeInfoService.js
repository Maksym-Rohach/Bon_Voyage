import axios from "axios";
import {serverUrl} from '../../config';

export default class ChangeInfoService {
    static getInfo() {       
        return axios.get(`${serverUrl}api/change/get-info`)
    };
    static changeInfo(model) {      
        return axios.post(`${serverUrl}api/change/change-info`, model)
    };
}
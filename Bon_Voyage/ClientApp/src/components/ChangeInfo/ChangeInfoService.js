import axios from "axios";
import {serverUrl} from '../../config';

export default class ChangeInfoService {
    static getInfo() {       
        return axios.get(`${serverUrl}api/change/get-info`)
    };
    static changeInfo(model) { 
        console.log("Service post model",model);      
        return axios.post(`${serverUrl}api/change/change-info`, model)
    };
}
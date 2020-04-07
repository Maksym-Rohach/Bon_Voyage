import axios from "axios";
import {serverUrl} from '../../config';

export default class ChangeImageService {
    static getImage() {       
        return axios.get(`${serverUrl}api/change/get-image`)
    };
    static changeImage(model) { 
        console.log("BASE 64", model);      
        return axios.post(`${serverUrl}api/change/change-image`, model)
    };
}
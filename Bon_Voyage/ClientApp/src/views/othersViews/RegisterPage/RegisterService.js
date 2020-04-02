import axios from "axios";
import {serverUrl} from '../../../config';

export default class RegisterService {
    static register(model) {
        console.log("service");
        return axios.post(`${serverUrl}api/registration/register`, model)
    };
}
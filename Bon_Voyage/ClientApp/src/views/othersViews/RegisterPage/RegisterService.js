import axios from "axios";
import {serverUrl} from '../../../config';

export default class RegistrationService {
    static registration(model) {
        return axios.post(`${serverUrl}api/auth/registration`, model)
    };
}
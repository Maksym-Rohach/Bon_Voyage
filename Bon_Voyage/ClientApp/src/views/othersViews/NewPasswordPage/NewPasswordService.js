import axios from "axios";
import {serverUrl} from '../../../config';

export default class NewPasswordService {
    static newPassword(model) {
        return axios.post(`${serverUrl}api/change/change-password`, model)
    };
}
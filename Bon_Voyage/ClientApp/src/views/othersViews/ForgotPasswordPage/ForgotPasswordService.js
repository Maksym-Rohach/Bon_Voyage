import axios from "axios";
import {serverUrl} from '../../../config';

export default class ForgotPasswordService {
    static forgotPassword(model) {
        return axios.post(`${serverUrl}api/auth/forgot-password`, model)
    };
}
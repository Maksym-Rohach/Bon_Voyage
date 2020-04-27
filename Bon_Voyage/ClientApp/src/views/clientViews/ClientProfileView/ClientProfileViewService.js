import axios from "axios";
import { serverUrl } from '../../../config';

export default class ClientProfileViewService {
    static updateClientProfile(model) {
        return axios.post(`${serverUrl}api/clientprofile/update`, model)
    };
    static getClientProfile() {
        return axios.get(`${serverUrl}api/Clientprofile/getClientProfile`)
    };
}
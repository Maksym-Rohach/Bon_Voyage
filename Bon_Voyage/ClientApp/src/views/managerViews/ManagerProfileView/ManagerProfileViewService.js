import axios from "axios";
import { serverUrl } from '../../../config';

export default class ManagerProfileViewService {
    static updateManagerProfile(model) {
        return axios.post(`${serverUrl}api/managerprofile/update`, model)
    };
    static getManagerProfile() {
        return axios.get(`${serverUrl}api/managerprofile/getManagerProfile`)
    };
}
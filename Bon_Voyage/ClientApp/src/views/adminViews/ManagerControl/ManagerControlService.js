import axios from "axios";
import {serverUrl} from '../../../config';

export default class ManagerControlService {
    static addManager(model) {
        return axios.post(`${serverUrl}api/managercontrol/add`, model)
    };
    static deleteManager(model) {
        return axios.post(`${serverUrl}api/managercontrol/delete`, model)
    };
    static updateManager(model) {
        return axios.post(`${serverUrl}api/managercontrol/update`, model)
    };
    static getAllManagers() {
        return axios.get(`${serverUrl}api/admin/getAllManagers`)
    };
}
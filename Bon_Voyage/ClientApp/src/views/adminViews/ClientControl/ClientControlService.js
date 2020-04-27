import axios from "axios";
import {serverUrl} from '../../../config';

export default class ClientControlService {
    static getAllClients() {
        return axios.get(`${serverUrl}api/admin/getAllClients`)
    };
}
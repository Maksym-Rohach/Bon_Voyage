import axios from "axios";
import { serverUrl } from '../../../config';

export default class ClientMapViewService {
    static updateClientMap(model) {
        return axios.post(`${serverUrl}api/clientmap/update`, model)
    };
}
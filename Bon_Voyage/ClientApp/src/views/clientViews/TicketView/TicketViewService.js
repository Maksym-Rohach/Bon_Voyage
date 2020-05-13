import axios from "axios";
import { serverUrl } from '../../../config';

export default class ClientProfileViewService {
    static getTicektsWithFilters(indx,filters) {
        return axios.post(`${serverUrl}api/`, {indx,filters});
    };
}
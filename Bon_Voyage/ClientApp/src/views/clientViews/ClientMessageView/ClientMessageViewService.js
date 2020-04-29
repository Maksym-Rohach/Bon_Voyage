import axios from "axios";
import { serverUrl } from '../../../config';

export default class ClientMessageViewService {
    static updateClientMessage(model) {
        return axios.post(`${serverUrl}api/clientmessage/update`, model)
    };
}
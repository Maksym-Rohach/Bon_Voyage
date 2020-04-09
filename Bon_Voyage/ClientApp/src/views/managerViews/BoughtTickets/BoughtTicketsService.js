import axios from "axios";
import {serverUrl} from '../../../config';

export default class ManagerControlService {
    static getBoughtTickets() {
        return axios.get(`${serverUrl}/api/TicketControl/getBoughtsTickets`)
    };
}
import axios from "axios";
import { serverUrl } from '../../../config';

export default class ManagerControlService {
    static getHotDealTickets() {
        return axios.get(`${serverUrl}/api/TicketControl/getHotDealTickets`)
    };
    static updateTicketDiscount(model) {
        console.log('123');
        return axios.post(`${serverUrl}/api/TicketControl/updateTicketDiscount`, model)
    };
}
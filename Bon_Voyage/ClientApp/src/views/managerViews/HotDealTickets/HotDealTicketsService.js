import axios from "axios";
import { serverUrl } from '../../../config';

export default class ManagerControlService {
    static getHotDealTickets() {
        return axios.get(`${serverUrl}/api/TicketControl/getHotDealTickets`)
    };
    //static updateTickets() {
    //    return axios.get(`${serverUrl}/api/TicketControl/updateTickets`)
    //};
}
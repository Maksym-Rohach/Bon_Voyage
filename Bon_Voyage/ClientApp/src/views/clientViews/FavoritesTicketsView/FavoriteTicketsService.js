import axios from "axios";
import { serverUrl } from '../../../config';

export default class FavoriteTicketsService {
    static GetTickets() {
        return axios.get(`${serverUrl}api/Client/GetCardsTickets`);
    }
    static BuyTicket(model) {
        return axios.post(`${serverUrl}api/Ticket/BuyTicket`, model);
    }
}
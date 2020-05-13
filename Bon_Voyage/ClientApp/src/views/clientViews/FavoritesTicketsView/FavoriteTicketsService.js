import axios from "axios";
import { serverUrl } from '../../../config';

export default class FavoriteTicketsService {
    static GetTickets() {
        return axios.get(`${serverUrl}api/Client/GetCardsTickets`);
    }
}
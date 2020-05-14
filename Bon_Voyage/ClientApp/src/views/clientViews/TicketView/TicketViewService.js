import axios from "axios";
import { serverUrl } from '../../../config';

export default class ClientProfileViewService {
    static getTicketsWithFiltres(indx,filters) {
        return axios.post(`${serverUrl}api/TicketFiltring/GetFiltredTickets`, {indx,filters});
    };
    static getFiltersData(){
        return axios.get(`${serverUrl}api/TicketFiltring/GetDataForFilter`);
    }
    static getHotelsData(countryId){
        return axios.get(`${serverUrl}api/Hotel/GetHotelByCountry/${countryId}`);
    }
}
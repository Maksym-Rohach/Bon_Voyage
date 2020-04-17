import axios from "axios";
import { serverUrl } from '../../../config';

export default class AddTicketService {
    static GetCountries() {
        return axios.get(`${serverUrl}api/Country/GetAllCountry`);
    }

    static GetCities(countryId) {
        return axios.get(`${serverUrl}api/City/GetCitiesByCountry/${countryId}`);
    }

    static GetAirports(countryId) {
        return axios.get(`${serverUrl}api/Airport/GetAirportsByCountry/${countryId}`);
    }

    static GetHotels(cityId) {
        return axios.get(`${serverUrl}api/Hotel/GetHotelByCity/${cityId}`);
    }

    static GetRoomTypes() {
        return axios.get(`${serverUrl}api/RoomType/GetAllRoomTypes`);
    }
    static GetComforts() {
        return axios.get(`${serverUrl}api/Comfort/GetAllComforts`);
    }

    static CreateTicket(ticket) {
        return axios.post(`${serverUrl}api/TicketControl/CreateTicket`, ticket);
    }
}
import axios from "axios";
import { serverUrl } from '../../../config';

export default class AirportControlService {
    static getAllCountry() {
        return axios.get(`${serverUrl}/api/Country/GetAllCountryWithCityCount`)
    }

    static createCountry(country) {
        return axios.post(`${serverUrl}/api/CountryControl/CreateCountry`, country);
    }

    static changeCountry(country) {
        return axios.post(`${serverUrl}/api/CountryControl/ChangeCountry`, country);
    }
    static deleteCountry(country) {
        return axios.post(`${serverUrl}/api/CountryControl/DeleteCountry`, country);
    }
}
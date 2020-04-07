import axios from "axios";
import {serverUrl} from '../../../config';

export default class HomePageService {
    static GetHomeInfo() {
        return axios.get(`${serverUrl}api/HomePage/GetHomeInformation`)
    };

    static GetCities(CountryId) {
        return axios.get(`${serverUrl}api/City/GetCitiesByCountry/${CountryId}`)
    };

    static GetHotels(CityId){
        return axios.get(`${serverUrl}api/Hotel/GetHotelByCity/${CityId}`)
    }
}
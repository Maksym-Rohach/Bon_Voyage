import axios from "axios";
import {serverUrl} from '../../../config';

export default class HomePageService {
    static GetHomeInfo() {
        return axios.post(`${serverUrl}api/HomePage/GetHomeInformation`)
    };

    static GetCities(CountryId) {
        return axios.post(`${serverUrl}api/City/GetHomeInformation/${CountryId}`)
    };

    static GetHotels(CityId){
        return axios.post(`${serverUrl}api/Hotel/GetHomeInformation/${CityId}`)
    }
}
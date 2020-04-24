import axios from "axios";
import {serverUrl} from '../../../config';

export default class HotelControlService {
    static addHotel(model) {
        return axios.post(`${serverUrl}api/hotelcontrol/add`, model)
    };
    static updateHotel(model) {
        return axios.post(`${serverUrl}api/hotelcontrol/update`, model)
    };
    static getAllHotels() {
        return axios.get(`${serverUrl}api/admin/getAllHotels`)
    };
}
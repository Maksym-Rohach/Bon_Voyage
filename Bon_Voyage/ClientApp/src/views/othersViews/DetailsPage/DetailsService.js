import axios from "axios";
import {serverUrl} from '../../../config';

export default class DetailsPageService {
    static GetHotelInfo(HotelId) {
        console.log("HotelID",HotelId)
        return axios.get(`${serverUrl}api/Hotel/GetHotelInfo/${HotelId}`)
    };   
}
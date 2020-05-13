import axios from "axios";
import { serverUrl } from '../../../config';

export default class GenerateHotelPhotoService {
    static SendNudes(photos) {
        console.log("Service photos:",photos);
        return axios.post(`${serverUrl}/api/Admin/GenerateHotelPhotoSeeder`,photos)
    }
}
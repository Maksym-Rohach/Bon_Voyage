import axios from "axios";
import {serverUrl} from '../../../config';

export default class GalleryPageService {
    static GetPhotos() {
        return axios.get(`${serverUrl}api/HomePage/GetGalleryPhoto`);
    };
}
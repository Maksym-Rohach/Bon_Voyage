import axios from "axios";
import {serverUrl} from '../../../config';

export default class CityControlService {
   static getAllCities(){    
      console.log('get')
    return axios.get(`${serverUrl}api/CityControl/GetCitiesData`)
   }
}
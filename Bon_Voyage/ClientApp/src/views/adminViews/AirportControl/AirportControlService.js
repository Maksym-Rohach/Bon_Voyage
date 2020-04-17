import axios from "axios";
import {serverUrl} from '../../../config';

export default class AirportControlService {
   static getAllAirports(){    
    return axios.get(`${serverUrl}/api/AirportControl/GetAirportsData`)
   }

   static createAirport(model){
    return axios.post(`${serverUrl}/api/AirportControl/CreateAirport`,model);
   }

   static getCityByCountry(countryId){
      return axios.get(`${serverUrl}/api/City/GetCitiesByCountry/${countryId}`);
   }
}
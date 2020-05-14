import axios from "axios";
import {serverUrl} from '../../../config';

export default class ManagerControlService {
    static getFeedBack() {
        return axios.get(`${serverUrl}api/FeedBack/GetAllFeedbacks`)
    };
    static AnswerFeedBack(model) {
        return axios.post(`${serverUrl}api/FeedBack/AnswerFeedBack`,model)
    };
}   
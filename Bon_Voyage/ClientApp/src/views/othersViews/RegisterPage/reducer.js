import update from "../../../helpers/update";
import RegisterService from "./RegisterService";
import isEmpty from "lodash/isEmpty";
import setAuthorizationToken from "../../../utils/setAuthorizationToken";
import jwt from "jsonwebtoken";
import redirectStatusCode from "../../../services/redirectStatusCode";
import history from "../../../utils/history";
import {push} from "connected-react-router";



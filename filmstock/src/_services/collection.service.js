import axios from 'axios';
import authHeader from './auth.header';

const baseUrl = "https://localhost:7299/";

function addToUserCollection(filterInfo, payload){
    return axios.post(baseUrl + filterInfo, payload, authHeader());
}

function getUserCollections(filterInfo){
    return axios.get(baseUrl + filterInfo, authHeader());
}

const collectionService = {
    addToUserCollection,
    getUserCollections
}

export default collectionService;
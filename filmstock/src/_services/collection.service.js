import axios from 'axios';

const baseUrl = "https://localhost:7299/";

function addToUserCollection(filterInfo, payload){
    return axios.post(
        baseUrl + filterInfo,payload,
        {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem("user")}`
              }
        });
}

function getUserCollections(filterInfo){
    return axios.get(baseUrl + filterInfo,{
        headers: {
            'Authorization': `Bearer ${localStorage.getItem("user")}`
          }
    });
}

const collectionService = {
    addToUserCollection,
    getUserCollections
}

export default collectionService;
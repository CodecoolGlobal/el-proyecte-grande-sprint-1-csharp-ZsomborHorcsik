import axios from "axios";

function postFetch(urlFilter, payload){
    const baseUrl = "https://localhost:7299/";
    return axios.post(baseUrl + urlFilter, payload)
                .then((response)=>{
                    localStorage.setItem("user", JSON.stringify(response.data));
                })

}

export default postFetch;
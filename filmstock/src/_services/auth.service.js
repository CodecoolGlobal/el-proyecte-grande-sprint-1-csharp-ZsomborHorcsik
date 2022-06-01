import axios from "axios";

function postFetch(urlFilter, payload){
    const baseUrl = "https://localhost:7299/";
    return axios.post(baseUrl + urlFilter, payload)
                .then((response)=>{
                    localStorage.setItem("user", JSON.stringify(response.data));
                })
}

const logout = () =>{
    localStorage.removeItem("user");
}

const getCurrentUser = () =>{
    return JSON.parse(localStorage.getItem("user"));
}

const authService = {
    postFetch,
    logout,
    getCurrentUser
}

export default authService;
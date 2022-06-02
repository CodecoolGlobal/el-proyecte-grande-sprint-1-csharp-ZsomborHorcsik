import axios from "axios";

const baseUrl = "https://localhost:7299/";

function postFetch(urlFilter, payload){
    return axios.post(baseUrl + urlFilter, payload)
                .then((response) =>{
                    localStorage.setItem("user", JSON.stringify(response.data));
                })
}

function registerUser(urlFilter, payload) {
    return axios.post(baseUrl + urlFilter, payload)
                .then((response) => {
                    console.log(JSON.stringify(response.data));
                });
  };

const logout = () =>{
    localStorage.removeItem("user");
    window.location.reload();
}

const getCurrentUser = () =>{
    return JSON.parse(localStorage.getItem("user"));
}

const authService = {
    postFetch,
    logout,
    getCurrentUser,
    registerUser
}

export default authService;
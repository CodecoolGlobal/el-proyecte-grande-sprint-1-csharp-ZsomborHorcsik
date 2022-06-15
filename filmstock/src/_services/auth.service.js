import axios from "axios";

const baseUrl = "https://localhost:7299/";

function loginUser(urlFilter, payload){
    return axios.post(baseUrl + urlFilter, payload)
                .then((response) =>{
                    if(response.ok){
                        localStorage.setItem("user", response.data);
                    }
                })
}

function registerUser(urlFilter, payload) {
    return axios.post(baseUrl + urlFilter, payload);
  };

const logout = () =>{
    localStorage.removeItem("user");
    window.location.reload();
}

const getCurrentUser = () =>{
    return JSON.parse(localStorage.getItem("user"));
}

const authService = {
    loginUser,
    logout,
    getCurrentUser,
    registerUser
}

export default authService;
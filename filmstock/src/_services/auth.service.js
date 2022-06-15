import axios from "axios";

const baseUrl = "https://localhost:7299/";

function loginUser(urlFilter, payload){
    return axios.post(baseUrl + urlFilter, payload)
                .then((response) =>{
                        if(response.status === 200){
                            localStorage.setItem("user", response.data);
                        }
                    })
                }               

function registerUser(urlFilter, payload) {
    return axios.post(baseUrl + urlFilter, payload);
  };

const logout = () =>{
    localStorage.removeItem("user");
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
import axios from "axios";
import {login} from '../_slices/userLoginSlice';
import {useDispatch} from 'react-redux';

const baseUrl = "https://localhost:7299/";

function loginUser(urlFilter, payload){
    return axios.post(baseUrl + urlFilter, payload)
                .then((response) =>{
                        localStorage.setItem("user", response.data);
                        useDispatch(login(response.data));
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
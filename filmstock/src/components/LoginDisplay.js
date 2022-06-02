import React from 'react';
import Layout from './layout/Layout';
import './stylesheets/loginSystem.css';
import { useState } from 'react';
import authService from '../_services/auth.service';
import { useNavigate } from 'react-router-dom';
    
const LoginDisplay = () => {
    const navigate = useNavigate();
    const [password, setPassword] = useState("");
    const [username, setUsername] = useState("");

    const handlePassword = (event) =>{
        setPassword(event.target.value);
    }

    const handleUsername = (event) =>{
        setUsername(event.target.value);
    }

    const handleSubmit = async event =>{
        event.preventDefault();
        let payload = {"UserName": username, "Password": password};

        try{
            await authService.postFetch("api/User/login", payload)
                            .then( ()=>{
                                navigate("/");
                            })
        }catch(err){
            console.log(err);
        }
        
    }

  return (
    <div className='App'>
        <Layout>
            <div className='single-content-box'>
                <form onSubmit={handleSubmit} method='POST'>
                    <div className="shadow-md rounded px-8 pt-6 pb-8 mb-4 flex flex-col" id="login-panel">
                        <div className="mb-4">
                            <label className="block text-white text-sm font-bold mb-2" htmlFor="UserName">
                                Username
                            </label>
                            <input className="shadow appearance-none border rounded w-full py-2 px-3 text-grey-darker" 
                            id="userName" 
                            name="userName" 
                            type="text" 
                            placeholder="Username"
                            onChange={handleUsername}
                            required/>
                        </div>
                        <div className="mb-6">
                            <label className="block text-white text-sm font-bold mb-2" htmlFor="Password">
                                Password
                            </label>
                            <input className="shadow appearance-none border border-red rounded w-full py-2 px-3 text-grey-darker mb-3" 
                            id="password" 
                            name="password"
                            type="password" 
                            onChange={handlePassword}
                            placeholder="******************" 
                            required/>
                        </div>
                        <div className="flex items-center justify-between">
                            <button type='submit' className="font-bold outline-none uppercase focus:outline-none focus:shadow-none transition-all duration-300 rounded-md py-3 px-4 text-sm leading-relaxed text-white bg-teal-500 hover:bg-teal-700 focus:bg-teal-400 active:bg-teal-800 shadow-md-blue-gray hover:shadow-lg-blue-gray">
                                Sign in
                            </button>
                        </div>
                    </div>
                </form>
            </div>
        </Layout>
    </div>
  )
}

export default LoginDisplay;
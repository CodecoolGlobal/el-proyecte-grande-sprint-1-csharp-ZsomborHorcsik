import React from 'react';
import Layout from './layout/Layout';
import './stylesheets/loginSystem.css';
import authService from '../_services/auth.service';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const RegisterDisplay = () => {
    let navigate = useNavigate();
    const [firstName, setFirstName] = useState(null);
    const [lastName, setLastName] = useState(null);
    const [email, setMail] = useState(null);
    const [password, setPassword] = useState(null);
    const [username, setUserName] = useState(null);

    const registerHandler = async event =>{
        event.preventDefault();
        let payload = {"userName": username, "password": password, "firstName": firstName, "lastName": lastName, "email": email};
        try{
            await authService.registerUser("api/User/register", payload)
        }
        catch(err){
            console.log(err);
        }
    }

  return (
    <div className='App'>
        <Layout>
            <div className='single-content-box'>
                <form onSubmit={registerHandler} method='POST'>
                    <div className="bg-gray-500 shadow-md rounded px-8 pt-6 pb-8 mb-4 flex flex-col" id="register-panel">
                        <div className="mb-4">
                            <label className="block text-white text-sm font-bold mb-2" htmlFor="firstName">
                                First name
                            </label>
                              <input onChange={(e) => {setFirstName(e.target.value)}} className="shadow appearance-none border rounded w-full py-2 px-3 text-black" id="firstName" name="firstName" type="text" placeholder="First name" required/>
                        </div>
                        <div className="mb-4">
                            <label className="block text-white text-sm font-bold mb-2" htmlFor="lastName">
                                Last name
                            </label>
                              <input onChange={(e) => {setLastName(e.target.value)}} className="shadow appearance-none border rounded w-full py-2 px-3 text-black" id="lastName" name="lastName" type="text" placeholder="Last name" required/>
                        </div>
                        <div className="mb-4">
                            <label className="block text-white text-sm font-bold mb-2" htmlFor="email">
                                E-mail
                            </label>
                            <input onChange={(e) => {setMail(e.target.value)}} className="shadow appearance-none border rounded w-full py-2 px-3 text-black" id="email" name="email" type="text" placeholder="Email" required/>
                        </div>
                        <div className="mb-4">
                            <label className="block text-white text-sm font-bold mb-2" htmlFor="userName">
                                Username
                            </label>
                            <input onChange={(e) => {setUserName(e.target.value)}} className="shadow appearance-none border rounded w-full py-2 px-3 text-grey-darker" id="userName" name="userName" type="text" placeholder="Username" required/>
                        </div>
                        <div className="mb-6">
                            <label className="block text-white text-sm font-bold mb-2" htmlFor="password">
                                Password
                            </label>
                            <input onChange={(e) => {setPassword(e.target.value)}} className="shadow appearance-none border border-red rounded w-full py-2 px-3 text-grey-darker mb-3" id="password" name="password" type="password" placeholder="******************" required/>
                        </div>
                        <div className="flex items-center justify-between">
                            <button className="font-bold outline-none uppercase focus:outline-none focus:shadow-none transition-all duration-300 rounded-md py-3 px-4 text-sm leading-relaxed text-white bg-teal-500 hover:bg-teal-700 focus:bg-teal-400 active:bg-teal-800 shadow-md-blue-gray hover:shadow-lg-blue-gray" type="submit">
                                Register
                            </button>
                        </div>
                    </div>
                </form>
            </div>
        </Layout>
    </div>
  )
}

export default RegisterDisplay
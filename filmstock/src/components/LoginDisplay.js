import React from 'react';
import Layout from './Layout';
import './stylesheets/loginSystem.css'

const LoginDisplay = () => {
  return (
    <div className='App'>
        <Layout>
            <div className='single-content-box'>
                <form action="https://localhost:7299/api/user/LoginUser" method='POST'>
                    <div className="shadow-md rounded px-8 pt-6 pb-8 mb-4 flex flex-col" id="login-panel">
                        <div className="mb-4">
                            <label className="block text-white text-sm font-bold mb-2" htmlFor="userName">
                                Username
                            </label>
                            <input className="shadow appearance-none border rounded w-full py-2 px-3 text-grey-darker" id="userName" name="userName" type="text" placeholder="Username" required/>
                        </div>
                        <div className="mb-6">
                            <label className="block text-white text-sm font-bold mb-2" htmlFor="password">
                                Password
                            </label>
                            <input className="shadow appearance-none border border-red rounded w-full py-2 px-3 text-grey-darker mb-3" id="password" name="password" type="password" placeholder="******************" required/>
                        </div>
                        <div className="flex items-center justify-between">
                            <button className="font-bold outline-none uppercase focus:outline-none focus:shadow-none transition-all duration-300 rounded-md py-3 px-4 text-sm leading-relaxed text-white bg-teal-500 hover:bg-teal-700 focus:bg-teal-400 active:bg-teal-800 shadow-md-blue-gray hover:shadow-lg-blue-gray" type="submit">
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
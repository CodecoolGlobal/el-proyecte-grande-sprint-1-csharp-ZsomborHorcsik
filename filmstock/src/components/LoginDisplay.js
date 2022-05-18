import React from 'react';
import Layout from './Layout';
import './stylesheets/login.css'

const LoginDisplay = () => {
  return (
    <div className='App'>
        <Layout>
            <div className='single-content-box' method='POST'>
                <form action="">
                    <div className="bg-gray-500 shadow-md rounded px-8 pt-6 pb-8 mb-4 flex flex-col">
                        <div className="mb-4">
                            <label className="block text-grey-darker text-sm font-bold mb-2" htmlFor="username">
                                Username
                            </label>
                            <input className="shadow appearance-none border rounded w-full py-2 px-3 text-grey-darker" id="userName" name="userName" type="text" placeholder="Username" />
                        </div>
                        <div className="mb-6">
                            <label className="block text-grey-darker text-sm font-bold mb-2" htmlFor="password">
                                Password
                            </label>
                            <input className="shadow appearance-none border border-red rounded w-full py-2 px-3 text-grey-darker mb-3" id="password" name="password" type="password" placeholder="******************"/>
                        </div>
                        <div className="flex items-center justify-between">
                            <button className="bg-blue hover:bg-blue-dark text-white font-bold py-2 px-4 rounded" type="button">
                                Sign In
                            </button>
                            <a className="inline-block align-baseline font-bold text-sm text-blue hover:text-blue-darker" href="#">
                                Forgot Password?
                            </a>
                        </div>
                    </div>
                </form>
            </div>
        </Layout>
    </div>
  )
}

export default LoginDisplay
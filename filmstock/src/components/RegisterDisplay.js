import React from 'react';
import Layout from './Layout';

const RegisterDisplay = () => {
  return (
    <div className='App'>
        <Layout>
            <div className='single-content-box'>
                <form action="https://localhost:7299/api/user/register" method='POST'>
                    <div className="bg-gray-500 shadow-md rounded px-8 pt-6 pb-8 mb-4 flex flex-col">
                        <div className="mb-4">
                            <label className="block text-grey-darker text-sm font-bold mb-2" htmlFor="firstName">
                                First name
                            </label>
                              <input className="shadow appearance-none border rounded w-full py-2 px-3 text-grey-darker" id="firstName" name="firstName" type="text" placeholder="First name" required/>
                        </div>
                        <div className="mb-4">
                            <label className="block text-grey-darker text-sm font-bold mb-2" htmlFor="lastName">
                                Last name
                            </label>
                              <input className="shadow appearance-none border rounded w-full py-2 px-3 text-grey-darker" id="lastName" name="lastName" type="text" placeholder="Last name" required/>
                        </div>
                        <div className="mb-4">
                            <label className="block text-grey-darker text-sm font-bold mb-2" htmlFor="email">
                                E-mail
                            </label>
                            <input className="shadow appearance-none border rounded w-full py-2 px-3 text-grey-darker" id="email" name="email" type="text" placeholder="Email" required/>
                        </div>
                        <div className="mb-4">
                            <label className="block text-grey-darker text-sm font-bold mb-2" htmlFor="userName">
                                Username
                            </label>
                            <input className="shadow appearance-none border rounded w-full py-2 px-3 text-grey-darker" id="userName" name="userName" type="text" placeholder="Username" required/>
                        </div>
                        <div className="mb-6">
                            <label className="block text-grey-darker text-sm font-bold mb-2" htmlFor="password">
                                Password
                            </label>
                            <input className="shadow appearance-none border border-red rounded w-full py-2 px-3 text-grey-darker mb-3" id="password" name="password" type="password" placeholder="******************" required/>
                        </div>
                        <div className="flex items-center justify-between">
                            <button className="bg-blue hover:bg-blue-dark text-white font-bold py-2 px-4 rounded" type="submit">
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
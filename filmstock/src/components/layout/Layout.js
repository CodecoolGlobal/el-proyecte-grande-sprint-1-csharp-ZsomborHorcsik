import React from 'react';
import Header from './Header';
import Footer from './Footer';
import '../../App.css'

const Layout = ({children}) => {
  return (
    <>
    <div className="wrapper">
      <Header/>
      <main className='main-box'>{children}</main>
      </div>
      <Footer/>
    
    </>
  )
}

export default Layout;
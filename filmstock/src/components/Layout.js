import React from 'react';
import Header from './Header';
import Footer from './Footer';
import '../App.css';

const Layout = ({children}) => {
  return (
    <>
      <Header/>
      <main className='main-box'>{children}</main>
      <Footer/>
    </>
  )
}

export default Layout;
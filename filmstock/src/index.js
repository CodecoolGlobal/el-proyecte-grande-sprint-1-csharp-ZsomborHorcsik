import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import MovieDisplay from './components/MovieDisplay'
import reportWebVitals from './reportWebVitals';
import {BrowserRouter, Routes, Route} from 'react-router-dom';

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route exact path="/" element={<App/>} />
        <Route exact path="/Movies" element={<MovieDisplay/>} />
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
, document.getElementById('root'));
reportWebVitals();
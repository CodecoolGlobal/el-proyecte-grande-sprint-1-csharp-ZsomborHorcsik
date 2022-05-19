import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import MovieDisplay from './components/MovieDisplay';
import SeriesDisplay from './components/SeriesDisplay';
import LoginDisplay from './components/LoginDisplay';
import RegisterDisplay from './components/RegisterDisplay';
import reportWebVitals from './reportWebVitals';
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import ShowMovie from './components/ShowMovie';

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route exact path="/" element={<App/>} />
        <Route exact path="/Movies" element={<MovieDisplay/>} />
        <Route exact path="/Series" element={<SeriesDisplay />} />
        <Route exact path="/Login" element={<LoginDisplay />} />
        <Route exact path="/Register" element={<RegisterDisplay />} />
        <Route exact path="/Movies/:id" element={<ShowMovie/>}/> 
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
, document.getElementById('root'));
reportWebVitals();
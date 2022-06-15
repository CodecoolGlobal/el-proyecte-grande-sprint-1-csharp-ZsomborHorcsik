import React, { useReducer } from 'react';
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
import CollectionDisplay from './components/CollectionDisplay';
import { configureStore } from '@reduxjs/toolkit';
import { Provider } from 'react-redux';
import userLoginSlice from './_slices/userLoginSlice';

const store = configureStore({
  reducer:{
    user: useReducer
  }
})

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <BrowserRouter>
        <Routes>
          <Route exact path="/" element={<App/>} />
          <Route exact path="/Movies" element={<MovieDisplay/>} />
          <Route exact path="/Series" element={<SeriesDisplay />} />
          <Route exact path="/Login" element={<LoginDisplay />} />
          <Route exact path="/Register" element={<RegisterDisplay />} />
          <Route exact path="/Movies/:id" element={<ShowMovie/>}/> 
          <Route exact path="/:id/Collection" element={<CollectionDisplay/>}/> 
        </Routes>
      </BrowserRouter>
    </Provider>
  </React.StrictMode>
, document.getElementById('root'));
reportWebVitals();
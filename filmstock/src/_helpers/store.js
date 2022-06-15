import { configureStore } from '@reduxjs/toolkit';
import userReducer from '../_slices/userLoginSlice';

export const store = configureStore({
    reducer:{
      user: userReducer
    }
  });

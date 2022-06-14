import { createSlice } from "@reduxjs/toolkit";

const defaultState = {username: "", password: ""}

export const userSlice = createSlice({
    name:"user",
    defaultState,
    reducers:{
            login: (state, action) =>{
                state.user = action.payload;
            },
            logout: (state) => {
                state.user = null;
            }
        }
});

export  const {login, logout} = userSlice.actions;
export const selectUser = (state) => state.user.user;
export default userSlice.reducer;
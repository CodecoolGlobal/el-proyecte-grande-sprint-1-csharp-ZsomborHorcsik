import { createSlice } from "@reduxjs/toolkit";

function checkUser(){
    const currentUser = localStorage.getItem('user');
    if(currentUser){
        return currentUser;
    }
    return null;
}


export const userSlice = createSlice({
    name:"user",
    initialState:{
        user: checkUser()
    },
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
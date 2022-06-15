import { createSlice } from "@reduxjs/toolkit";

function checkUser(){
    const currentUser = localStorage.getItem('user');
    
    if(currentUser == null){
        return null;
    }
    return currentUser;
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

export default userSlice.reducer;
export  const {login, logout} = userSlice.actions;
export const selectUser = (state) => state.user.user;

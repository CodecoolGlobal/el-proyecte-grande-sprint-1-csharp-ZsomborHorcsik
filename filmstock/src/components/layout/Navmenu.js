import React, { useState } from "react";
import Navbar from "@material-tailwind/react/Navbar";
import NavbarContainer from "@material-tailwind/react/NavbarContainer";
import NavbarWrapper from "@material-tailwind/react/NavbarWrapper";
import NavbarBrand from "@material-tailwind/react/NavbarBrand";
import NavbarToggler from "@material-tailwind/react/NavbarToggler";
import NavbarCollapse from "@material-tailwind/react/NavbarCollapse";
import Nav from "@material-tailwind/react/Nav";
import NavItem from "@material-tailwind/react/NavItem";
import Icon from "@material-tailwind/react/Icon";
import authService from "../../_services/auth.service";
import { logout } from "../../_slices/userLoginSlice";
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import {useSelector} from 'react-redux';

const Navmenu = () => {
    const [openNavbar, setOpenNavbar] = useState(false);
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const handleLogout = async event =>{
        event.preventDefault();
        try{
            await dispatch(logout());
            await authService.logout();
            navigate("/");
        }catch(err){
            console.log(err);
        }
    }
    if(!localStorage.getItem("user")){
        return (
            <Navbar color="blueGray" navbar>
                <NavbarContainer>
                    <NavbarWrapper>
                        <NavbarBrand><a href="http://localhost:3000/">FilmStock</a></NavbarBrand>
                        <NavbarToggler
                            color="white"
                            onClick={() => setOpenNavbar(!openNavbar)}
                            ripple="light"
                        />
                    </NavbarWrapper>
        
                    <NavbarCollapse open={openNavbar}>
                        <Nav leftSide>
                            <NavItem ripple="light">
                                <Icon name="assistant" size="xl" />
                                <a href="http://localhost:3000/Movies">Movies</a>
                            </NavItem>
                            <NavItem ripple="light" >
                                <Icon name="live_tv" size="xl" />
                                <a href="http://localhost:3000/Series">TV Series</a>
                            </NavItem>
                        </Nav>
                        <Nav rightSide>
                            <NavItem ripple="light">
                                <Icon name="login" size="xl"/>
                                <a href="http://localhost:3000/login">Login</a>
                            </NavItem>
                            <NavItem ripple="light">
                                <Icon name="logout" size="xl"/>
                                <a href="http://localhost:3000/register">Register</a>
                            </NavItem>
                        </Nav>
                    </NavbarCollapse>
                </NavbarContainer>
            </Navbar>
        )
    }
    else {
        return (
            <Navbar color="blueGray" navbar>
                <NavbarContainer>
                    <NavbarWrapper>
                        <NavbarBrand><a href="http://localhost:3000/">FilmStock</a></NavbarBrand>
                        <NavbarToggler
                            color="white"
                            onClick={() => setOpenNavbar(!openNavbar)}
                            ripple="light"
                        />
                    </NavbarWrapper>
        
                    <NavbarCollapse open={openNavbar}>
                        <Nav leftSide>
                            <NavItem ripple="light">
                                <Icon name="collections" size="xl" />
                                <a href="http://localhost:3000/Collection">Collection</a>
                            </NavItem>
                            <NavItem ripple="light">
                                <Icon name="assistant" size="xl" />
                                <a href="http://localhost:3000/Movies">Movies</a>
                            </NavItem>
                            <NavItem ripple="light" >
                                <Icon name="live_tv" size="xl" />
                                <a href="http://localhost:3000/Series">TV Series</a>
                            </NavItem>
                        </Nav>
                        <Nav rightSide>
                            <NavItem ripple="light">
                                <Icon name="logout" size="xl"/>
                                <button type="button" onClick={handleLogout} className="font-bold outline-none uppercase focus:outline-none focus:shadow-none transition-all duration-300 rounded-md py-3 px-4 text-sm leading-relaxed text-white bg-teal-500 hover:bg-teal-700 focus:bg-teal-400 active:bg-teal-800 shadow-md-blue-gray hover:shadow-lg-blue-gray">
                                    Logout
                                </button>
                            </NavItem>
                        </Nav>
                    </NavbarCollapse>
                </NavbarContainer>
            </Navbar>
        )
    }
}

export default Navmenu;
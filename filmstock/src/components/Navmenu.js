import React, { useState } from "react";
import Navbar from "@material-tailwind/react/Navbar";
import NavbarContainer from "@material-tailwind/react/NavbarContainer";
import NavbarWrapper from "@material-tailwind/react/NavbarWrapper";
import NavbarBrand from "@material-tailwind/react/NavbarBrand";
import NavbarToggler from "@material-tailwind/react/NavbarToggler";
import NavbarCollapse from "@material-tailwind/react/NavbarCollapse";
import Nav from "@material-tailwind/react/Nav";
import NavItem from "@material-tailwind/react/NavItem";
import NavbarInput from "@material-tailwind/react/NavbarInput";
import Icon from "@material-tailwind/react/Icon";

const Navmenu = () => {
    const [openNavbar, setOpenNavbar] = useState(false);
    if(!localStorage.getItem('user')){
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
                                Collections
                            </NavItem>
                            <NavItem ripple="light">
                                <Icon name="assistant" size="xl" />
                                <a href="http://localhost:3000/Movies">Discover</a>
                            </NavItem>
                            <NavItem ripple="light" >
                                <Icon name="live_tv" size="xl" />
                                <a href="http://localhost:3000/Series">TV Series</a>
                            </NavItem>
                            <NavItem>
                                <NavbarInput type="text" placeholder="Search here" />
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
                                Collections
                            </NavItem>
                            <NavItem ripple="light">
                                <Icon name="assistant" size="xl" />
                                <a href="http://localhost:3000/Movies">Discover</a>
                            </NavItem>
                            <NavItem ripple="light" >
                                <Icon name="live_tv" size="xl" />
                                <a href="http://localhost:3000/Series">TV Series</a>
                            </NavItem>
                            <NavItem>
                                <NavbarInput type="text" placeholder="Search here" />
                            </NavItem>
                        </Nav>
                        <Nav rightSide>
                            <NavItem ripple="light">
                                <Icon name="loginout" size="xl"/>
                                <a href="http://localhost:3000/logout">Logout</a>
                            </NavItem>
                        </Nav>
                    </NavbarCollapse>
                </NavbarContainer>
            </Navbar>
        )
    }
}

export default Navmenu;
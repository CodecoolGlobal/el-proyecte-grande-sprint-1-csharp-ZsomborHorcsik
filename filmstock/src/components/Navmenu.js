import React, { useState } from "react";
import Navbar from "@material-tailwind/react/Navbar";
import NavbarContainer from "@material-tailwind/react/NavbarContainer";
import NavbarWrapper from "@material-tailwind/react/NavbarWrapper";
import NavbarBrand from "@material-tailwind/react/NavbarBrand";
import NavbarToggler from "@material-tailwind/react/NavbarToggler";
import NavbarCollapse from "@material-tailwind/react/NavbarCollapse";
import Nav from "@material-tailwind/react/Nav";
import NavItem from "@material-tailwind/react/NavItem";
import NavLink from "@material-tailwind/react/NavLink";
import NavbarInput from "@material-tailwind/react/NavbarInput";
import Icon from "@material-tailwind/react/Icon";

const Navmenu = () => {
  const [openNavbar, setOpenNavbar] = useState(false);

  return (
    <Navbar color="blueGray" navbar>
        <NavbarContainer>
            <NavbarWrapper>
                <NavbarBrand>FilmStock</NavbarBrand>
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
                    <NavLink href="#navbar" active="light" ripple="light">
                        <Icon name="assistant" size="xl" />
                        Discover
                    </NavLink>
                    <NavItem ripple="light">
                        <Icon name="live_tv" size="xl" />
                        TV Series
                    </NavItem>
                    <NavItem>
                        <NavbarInput type="text" placeholder="Search here" />
                    </NavItem>
                </Nav>
                <Nav rightSide>
                    <NavItem ripple="light">
                        <Icon name="login" size="xl"/>
                        Login
                    </NavItem>
                    <NavItem ripple="light">
                        <Icon name="logout" size="xl"/>
                        Register
                    </NavItem>
                </Nav>
                
            </NavbarCollapse>
        </NavbarContainer>
    </Navbar>
  );
}

export default Navmenu;
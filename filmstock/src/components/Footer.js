const Footer = () =>{
    return ( 
        <footer id="footer" className="flex items-center justify-between px-12 px-4 bg-gray-500 py-7 text-black fix-footer">
            <span className="text-sm text-black sm:text-center">© 2022 <a href="#test" className="hover:underline">FilmStock™</a>. All Rights Reserved.
            </span>
            <ul className="flex flex-wrap items-center mt-3 text-sm text-black sm:mt-0">
                <li>
                    <a href="#test" className="mr-4 hover:underline md:mr-6 ">About</a>
                </li>
                <li>
                    <a href="#test" className="mr-4 hover:underline md:mr-6">Privacy Policy</a>
                </li>
                <li>
                    <a href="#test" className="mr-4 hover:underline md:mr-6">Licensing</a>
                </li>
                <li>
                    <a href="#test" className="hover:underline">Contact</a>
                </li>
            </ul>
        </footer>
    )
}

export default Footer;
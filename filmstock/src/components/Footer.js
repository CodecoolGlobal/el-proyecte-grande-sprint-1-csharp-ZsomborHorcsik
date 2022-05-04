const Footer = () =>{
    return ( 
        <footer class="md:flex md:items-center md:justify-between sm:px-12 px-4 bg-white py-7 text-black">
            <span class="text-sm text-black sm:text-center">© 2022 <a href="#test" class="hover:underline">FilmStock™</a>. All Rights Reserved.
            </span>
            <ul class="flex flex-wrap items-center mt-3 text-sm text-black sm:mt-0">
                <li>
                    <a href="#test" class="mr-4 hover:underline md:mr-6 ">About</a>
                </li>
                <li>
                    <a href="#test" class="mr-4 hover:underline md:mr-6">Privacy Policy</a>
                </li>
                <li>
                    <a href="#test" class="mr-4 hover:underline md:mr-6">Licensing</a>
                </li>
                <li>
                    <a href="#test" class="hover:underline">Contact</a>
                </li>
            </ul>
        </footer>
    )
}

export default Footer;
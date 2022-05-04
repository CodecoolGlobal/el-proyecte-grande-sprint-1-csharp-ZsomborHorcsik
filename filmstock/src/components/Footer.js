const Footer = () =>{
    return (
        <footer className="text-center text-white">
            <div className="container p-6">
                <div>
                <p className="flex justify-center items-center">
                    <span className="mr-4">Register</span>
                    <button className="inline-block px-6 py-2 border-2 border-white text-white font-medium text-xs leading-tight uppercase rounded-full hover:bg-black hover:bg-opacity-5 focus:outline-none focus:ring-0 transition duration-150 ease-in-out">
                    Sign up!
                    </button>
                </p>
                </div>
            </div>

            <div className="text-center p-4">
                © 2021 Copyright:
                <a className="text-white" href="#">FilmStock</a>
            </div>
        </footer>
    )
}

export default Footer;
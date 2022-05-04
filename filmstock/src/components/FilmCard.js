import React from "react";
import Modal from "./Modal";

const FilmCard = ({movie}) => {
    return (
        <div className="mx-2 m-2 box-border">
            <div className="bg-white shadow-md rounded-lg flex-column md:content-center md:justify-center p-5">
                <img alt="" className="rounded-lg -mt-9" src={movie.image}></img>

                <div class="p-1">
                    <h1 className="text-gray-900 text-xl font-serif font-bold leading-normal mt-0 mb-2">{movie.fullTitle}</h1>
                    <p className="text-blue-gray-700 text-base font-light leading-relaxed mt-0 mb-2">{movie.rating}</p>
                </div>

                <div className="p-1">
                    {/* <button class="items-center justify-center font-bold outline-none uppercase tracking-wider focus:outline-none focus:shadow-none transition-all duration-300 rounded-lg py-3 px-7 text-sm leading-relaxed text-white bg-blue-gray-500 hover:bg-blue-gray-700 focus:bg-blue-gray-400 active:bg-blue-gray-800 shadow-md-blue-gray hover:shadow-lg-blue-gray">
                        Go to discussion
                    </button> */}
                    <Modal movie={movie}/>
                </div>
            </div>
        </div>
    );
}

export default FilmCard;
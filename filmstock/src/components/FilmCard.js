import '../App.css';
import React from "react";

const FilmCard = ({movie}) => {
    return (
        <div className="mx-2 m-2">
            <div className="bg-white shadow-md rounded-lg flex-column p-5 transition ease-in-out delay-150 hover:-translate-y-1 hover:scale-105 duration-300 card-box">
                <img alt="" className="rounded-lg -mt-9" src={movie.image}></img>

                <div class="p-1">
                    <h1 className="text-gray-900 text-md font-serif font-bold mt-0 mb-2">{movie.title}</h1>
                    <p className="text-blue-gray-700 text-base font-light mt-0 mb-2">{movie.rating}</p>
                </div>
                <div className="p-1">
                    <button class="items-center justify-center font-bold outline-none uppercase tracking-wider focus:outline-none focus:shadow-none transition-all duration-300 rounded-md py-3 px-4 text-sm leading-relaxed text-white bg-teal-500 hover:bg-teal-700 focus:bg-teal-400 active:bg-teal-800 shadow-md-blue-gray hover:shadow-lg-blue-gray">
                        Go to discussion
                    </button>
                </div>
            </div>
        </div>
    );
}

export default FilmCard;
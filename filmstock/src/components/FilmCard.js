import '../App.css';
import React from "react";

const FilmCard = ({movie}) => {
    return (
        <div className="mx-2 m-2">
            <div className="bg-white shadow-md h-150 min-h-full rounded-lg flex flex-col justify-between self-end p-5 transition ease-in-out delay-150 hover:-translate-y-1 hover:scale-105 duration-300 card-box">
                <img alt="" className="rounded-lg -mt-9" src={movie.image}></img>

                <div className="p-1">
                    <h1 className="text-gray-900 text-xl font-serif font-bold mt-0 mb-2">{movie.title}</h1>
                    <p className="text-white-700 text-lg mt-0 mb-2">{movie.rating}</p>
                </div>
                <button className="font-bold outline-none uppercase focus:outline-none focus:shadow-none transition-all duration-300 rounded-md py-3 px-4 text-sm leading-relaxed text-white bg-teal-500 hover:bg-teal-700 focus:bg-teal-400 active:bg-teal-800 shadow-md-blue-gray hover:shadow-lg-blue-gray">
                    Go to discussion
                </button>
            </div>
        </div>
    );
}

export default FilmCard;
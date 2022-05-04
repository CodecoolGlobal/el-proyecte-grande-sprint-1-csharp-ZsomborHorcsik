import React from "react";
import Modal from "./Modal";

const FilmCard = () => {
    return (
        <div className="mx-2">
            <div className="bg-white shadow-md rounded-lg flex-column p-5">
                <img alt="" class="rounded-lg -mt-9" src="https://image.tmdb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"></img>

                <div class="p-1">
                    <h1 class="text-gray-900 text-xl font-serif font-bold leading-normal mt-0 mb-2">Inception (2018)</h1>
                    <p class="text-blue-gray-700 text-base font-light leading-relaxed mt-0 mb-2">8.7 - *************</p>
                </div>

                <div class="p-1">
                    {/* <button class="items-center justify-center font-bold outline-none uppercase tracking-wider focus:outline-none focus:shadow-none transition-all duration-300 rounded-lg py-3 px-7 text-sm leading-relaxed text-white bg-blue-gray-500 hover:bg-blue-gray-700 focus:bg-blue-gray-400 active:bg-blue-gray-800 shadow-md-blue-gray hover:shadow-lg-blue-gray">
                        Go to discussion
                    </button> */}
                    <Modal/>
                </div>
            </div>
        </div>
    );
}

export default FilmCard;
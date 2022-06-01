import React from 'react';
import Layout from './Layout';
import { useParams } from 'react-router-dom';
import useFetch from '../Hooks/useFetch';
import './stylesheets/showMovie.css'

const ShowMovie = (props) => {
    const { id } = useParams();
    const {data, error} = useFetch(`api/Movie/${id}`);
    const starRating = data?.rating;
    if(error) console.log(error);
  return (
    <div>
        <Layout>
            <div className='movie-content-box'>
                <div className='movie-image'>
                    <img src={data?.image} alt="The poster of the movie" className='movie-image'></img>
                </div>
                <div className='movie-details'>
                  <div className='detail-item'>
                    <p>{data?.fullTitle}</p>
                    <p>Crew: {data?.crew}</p>
                  </div>
                  <div>
                    <p>{data?.rating}</p>{Array.from({ length: starRating }, (_, i) => <i key={i} class="fa-solid fa-star"></i>)}
                    <p>Global rank : {data?.rank}</p>
                    <button className='font-bold outline-none uppercase focus:outline-none focus:shadow-none transition-all duration-300 rounded-md py-3 px-4 text-sm leading-relaxed text-white bg-teal-500 hover:bg-teal-700 focus:bg-teal-400 active:bg-teal-800 shadow-md-blue-gray hover:shadow-lg-blue-gray'><a>Add to collection</a></button>
                  </div>
                </div>
            </div>
            <div className='review-content-box'>
              <div class="comment">
                <div class="comment-heading">
                  <div class="comment-voting">
                    <button type="button">
                        <span aria-hidden="true">&#9650;</span>
                        <span class="sr-only">Vote up</span>
                    </button>
                    <button type="button">
                        <span aria-hidden="true">&#9660;</span>
                        <span class="sr-only">Vote down</span>
                    </button>
                  </div>
                  <div class="comment-info">
                      <a href="#" class="comment-author">TestUser</a>
                      <p class="m-0">
                        4 days ago
                      </p>
                  </div>
                </div>
                <div class="comment-body">
                  <p>
                    A tough, complex story [told] with clarity, compassion and considerable dramatic force.
                  </p>
                </div>
              </div>
            </div>
        </Layout>
    </div>
  )
}

export default ShowMovie;
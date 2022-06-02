import React from 'react';
import Layout from './layout/Layout';
import { useParams } from 'react-router-dom';
import useFetch from '../Hooks/useFetch';
import './stylesheets/showMovie.css';
import collectionService from '../_services/collection.service';
import authHeader from '../_services/auth.header';

const ShowMovie = (props) => {
    const { id } = useParams();
    const {data, error} = useFetch(`api/Movie/${id}`);
    const starRating = data?.rating;

    const handleClick = async event =>{
        event.preventDefault();
        try{
            await collectionService.addToUserCollection(`api/Collection/add/${id}`, {})
                                  .then( (response)=>{
                                      console.log(JSON.stringify(response.data));
                                  })
        }
        catch(err){
          console.log(err);
        }
    }

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
                    <p>{data?.rating}</p>{Array.from({ length: starRating }, (_, i) => <i key={i} className="fa-solid fa-star"></i>)}
                    <p>Global rank : {data?.rank}</p>
                    <button onClick={handleClick} className='font-bold outline-none uppercase focus:outline-none focus:shadow-none transition-all duration-300 rounded-md py-3 px-4 text-sm leading-relaxed text-white bg-teal-500 hover:bg-teal-700 focus:bg-teal-400 active:bg-teal-800 shadow-md-blue-gray hover:shadow-lg-blue-gray'>Add to collection</button>
                  </div>
                </div>
            </div>
            <div className='review-content-box'>
              <div className="comment">
                <div className="comment-heading">
                  <div className="comment-voting">
                    <button type="button">
                        <span aria-hidden="true">&#9650;</span>
                        <span className="sr-only">Vote up</span>
                    </button>
                    <button type="button">
                        <span aria-hidden="true">&#9660;</span>
                        <span className="sr-only">Vote down</span>
                    </button>
                  </div>
                  <div className="comment-info">
                      <a href="#" className="comment-author">TestUser</a>
                      <p className="m-0">
                        4 days ago
                      </p>
                  </div>
                </div>
                <div className="comment-body">
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
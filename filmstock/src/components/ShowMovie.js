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
                    <img src={data?.image} alt=""></img>
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
              <div className='review-box'>
                <h1 className='review-author'>Vagány Jóskagyerek</h1>
                <p className='review'>Gya de jau film vót he</p>
              </div>
              <div className='comment-box'>
                <div className='comment'>
                  <h2 className='comment-author'>Véleményosztó</h2>
                  <p className='comment'>this is ich bin das ist comment</p>
                  <div className='comment-rating'>
                      <i class="fa-solid fa-face-smile item-rate"></i>
                      <i class="fa-solid fa-face-frown item-rate"></i>
                      <i class="fa-solid fa-face-rolling-eyes item-rate"></i>
                  </div>
                </div>
                <div className='comment'>
                  <h2 className='comment-author'>Másik Véleményosztó</h2>
                  <p className='comment'>msőovnfmsőgápjksmdőgpjk dúpoojkg spdútojgk ődspáojg úpsdojgf údséoflgkdsúáűőp kgsáőpdofk gjúsdpg</p>
                  <div className='comment-rating'>
                      <i class="fa-solid fa-face-smile item-rate"></i>
                      <i class="fa-solid fa-face-frown item-rate"></i>
                      <i class="fa-solid fa-face-rolling-eyes item-rate"></i>
                  </div>
                </div>
              </div>
            </div>
        </Layout>
    </div>
  )
}

export default ShowMovie;
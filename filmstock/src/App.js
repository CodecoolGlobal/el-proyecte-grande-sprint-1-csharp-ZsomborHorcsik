import './App.css';
import Header from './components/Header';
import FilmCard from './components/FilmCard';
import "@material-tailwind/react/tailwind.css";
import axios from 'axios';
import {useState, useEffect} from "react";

function App() {
    const [data, setData] = useState(null);
    const url = "https://localhost:44398/Movie/GetAll"

    useEffect(()=>{
        axios
        .get(url)
        .then((response) =>{
            setData(response.data);
        })
        .catch((err)=>{
            console.log(err)
        })
    }, []);
    console.log(data);
  return (
    <div className="App">
      <Header/>
      <div className='container mx-auto flex card-box'>
        <FilmCard/>
        <FilmCard/>
        <FilmCard/>
        <FilmCard/>
        <FilmCard/>
      </div>
      
    </div>
  );
}

export default App;

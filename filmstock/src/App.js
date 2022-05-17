import './App.css';
import "@material-tailwind/react/tailwind.css";
import Header from './components/Header';
import FilmCard from './components/FilmCard';
import useFetch from './Hooks/useFetch';
import Footer from './components/Footer';
import {useState} from "react";

function App() {
  const {data, error, loading} = useFetch(filterInfo);

  if(error) console.log(error);

  return (
    <div className="App">
    </div>
  );
}

export default App;

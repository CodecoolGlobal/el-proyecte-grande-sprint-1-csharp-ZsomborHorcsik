import './App.css';
import "@material-tailwind/react/tailwind.css";
import Header from './components/Header';
import FilmCard from './components/FilmCard';
import useFetch from './Hooks/useFetch';
import Footer from './components/Footer'
import {useState} from "react"

function App() {
  const [filterInfo, setFilter] = useState("api/Movie/Movies");

  const {data, error, loading} = useFetch(filterInfo);

  if(error) console.log(error);

  return (
    <div className="App">

      <Header setFilter={setFilter}/>

      <div className={`grid grid-cols-6 gap-4 md:container md:mx-auto mt-6 ${loading ? "opacity-50" : ""}`}>
        {data?.map(movieData =>(<FilmCard movie={movieData} key={movieData.id}/>))}
      </div>

      <Footer/>
      
    </div>
  );
}

export default App;

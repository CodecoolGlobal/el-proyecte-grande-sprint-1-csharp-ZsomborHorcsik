import './App.css';
import "@material-tailwind/react/tailwind.css";
import Header from './components/Header';
import FilmCard from './components/FilmCard';
import useFetch from './Hooks/useFetch';
import Footer from './components/Footer'

function App() {
  const {data, error, loading} = useFetch(
    "https://localhost:7299/GetAll"
    );

  if(error) console.log(error);
  if(loading) return <h1>Retrieving data...</h1>

  return (
    <div className="App">
      <Header/>
      <div className='grid grid-cols-6 gap-4 md:container md:mx-auto mt-6 '>
        {data?.map(movieData =>(<FilmCard movie={movieData} key={movieData.title}/>))}
      </div>
      <Footer/>
    </div>
  );
}

export default App;

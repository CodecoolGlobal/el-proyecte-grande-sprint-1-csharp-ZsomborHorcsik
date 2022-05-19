import '../App.css';
import "@material-tailwind/react/tailwind.css";
import FilmCard from '../components/FilmCard';
import useFetch from '../Hooks/useFetch';
import Layout from './Layout';

function MovieDisplay() {
  const {data, error} = useFetch("api/Movie/Movies");

  if(error) console.log(error);

  return (
    <div className="MovieDisplay">
        <Layout>
            <div className={`grid grid-cols-6 gap-4 md:container md:mx-auto mt-6`}>
                {data?.map(movieData =>(<FilmCard movie={movieData} key={movieData.id}/>))}
            </div>
        </Layout>
    </div>
  );
}

export default MovieDisplay;

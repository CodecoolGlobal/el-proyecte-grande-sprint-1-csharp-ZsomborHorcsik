import './App.css';
import useFetch from './hooks/useFetch'
import Header from './components/Header';
import "@material-tailwind/react/tailwind.css";

function App() {
  const {data} = useFetch("https://localhost:44398/Movie/GetAll");
  return (
    <div className="App">
      <Header/>
    </div>
  );
}

export default App;

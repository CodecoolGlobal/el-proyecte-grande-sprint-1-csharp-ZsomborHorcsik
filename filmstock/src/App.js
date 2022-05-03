import './App.css';
import useFetch from './hooks/useFetch'

function App() {
  const {data} = useFetch("https://localhost:44398/Movie/GetAll");
  console.log(data);

  return (
    <div className="App">
    </div>
  );
}

export default App;

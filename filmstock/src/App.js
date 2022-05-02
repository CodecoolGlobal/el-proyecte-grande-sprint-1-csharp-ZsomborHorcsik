import './App.css';
import axios from 'axios';
import { useEffect } from 'react';
import { useState } from 'react';

function useFetch(url){
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);

  useEffect(()=>{
      axios
      .get(url)
      .then((response) =>{
          setData(response.data);
      })
      .catch((err)=>{
          setError(err);
      })
  }, [url]);

  return {data, error};
}


function App() {
  const {data} = useFetch("/Movie/GetAll");
  console.log(data);
  return (
    <div className="App">
      <header className="App-header">
      </header>
    </div>
  );
}

export default App;

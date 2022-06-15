import axios from "axios";
import {useState, useEffect} from "react";

function useFetch(filterInfo){
    const [data, setData] = useState(null);
    const [error, setError] = useState(null);
    const url = "https://localhost:7299/";

    useEffect(()=>{
        axios
        .get(url+filterInfo,
            {
                headers: {
                    'Authorization': `Bearer ${localStorage.getItem("user")}`
                  }
            })
        .then((response) =>{
            setData(response.data);
        })
        .catch((err)=>{
            setError(err);
        })
    }, [filterInfo]);

    return {data, error};
}

export default useFetch;
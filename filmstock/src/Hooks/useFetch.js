import axios from "axios";
import {useState, useEffect} from "react";

function useFetch(filterInfo){
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const url = "https://localhost:7299/";

    useEffect(()=>{
        setLoading(true);
        axios
        .get(url+filterInfo)
        .then((response) =>{
            setData(response.data);
        })
        .catch((err)=>{
            setError(err);
        })
        .finally(()=>{
            setLoading(false);
        });
    }, [filterInfo]);

    return {data, error, loading};
}

export default useFetch;
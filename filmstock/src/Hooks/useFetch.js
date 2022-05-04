import axios from "axios";
import {useState, useEffect} from "react";

function useFetch(url){
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    useEffect(()=>{
        setLoading(true);
        axios
        .get(url)
        .then((response) =>{
            setData(response.data);
        })
        .catch((err)=>{
            setError(err);
        })
        .finally(()=>{
            setLoading(false);
        });
    }, [url]);

    return {data,error,loading};
}

export default useFetch;
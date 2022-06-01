import axios from "axios";

function postFetch(urlFilter, payload){
    const baseUrl = "https://localhost:7299/";
    return axios.post(baseUrl + urlFilter, payload)
                .then((response)=>{
                    localStorage.setItem("user", JSON.stringify(response.data));
                    console.log(localStorage.getItem("user"));
                })

}


async function apiPost(urlFilter, payload) {
    const baseUrl = "https://localhost:7299/";
    let response = await fetch(baseUrl + urlFilter , {
        method: "POST",
        headers: {"Content-type": "application/json"},
        body: JSON.stringify(payload)
    });
    if (response.status === 200) {
        console.log(response)
        let data = response.data;
        return data;
    }
}

export default postFetch;
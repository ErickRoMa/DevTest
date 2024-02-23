import axios from "axios";

const baseUrl = process.env.REACT_APP_API_BASE_URL

const axiosClient= axios.create({
 baseURL : baseUrl,
 timeout : 8000 
});


export const requestGet = async (endpoint, parameter) => {   
      if(parameter!==undefined)
        return await axiosClient.get(endpoint,{ params: parameter }); 
     return await axiosClient.get(endpoint);
}


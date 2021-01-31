import axios from 'axios';

const api = 'http://localhost:5000/api';
export const accountService =  {
    register(userRegistration) {
        return axios.post(`${api}/accounts/register`, userRegistration)
    }
}
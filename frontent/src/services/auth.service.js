
import axios from 'axios';

const api = 'http://localhost:5000/api';
export const authService =  {
    login(credentials) {
        return axios.post(`${api}/accounts/login`, credentials)
    },
}

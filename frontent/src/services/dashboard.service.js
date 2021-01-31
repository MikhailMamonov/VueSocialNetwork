import axios from 'axios';

const api = 'http://localhost:5000/api';
export const dashboardService =  {
    getHomeDetails() {
        return axios.get(`${api}/dashboard/home`);
    }
}

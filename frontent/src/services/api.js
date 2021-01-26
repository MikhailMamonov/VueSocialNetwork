import axios from 'axios';

const baseDomain = "http://localhost:5000";
const baseURL = `${baseDomain}/api`;

export default axios.create({
  baseURL
})
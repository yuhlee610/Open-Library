import axios from "axios";

const instance = axios.create({baseURL: 'https://localhost:44348/api'})

export default instance
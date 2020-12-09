
import axios from 'axios';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Rx';

class ProfileService extends BaseService {

    static instance;

    constructor() {  super(); }

    static get Instance() {
       return this.instance || (this.instance = new this());
    }

    get() {
        return Observable.fromPromise(axios.get(`${this.api}/users/index`))
        .map((res) => {
            console.log( res.data); 
            const parsed = JSON.stringify(res.data);
            localStorage.setItem('profile', parsed);  
            return res.data;})
        .catch((error) => {console.log( error.response); this.handleError(error.response)});
    }
}

export const profileService = ProfileService.Instance;
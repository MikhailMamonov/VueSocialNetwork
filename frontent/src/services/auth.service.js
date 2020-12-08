
import axios from 'axios';

import { BaseService } from './base.service';
import { Observable } from 'rxjs/Rx';

class AuthService extends BaseService {

    static instance;

    constructor() {  super(); }

    static get Instance() {
       // Do you need arguments? Make it a regular method instead.
       return this.instance || (this.instance = new this());
    }

    login(credentials) {
        return Observable.fromPromise(axios.post(`${this.api}/accounts/login`, credentials))
        .map((res) => res.data)
        .catch((error) => this.handleError(error.response));
    }
}

// export a singleton instance in the global namespace
export const authService = AuthService.Instance;

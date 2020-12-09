
import axios from 'axios';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Rx';

class AccountService extends BaseService {

    static instance;

    constructor() {  super(); }

    static get Instance() {
       return this.instance || (this.instance = new this());
    }

    register(userRegistration) {
        return Observable.fromPromise(axios.post(`${this.api}/accounts`, userRegistration))
        .map((res) => true)
        .catch((error) => this.handleError(error.response));
    }
}

export const accountService = AccountService.Instance;
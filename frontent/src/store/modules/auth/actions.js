import { authService } from '../../../services/auth.service';
import defaultState from './defaultState';
import axios from 'axios'

const login= ({commit, dispatch} , credentials) => {
        return new Promise((resolve, reject) => {
            commit('LOGIN_REQUEST');
            authService.login(credentials)
            .subscribe((result) => {
              localStorage.setItem('token', result.token); // stash the auth token in localStorage
              localStorage.setItem('user', JSON.stringify(result.user));
              axios.defaults.headers.common['Authorization'] = result.token
              commit('LOGIN_SUCCESS', {token: result.token, user: result.user});
              dispatch('users/setCurrentUser',result.user, { root: true });
              
              resolve(result);
            },
            (errors) => {
              commit('LOGIN_ERROR', errors);
              localStorage.removeItem('token');
              reject(errors);
            });
          });
    }
    const LOGOUT =  ({commit, dispatch}) => {
        return new Promise((resolve, reject) => {
          commit('LOGOUT');
          localStorage.removeItem('token');
          localStorage.removeItem('user');
          delete axios.defaults.headers.common['Authorization']
          dispatch('users/setCurrentUser',{}, { root: true })
          resolve();
        });
    }

    export {
        login,
        LOGOUT
    }
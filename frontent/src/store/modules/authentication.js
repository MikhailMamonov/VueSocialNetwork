
import { authService } from '../../services/auth.service';
import { EventBus } from '../../event-bus';

const user = JSON.parse(localStorage.getItem('user'));

const initialState = { 
  token: localStorage.getItem('auth-token') || '',
  status: user ? { loggedIn: true }: {},
  user: user||{}
 };

 const state = { token: localStorage.getItem('auth-token') || '', status: '', user: user||{} };
const getters = {
    isAuthenticated: (authState) => { debugger; return !!authState.token},
    authStatus: (authState) => authState.status,
    authToken: (authState) => authState.token,
    user: (authState) => authState.user,
};

const actions = {
    login: ({commit, dispatch} , credentials) => {
        return new Promise((resolve, reject) => {
            commit('loginRequest');
            authService.login(credentials)
            .subscribe((result) => {
              localStorage.setItem('auth-token', result.token); // stash the auth token in localStorage
              debugger;
              commit('loginSuccess', result.token, result.user);
              EventBus.$emit('logged-in', null);
              //dispatch('user/userRequest', null, { root: true });
              resolve(result);
            },
            (errors) => {
              commit('loginError', errors);
              localStorage.removeItem('auth-token');
              reject(errors);
            });
          });
    },
    logout: ({commit, dispatch}) => {
        return new Promise((resolve, reject) => {
          commit('logout');
          localStorage.removeItem('auth-token');
          localStorage.removeItem('profile');
          resolve();
        });
    },
};

const mutations = {
    loginRequest: (authState) => {
        authState.status = 'attempting authentication request';
    },
    loginSuccess: (authState, token, user) => {
        authState.status = { loggedIn: true };
        authState.user = user;
        authState.token = token;
        
    },
    loginError: (authState) => {
        authState.token = '';
        authState.status = {};
        authState.user = {};
    },
    logout: (authState) => {
        authState.token = '';
        authState.status = {};
        authState.user = {};
    },
};

export default {
    state,
    getters,
    actions,
    mutations,
};

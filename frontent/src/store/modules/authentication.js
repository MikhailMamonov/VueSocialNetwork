
import { authService } from '../../services/auth.service';

const user = localStorage.getItem("user");

 const state = { token: localStorage.getItem('auth-token') || '',
                 status: '',
                 user: user? JSON.parse(user): {}
                };
const getters = {
    isAuthenticated: (authState) => { console.log("isAuthenticated", !!authState.token); return !!authState.token},
    authStatus: (authState) => authState.status,
    authToken: (authState) => authState.token,
    user: (authState) => {console.log("user", authState.user); return authState.user},
};

const actions = {
    login: ({commit, dispatch} , credentials) => {
        return new Promise((resolve, reject) => {
            commit('loginRequest');
            authService.login(credentials)
            .subscribe((result) => {
              localStorage.setItem('auth-token', result.token); // stash the auth token in localStorage
              localStorage.setItem('user', JSON.stringify(result.user));
              console.log("beforeLoginSuccess", result.user, result.token);
              commit('loginSuccess', {token: result.token, user: result.user});
              
              console.log(result);
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
          localStorage.removeItem('user');
          resolve();
        });
    },
};

const mutations = {
    loginRequest: (authState) => {
        authState.status = 'attempting authentication request';
    },
    loginSuccess: (authState, data) => {
        console.log("loginSuccess", data.profile, data.token);
        authState.status = { loggedIn: true };
        authState.user = data.user;
        authState.token = data.token;
        
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

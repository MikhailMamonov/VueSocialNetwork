const LOGIN_REQUEST =  (authState) => {
        authState.status = 'attempting authentication request';
    };
const LOGIN_SUCCESS =  (authState, data) => {
        console.log("LOGIN_SUCCESS", data.user, data.token);
        authState.status = { loggedIn: true };
        authState.user = data.user;
        authState.token = data.token;
        
    };
const LOGIN_ERROR= (authState) => {
        authState.token = '';
        authState.status = {};
        authState.user = {};
    };
const LOGOUT =  (authState) => {
        authState.token = '';
        authState.status = {};
        authState.user = {};
    };

export {
    LOGIN_REQUEST,
    LOGIN_SUCCESS,
    LOGIN_ERROR,
    LOGOUT


}
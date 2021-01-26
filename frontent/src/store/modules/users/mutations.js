const USER_REQUEST = (userState) => {
          userState.status = 'attempting request for user user data';
      };
const GET_USERS = (userState) => {
        userState.status = 'attempting request for users List data';
      };
const GET_USERS_SUCCESS = (userState, users) => {
        userState.status = 'success';
        userState.users = users;
      };
const GET_USERS_ERROR = (userState) => {
        userState.status = 'error';
      };
      const EDIT_USER = (userState) => {
        userState.status = 'attempting request update user';
      };
      
      const EDIT_USER_ERROR = (userState) => {
        userState.status = 'error';
      };
  
      const USER_REQUEST_ERROR = (userState) => {
        userState.status = 'error';
      };

      const SET_CURRENT_USER = (userState, currentUser) => {
        userState.status = 'success';
        userState.currentUser= currentUser;
        localStorage.setItem('user', JSON.stringify(currentUser));
        
      }

  export {
    USER_REQUEST,
    GET_USERS,
    GET_USERS_SUCCESS,
    GET_USERS_ERROR,
    EDIT_USER,
    EDIT_USER_ERROR,
    USER_REQUEST_ERROR,
    SET_CURRENT_USER
  }
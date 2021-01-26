import { usersService } from '../../../services/users.service';

const userRequest = ({commit, dispatch}, data) => {
        commit('USER_REQUEST');
        usersService.getUserById(data.id)
        .then((result) => {
          dispatch('setCurrentUser', result.data.user);
        },
      (errors) => {
        commit('USER_REQUEST_ERROR');
      });
    };

const getUsers = ({commit, dispatch}) => {
      commit('GET_USERS');
      usersService.getUsers()
      .then((result) => {
        commit('GET_USERS_SUCCESS', result.data.users);
        dispatch('friends/setFriendRequests',result.data.friendRequests, { root: true });
        console.log("users",result.data.users)
        console.log("friendRequests",result.data.friendRequests)
      },
    (errors) => {
      commit('GET_USERS_ERROR');
    });
  };

const editUser = ({commit,dispatch}, data)=> {
    commit('EDIT_USER');
    usersService.editUser(data.form, data.id)
    .then((result) => {
      dispatch('setCurrentUser', result.data.user);
      console.log(result);                
  }).catch((e) => {
      commit('EDIT_USER_ERROR');
      console.log(e);
  });
};


const setCurrentUser = ({commit, dispatch}, currentUser)=> {
  console.log('SET_CURRENT_USER', currentUser);
  commit('SET_CURRENT_USER', currentUser);
}


export{
    userRequest,
    getUsers,
    editUser,
    setCurrentUser
}
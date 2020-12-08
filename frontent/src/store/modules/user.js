import { profileService } from '../../services/profile.service';

import Vue from 'vue';

var  profile= function() 
  {
    console.log('ihiuhi');
    { if (localStorage.getItem('profile')) {
      try {
        return JSON.parse(localStorage.getItem('profile'));
      } catch(e) {
        localStorage.removeItem('profile');
      }
    } else return {};}
  } 

const state = { profile: {}, status: '' };

const getters = {
    profile: (userState) => { 
      console.log('ihiuhi');
      console.log(userState.profile); return userState.profile;},
};

const actions = {
    userRequest: ({commit, dispatch}) => {
        commit('userRequest');
        profileService.get()
        .subscribe((result) => {
          commit('userSuccess', result);
        },
      (errors) => {
        commit('userError');
        dispatch('authentication/authLogout', null, { root: true });
      });
    },
};

const mutations = {
    userRequest: (userState) => {
        userState.status = 'attempting request for user profile data';
    },
    userSuccess: (userState, userResp) => {
      userState.status = 'success';
      userState.profile= userResp;
    },
    userError: (userState) => {
      userState.status = 'error';
    },

};

export default {
    state,
    getters,
    actions,
    mutations,
};

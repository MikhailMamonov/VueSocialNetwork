import Vue from 'vue';
import Vuex from 'vuex';

import auth from './modules/authentication';
import user from './modules/user';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {

  },
  mutations: {

  },
  actions: {

  },
  modules: {
    authentication: {
      namespaced: true,
      state: auth.state,
      mutations: auth.mutations,
      getters: auth.getters,
      actions: auth.actions,
 },
    user: {
      namespaced: true,
      state: user.state,
      actions: user.actions,
      mutations: user.mutations,
      getters: user.getters,
  },
},
});

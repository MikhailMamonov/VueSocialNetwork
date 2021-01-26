import Vue from 'vue';
import Vuex from 'vuex';

import auth from './modules/auth/index';
import users from './modules/users/index';
import posts from './modules/posts/index';
import friends from './modules/friends/index';

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    auth: auth,
    users: users,
    posts: posts,
    friends: friends
},
});

import Vue from 'vue';
import Router from 'vue-router';
import store from './store/store';
import vDashboardRoot from './views/dashboard/v-root.vue';
import DashboardHome from './views/dashboard/v-home.vue';
import vLoginForm from '@/components/profile/account/v-login-form.vue';
import vRegisterForm from '@/components/profile/account/v-registration-form.vue';
import vProfile from './components/profile/v-profile.vue';
import vAbout from './components/v-about.vue';
import vHome from './components/v-home.vue';
import vPosts from './components/posts/v-posts';
import vUsers from './components/users/v-users';
import vFriends from './views/friends/v-friends';
import vUserProfileSettings from '@/components/profile/settings/v-user-profile-settings';



Vue.use(Router);

const router = new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'home',
      component: vHome,

    },
    {
      path: '/settings/profile',
      component: vUserProfileSettings,
      meta: { requiresAuth: true },
    },
    {
      path: '/current_user',
      name: 'current_user',
      component: vProfile,
      meta: { requiresAuth: true },
    },
    {
      path: '/friends',
      name: 'friends',
      component: vFriends,
      meta: { requiresAuth: true },
    },
    {
      path: '/login',
      name: 'login',
      component: vLoginForm,
    },
    {
      path: '/dashboard',
      component: vDashboardRoot,
      children: [
        {
          path: 'home',
          component: DashboardHome,
          meta: { requiresAuth: true },
        },
      ],
    },
    {
      path: '/register',
      name: 'register',
      component: vRegisterForm,
    },
    {
      path: '/about',
      name: 'about',
      component: vAbout,
    },
    {
      path: '/users',
      name: 'users',
      component: vUsers,
      meta: { requiresAuth: true },
    },
    {
      path: '/posts',
      name: 'posts',
      component: vPosts,
      meta: { requiresAuth: true },
    },
  ],
});

router.beforeEach((to, from, next) => {

  if (to.matched.some((record) => record.meta.requiresAuth)) {

    if (store.getters['auth/isAuthenticated']) {
      console.log(store.getters['auth/isAuthenticated']);
      next();
      return;
    }
    next('/login') }
    else {
      next();
  }
});

export default router;
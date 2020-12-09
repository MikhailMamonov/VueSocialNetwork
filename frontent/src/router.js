import Vue from 'vue';
import Router from 'vue-router';
import store from './store/store';
import DashboardRoot from './views/dashboard/Root.vue';
import DashboardHome from './views/dashboard/Home.vue';
import LoginForm from './views/account/LoginForm.vue';
import RegisterForm from './views/account/RegistrationForm.vue';
import Profile from './views/users/Profile.vue';
import About from './views/About.vue';
import Home from './views/Home.vue';


Vue.use(Router);

const router =  new Router({
    mode: 'history',
    routes: [   
    {
      path: '/',
      name: 'home',
      component: Home,
                  
    },
    {
      path: '/profile',
      name: 'profile',
      component: Profile,
                  meta: { requiresAuth: true },
    },
      {
        path: '/login',
        name: 'login',
        component: LoginForm,
      },
      {
        path: '/dashboard',
        component: DashboardRoot,
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
        component: RegisterForm,
      },
      {
      path: '/about',
      name: 'about',
      component: About,
    },
    ],
  });

  router.beforeEach((to, from, next) => {
    if (to.matched.some((record) => record.meta.requiresAuth)) {

      if (!store.getters['authentication/isAuthenticated']) {
        console.log(store.getters['authentication/isAuthenticated']);
        next({
          path: '/login',
          query: { redirect: to.fullPath },
        });
      } else {
        console.log(store.getters['authentication/isAuthenticated']);
        next();
      }
    } else {
 
      next(); 
    }
  });
  
  export default router;
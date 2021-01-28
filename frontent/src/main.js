import Vue from 'vue'
import App from './App.vue'
import Axios from 'axios';
import router from './router';
import store from './store/store';
import vuetify from './plugins/vuetify';

Vue.prototype.$http = Axios;
Axios.defaults.baseURL = process.env.API_ENDPOINT;

Vue.config.productionTip = false;


new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app');


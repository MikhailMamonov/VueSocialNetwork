<template>
 <div id="app">
    <v-nav /> 
    <div class="container mt-3 v-main-wrapper">
      <router-view />
    </div>
  </div>
</template>

<script>
import vNav from '@/components/v-nav.vue'; 

export default {
  name: 'App',
  components: {
    vNav
  },
  created: function () {

    //init auth token header 
    this.$http.interceptors.request.use((config) => {

      const token =  localStorage.getItem('token') || ''
      if (token!=='') {
        
        console.log("authToken",token)
        config.headers['Authorization'] = 'Bearer ' + token;
      }
        return config;
    }, (err) => {
      return Promise.reject(err);
    });
    // Processing unauthtorized error 401
    this.$http.interceptors.response.use(undefined, function (err) {
      alert("unauthtorized error 401");
      return new Promise(function (resolve, reject) {
        if (err.status === 401 && err.config && !err.config.__isRetryRequest) {
          this.$store.dispatch('auth/LOGOUT');
        }
        throw err;
      });
    });
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;

}

 .v-main-wrapper {
    margin: 0 auto;
  }
</style>

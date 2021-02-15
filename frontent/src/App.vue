<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
    >

    <v-app-bar-nav-icon></v-app-bar-nav-icon>
    <v-tabs>
    <v-tab to="/">Home</v-tab>
    <v-tab :to="{ name: 'profile', params: { userId: currentUser.id } }"> Profile</v-tab>
    <v-tab to="/friends">Friends</v-tab>
    <v-tab to="/users">Users</v-tab>
    <v-tab to="/posts">Posts</v-tab>
  </v-tabs>
      
      <v-spacer></v-spacer>
 <v-btn text exact to="/register"  v-show="!isAuthenticated">
         Email signup
       </v-btn>
        <v-btn text exact to="/login"  v-show="!isAuthenticated">
         Login
       </v-btn>
        <v-btn text exact href="javascript:void(0)" v-on:click="logoff" v-show="isAuthenticated">
         Logoff {{this.firstName}}
       </v-btn>
    </v-app-bar>

    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'App',

  data: () => ({
    user : {}
  }),
  methods:{ 
      logoff() {
     this.$store.dispatch('auth/LOGOUT').then(() => {
       console.log()
        this.$router.push('/');
     });
  }
  },
  computed:{ 
  ...mapGetters({
    isAuthenticated: 'auth/isAuthenticated',
    currentUser: 'users/currentUser'
  }),
  firstName(){
    return this.currentUser? this.currentUser.firstName: "";
  }
  },
   mounted() {
     console.log("currentUser", this.currentUser);
     if(this.isAuthenticated){
            this.$store.dispatch('users/userRequest', {id: this.currentUser.id})
            .then(() => {
              console.log('success');
            }).catch(e => console.log('error'));
            }

  },
  created() {
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
    
        
  }
};
</script>

<template>
 <nav class="navbar navbar-expand navbar-dark bg-dark">
      <router-link to="/" class="navbar-brand">bezKoder</router-link>
      <div class="navbar-nav mr-auto">
        <li class="nav-item">
          <router-link to="/" class="nav-link">Home</router-link>
        </li>
        <li class="nav-item">
          <router-link :to="{ name: 'profile', params: { userId: currentUser.id }}" class="nav-link">Profile</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/friends" class="nav-link">Friends</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/add" class="nav-link">Messages</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/users" class="nav-link">Users</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/posts" class="nav-link">Posts</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/about" class="nav-link">About</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/register"  class="navbar-item" v-show="!isAuthenticated">Email signup</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/login" class="nav-link" v-show="!isAuthenticated">Login</router-link>
        </li>
        <li class="nav-item"> 
          <a class="navbar-item" href="javascript:void(0)" v-on:click="logoff" v-show="isAuthenticated">Logoff {{this.firstName}}</a>
        </li>
      </div>
    </nav>
</template>

<script>

import { mapGetters } from 'vuex';

export default {
    name:'Nav',
  methods:{ 
      logoff() {
     this.$store.dispatch('auth/LOGOUT').then(() => {
       console.log("logoff success");
     });
  }
  },
  data(){
    return{
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
     debugger;
     console.log("currentUser", this.currentUser);
     if(this.isAuthenticated){
            this.$store.dispatch('users/userRequest', {id: this.currentUser.id})
            .then(() => {
              console.log('success');
            }).catch(e => console.log('error'));
            }

  }
}
</script>


<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.router-link-exact-active {
  color: #209cee !important;
}
</style>

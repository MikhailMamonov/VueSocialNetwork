<template>

        <v-list-item :key="user.firstName">
          <v-list-item-icon>
          <v-icon
            color="pink"
          >
            mdi-star
          </v-icon>
        </v-list-item-icon>
         <v-list-item-avatar>
          <v-img :src="user.imageSrc"></v-img>
        </v-list-item-avatar>
        <v-list-item-content>
          <v-list-item-title v-text="user.firstName+' '+ user.lastName"></v-list-item-title>
        </v-list-item-content>

         
          
              <button class="btn btn-danger" v-if="isFriend" @click="deleteFriend()">Delete from friends</button>
              <button class=" btn btn-danger" v-else-if="isFriendRequested" @click="cancelRequest()">Cancel request</button>
              <button class=" btn btn-primary" v-else-if="user.id!==currentUser.id" @click="addToFriend()">Add to Friend</button>
              <router-link v-else :to="{ name: 'profile', params: { userId: currentUser.id }}" class=" btn btn-info" tag="button">Edit profile</router-link>
        </v-list-item>
</template>

<script>
import { mapGetters } from 'vuex';
export default {
  name: "v-users-item",
  props: ["user"],
  computed:{
    ...mapGetters({
      currentUser: 'users/currentUser'
    }),
    isFriend() {
      return this.$store.getters['friends/isFriend'](this.user.id);
      
    },
    isFriendRequested() {
      const result =  this.$store.getters['friends/isFriendRequested']({receiverId:this.user.id, senderId:this.currentUser.id});
      console.log("result",result);
      return result;

    },
  },

  methods:{
    addToFriend(){
      console.log("current User",  this.currentUser);
      this.$store.dispatch('friends/addToFriends', {senderId:this.currentUser.id, receiverId:this.user.id})
            .then(() => {
              console.log('success');
            }).catch(e => this.hasError = true);
            
    },

    cancelRequest(){
      console.log("current User",  this.currentUser);
      this.$store.dispatch('friends/cancelFriendRequest', {senderId:this.currentUser.id, receiverId:this.user.id})
            .then(() => {
              console.log('success');
            }).catch(e => this.hasError = true);
          
    },
    
    deleteFriend(){
      console.log("current User",  this.currentUser);
      this.$store.dispatch('friends/deleteFriend', this.user.id)
            .then(() => {
              console.log('success');
            }).catch(e => this.hasError = true);
    }
  }
};
</script>

<style  lang="scss">
.container{
  padding: 5px;
.flex-column {
  background-color: gainsboro;
  .col {
    display: flex;
    align-items: center;
    justify-content: center;
    
    p{
      flex: 0 0 100%;
      text-align: center;
      background-color: goldenrod;
    }

    img{
      width:200px;
      height:200px;
    }
  }

 
}}
</style>
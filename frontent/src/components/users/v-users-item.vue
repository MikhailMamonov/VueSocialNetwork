<template>

        <li>
          <div class="container">
          <div class="row flex-column">
              <div class="col ">
                <img :src="user.imageSrc"/>
            </div>
            <div class="col">
              <p>{{user.firstName}}</p>
              </div>
            <div class="col">
                <p>{{ user.lastName }}</p>
              </div>
              <button class="btn btn-danger" v-if="isFriend" @click="deleteFromFriends()">Delete from friends</button>
              <button class=" btn btn-danger" v-else-if="isFriendRequested" @click="cancelRequest()">Cancel request</button>
              <button class=" btn btn-primary" v-else-if="user.id!==currentUser.id" @click="addToFriend()">Add to Friend</button>
              <button class=" btn btn-info" v-else >Edit profile</button>
          </div>
           
          </div>
        </li>
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
    
    deleteFromFriends(){
      console.log("current User",  this.currentUser);
      this.$store.dispatch('friends/deleteFromFriends', {senderId:this.currentUser.id, receiverId:this.user.id})
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
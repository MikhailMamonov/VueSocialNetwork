<template>
        
           <v-list >
             <v-list-item-group
              active-class="pink--text"
              multiple
            >
        <template v-for="(user, index) in users" >
          
          <v-list-item :key="user.id" @click="goToProfile(user.id)">
            <template v-slot:default="{ active }">
              <v-list-item-avatar>
            <v-img :src="user.imageSrc"></v-img>
          </v-list-item-avatar>
              <v-list-item-content>
                <v-list-item-title v-text="user.firstName"></v-list-item-title>

                <v-list-item-subtitle v-text="user.lastName"></v-list-item-subtitle>
              </v-list-item-content>
              <v-list-item-action>
                <v-list-item-action-text v-text="user.userName"></v-list-item-action-text>
                <v-btn v-if="tab ==='Friends'" @click="deleteFriend(user.id)">Delete</v-btn>
                <v-btn v-if="tab ==='Friends online'" @click="deleteFriend(user.id)">Delete</v-btn>
                <v-btn v-if="tab ==='Sended Requests'" @click="cancelRequest(user.id)">Cancel Request</v-btn>
                <v-btn v-if="tab ==='Received requests'" @click="accept(user.id)">Accept</v-btn>
                <v-btn v-if="tab ==='Received requests'" @click="decline(user.id)">Decline</v-btn>
                <v-icon
                  v-if="!active"
                  color="grey lighten-1"
                >
                  mdi-star-outline
                </v-icon>

                <v-icon
                  v-else
                  color="yellow darken-3"
                >
                  mdi-star
                </v-icon>
              </v-list-item-action>
            </template>
          </v-list-item>

          <v-divider
            v-if="index < users.length - 1"
            :key="index"
          ></v-divider>
        </template>
      </v-list-item-group>
    </v-list>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
      name:"v-friend-list",
      props:{
           tab:String
      },
      computed:{
           ...mapGetters({
      currentUser: 'users/currentUser'
    }),
          users(){
            if(this.tab ==='Friends'){
              return this.$store.state.friends.friends
            }
            else if(this.tab ==='Sended Requests'){
              const receivers =  this.$store.getters['friends/getSendedRequests']({senderId:this.currentUser.id});
      console.log("receivers",receivers);
              return receivers;
            }
            else if(this.tab ==='Received requests'){
              const senders =  this.$store.getters['friends/getReceivedRequests']({receiverId:this.currentUser.id});
              console.log("senders",senders);
              return senders;
            }
            return [];
          }
        },
        methods:{
          deleteFriend(userId){
             this.$store.dispatch('friends/deleteFriend',userId)
            .catch(e => console.log(e));
          },
          
          cancelRequest(userId){
            this.$store.dispatch('friends/cancelFriendRequest', {senderId:this.currentUser.id, receiverId:userId})
            .catch(e => this.hasError = true);
          },
          accept(userId){
            this.$store.dispatch('friends/accept', {senderId:userId, receiverId:this.currentUser.id})
            .catch(e => console.log(e));
            },
          decline(userId){
            this.$store.dispatch('friends/decline', {senderId:this.currentUser.id, receiverId:userId})
            .catch(e => console.log(e));},

          goToProfile(userId){
            console.log(userId);
            this.$router.push({ name: 'profile', params: { userId: userId } })
          }
        }
    }
</script>

<style lang="scss" scoped>

</style>
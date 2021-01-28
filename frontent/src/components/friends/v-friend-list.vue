<template>
        
           <v-list >
             <v-list-item-group
              active-class="pink--text"
              multiple
            >
 <v-subheader> {{tab}}</v-subheader>
        <template v-for="(user, index) in users" >
          
          <v-list-item :key="user.id">
            <template v-slot:default="{ active }">
              <v-list-item-content>
                <v-list-item-title v-text="user.firstName"></v-list-item-title>

                <v-list-item-subtitle v-text="user.lastName"></v-list-item-subtitle>
              </v-list-item-content>

              <v-list-item-action>
                <v-list-item-action-text v-text="user.userName"></v-list-item-action-text>

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
        data(){
          return {
          }
        },
        computed:{
           ...mapGetters({
      currentUser: 'users/currentUser'
    }),
          users(){
            if(this.tab ==='Friends'){
              return this.$store.state.friends.friends
            }
            else if(this.tab ==='Friends online'){
              return this.$store.state.users.users
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
          tabHeadSlotName(tabName){
            return `tab-head-${tabName}`;
          }

        }
    }
</script>

<style lang="scss" scoped>

</style>
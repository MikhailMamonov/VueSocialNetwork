<template>
<v-container class="grey lighten-5">
    <v-row class="fill-height ">
      <v-col sm="3">
        <v-card >
  <v-img :src="getImageSrc" height="300px" width="300px"  />

  <v-card-title>{{name()}}</v-card-title>
  <v-card-actions>
    <v-btn
        text
        color="teal accent-4"
        to="/settings/profile"
      >
        Edit
      </v-btn>
  </v-card-actions>
        </v-card>
        <v-card
      class="d-flex flex-column"
      color="grey lighten-2"
      flat
      tile
      
    >
      <v-card
        class="pa-2"
        outlined
        tile
      >
        Friends
      </v-card>
      <v-card
        class="pa-2"
        outlined
        tile
      >
        Friends Online
      </v-card>
      <v-card
        class="pa-2"
        outlined
        tile
      >
        Following
      </v-card>
      <v-card
        class="pa-2"
        outlined
        tile
      >
        Videos
      </v-card>
    </v-card>
      </v-col >
      <v-col sm="9" >
        <v-row>
           <v-card 
          class=" fill-height"
        >
          <v-card-title>{{name()}}</v-card-title>
          <v-card-content>
         <v-simple-table dense>
           <tbody>
        <tr
        >
          <td>Email</td>
          <td>{{profile.email}}</td>
        </tr>
        <tr
        >
          <td>Id</td>
          <td>{{profile.id}}</td>
        </tr>
        <tr
        >
          <td>Name</td>
          <td>Bob</td>
        </tr>
      </tbody>
  </v-simple-table>
          </v-card-content>
        </v-card>
        </v-row>
        <v-row class="pt-1">
            <v-card>
          <v-responsive  >
                <div class="d-flex justify-content-around caption ">
                  <div>
                    <div class="font-weight-medium">
                      362
                    </div>
                    <div class="grey--text mb-2">
                      Friends
                    </div>

                  </div>

                  <div>
                                   <div
                      class="font-weight-medium"
                      v-text="600"
                    ></div>
                    <div class="grey--text mb-2">
                      Followers
                    </div>
                  </div>

                  <div>
                       <div
                      class="font-weight-medium"
                      v-text="1000"
                    ></div>
                    <div class="grey--text mb-2">
                      Photos
                    </div>

                 
                  </div>

                  <div>
                    <div
                      class="font-weight-medium"
                      v-text="44"
                    ></div>
                    <div class="grey--text text-darken-1 mb-2">
                      tags
                    </div>
                  </div>
                  <div>
                    
                    <div
                      class="font-weight-medium"
                      v-text="570"
                    ></div>
                    <div class="grey--text text-darken-1 mb-2">
                      Videos
                    </div>

                  </div>
                  <div>
                    <div
                      class="font-weight-bold"
                      v-text="1111"
                    ></div>
                    <div class="grey--text text-darken-1 mb-2">
                      Tracks
                    </div>
                  </div>
                </div>
              </v-responsive>
              </v-card>
        </v-row>
        <v-row class="pt-1">
            <v-card>
              <v-card-title>My Photos</v-card-title>
              <v-card-content>
                <v-row class="d-flex justify-content-center mb-5">
                <v-col v-for="n in 4"
      :key="n"
      class="d-flex child-flex"
      cols="2"
    >
    <v-img
        :src="`https://picsum.photos/500/300?image=${n * 5 + 10}`"
        :lazy-src="`https://picsum.photos/10/6?image=${n * 5 + 10}`"
        aspect-ratio="1"
        class="grey lighten-2"
      >
        <template v-slot:placeholder>
          <v-row
            class="fill-height ma-0"
            align="center"
            justify="center"
          >
            <v-progress-circular
              indeterminate
              color="grey lighten-5"
            ></v-progress-circular>
          </v-row>
        </template>
      </v-img>
            </v-col>
            </v-row>
              </v-card-content>
              </v-card>
              
        </v-row>
      </v-col>
    </v-row>
    <v-row no-gutters>
      <v-col
        cols="8"
    sm="3"
      >
      <v-card
              class="pa-2"
              outlined
              style="background-color: lightgrey;"
              tile
            >
              Level 2: .col-8 .col-sm-6
      </v-card>
      </v-col>
      <v-col cols="4" sm="6">
        <v-card
              class="pa-2"
              outlined
              style="background-color: lightgrey;"
              tile
            >
              Level 3: .col-4 .col-sm-6
            </v-card>
      </v-col>
    </v-row>
  </v-container>

</template>

<script >
/* import { mapGetters } from 'vuex';
import { mapState } from 'vuex'; */
// import vPosts from '@/components/posts/v-posts.vue';


export default {
    name: 'v-profile',
    data: function () {
    return { 
      isBusy: false,
      isModalVisible: false,
      user:{}
       };  
  },
  methods:{
      name() {
        console.log("user", this.profile);
      return this.profile.firstName + ' ' + this.profile.lastName;
  },
  showModal() {
        this.isModalVisible = true;
      },
      closeModal() {
        this.isModalVisible = false;
      }
  },
  computed:{
/*     ...mapState({
            //profile: state => state.auth.user
            }), */
   /*    ...mapGetters({
        profile: 'users/currentUser'
      }), */
      getImageSrc () {
        return 'data:image/jpeg;base64,' + this.profile.profilePicture;
      },
      profile(){
        console.log("$route.params.userId",this.$route.params.userId);
        return this.$store.getters['users/userById']({userId:this.$route.params.userId});
      },
      cols () {
        const { lg, sm } = this.$vuetify.breakpoint
        return lg ? [3, 9] : sm ? [9, 3] : [6, 6]
      },
  },
  // components: {
  //   vPosts
  // },

   created() {
     console.log("v-profile created");
     this.isBusy = true;      
  }
}
</script>

<style scoped>

</style>
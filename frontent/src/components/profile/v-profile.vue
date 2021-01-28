<template>
 <v-card
    max-width="600"
    class="mx-auto mt-12"
    elevation="12"
  >
  <v-img
      :src="getImageSrc"
      height="500px"    
    >
    <v-row class="fill-height ">
    <v-card-title>
          <v-btn
            icon
          >
            <v-icon>mdi-chevron-left</v-icon>
          </v-btn>

          <v-spacer></v-spacer>

          <v-btn to="/settings/profile"
            
            icon
            class="mr-4"
          >
            <v-icon>mdi-pencil</v-icon>
          </v-btn>

          <v-btn
            icon
          >
            <v-icon>mdi-dots-vertical</v-icon>
          </v-btn>
        </v-card-title>

        <v-spacer></v-spacer>

        <v-card-title class="dark--text pl-12 pt-12">
          <div class="display-1 pl-12 pt-12">
            {{name()}}
          </div>
        </v-card-title>
      </v-row>
    </v-img>
    <v-list two-line>
      <v-list-item>
        <v-list-item-icon>
          <v-icon color="indigo">
            mdi-phone
          </v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>(650) 555-1234</v-list-item-title>
          <v-list-item-subtitle>Mobile</v-list-item-subtitle>
        </v-list-item-content>

        <v-list-item-icon>
          <v-icon>mdi-message-text</v-icon>
        </v-list-item-icon>
      </v-list-item>

      <v-list-item>
        <v-list-item-action></v-list-item-action>

        <v-list-item-content>
          <v-list-item-title>(323) 555-6789</v-list-item-title>
          <v-list-item-subtitle>Work</v-list-item-subtitle>
        </v-list-item-content>

        <v-list-item-icon>
          <v-icon>mdi-message-text</v-icon>
        </v-list-item-icon>
      </v-list-item>

      <v-divider inset></v-divider>

      <v-list-item>
        <v-list-item-icon>
          <v-icon color="indigo">
            mdi-email
          </v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>aliconnors@example.com</v-list-item-title>
          <v-list-item-subtitle>Personal</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-list-item>
        <v-list-item-action></v-list-item-action>

        <v-list-item-content>
          <v-list-item-title>ali_connors@example.com</v-list-item-title>
          <v-list-item-subtitle>Work</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-divider inset></v-divider>

      <v-list-item>
        <v-list-item-icon>
          <v-icon color="indigo">
            mdi-map-marker
          </v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>1400 Main Street</v-list-item-title>
          <v-list-item-subtitle>Orlando, FL 79938</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
    </v-list>



            
      <!--   <v-posts /> -->


        
 </v-card>
</template>

<script >
import { mapGetters } from 'vuex';
import { mapState } from 'vuex';
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
    ...mapState({
            //profile: state => state.auth.user
            }),
      ...mapGetters({
        profile: 'users/currentUser'
      }),
      getImageSrc () {
        return 'data:image/jpeg;base64,' + this.profile.profilePicture;
      }
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
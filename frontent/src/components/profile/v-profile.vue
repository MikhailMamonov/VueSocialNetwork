<template>
<div class="row"> 
<div class="col-sm-3 well text-center">
  <div class="well">
            <p><a ><strong >{{name()}}</strong></a></p>
        </div>
        <div>
          <div>Image</div>
           <img :src="getImageSrc" class="img-circle" height="100" width="100" >
        </div>
  <div class="well">
             <router-link to="/settings/profile" tag="button" class="btn btn-primary">
             Edit profile
             </router-link>
        </div>
        
            
        <v-posts />

  </div>
        

 </div>
</template>

<script >
import { mapGetters } from 'vuex';
import { mapState } from 'vuex';
import vPosts from '@/components/posts/v-posts.vue';


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
  components: {
    vPosts
  },

   created() {
     console.log("v-profile created");
     this.isBusy = true;      
  }
}
</script>

<style scoped>

</style>
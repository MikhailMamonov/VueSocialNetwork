<template>
  <div id="editForm" class="ui stackable grid container">
    <v-spinner @loading="loading"/>
        <h2 class="font-weight-semibold mb-4">Edit Profile</h2>
        <form class="contact-form" @submit.prevent="submitForm">
          <fieldset :disabled="loading">
            <div class="contact-form-success alert alert-success mt-4" v-if="success">
              <strong>Success!</strong> Your profile is edited.
            </div>

            <div class="contact-form-error alert alert-danger mt-4" v-if="error">
              <strong>Error!</strong> There was an error sending your request.
            </div>
          <div class="form-row" >
            <div class="form-group col">
            <label>First Name</label>
            <input type="text" name="firstName" v-model="firstName" >
          </div>
          </div>
          <div class="form-row" >
            <div class="form-group col">
            <label>Last Name</label>
            <input type="text" name="lastName" v-model="lastName" >
            </div>
          </div>
          <div class="form-row" >
            <div class="form-group col">
             <img class="img-preview" :src="getImageSrc" alt="Profile Image" >
            <br>
              <input type="file" @change="chooseImage" />
            </div>
          </div>
          <div class="form-row">
            <div class="form-group col">
          <button class="ui button primary">Update profile</button>
            </div>
          </div>
          </fieldset>
        </form>
  </div>
</template>

<script>

import { mapState, mapGetters } from 'vuex';
import vSpinner from '@/components/v-spinner.vue';

export default {
    name: 'v-user-profile-settings',
    components: {vSpinner},
    data () {
      return {
        file:null,
        success: false,
        error: false,
        loading: false,
        imageSrc:'',
        firstName: '',
        lastName: '',
        defaultImage: 'https://png.pngtree.com/png-vector/20200614/ourmid/pngtree-businessman-user-avatar-character-vector-illustration-png-image_2242909.jpg',
        inputName: "file",
        buttonStyle: {
					backgroundColor:"#037B38",
					color: "#ffffff",
				}
      }
    },
     computed: {
       ...mapGetters({
            profile: 'users/currentUser'
            }),
        getImageSrc () {
          return this.imageSrc !== null && this.imageSrc!=='' 
                ? this.imageSrc : this.defaultImage
            }
      },
      mounted () {
        console.log("profile",this.profile);
        this.fetchAuthenticatedUser();
      },
      methods: {
        fetchAuthenticatedUser () {
          console.log("profile",this.profile);
          this.firstName = this.profile.firstName;
          this.lastName = this.profile.lastName;
          this.imageSrc = 'data:image/jpeg;base64,' + this.profile.profilePicture;
          console.log("this.imageSrc",this.imageSrc);
            },
        chooseImage(e) {
          if(e.target.files && e.target.files[0]){
            this.file = e.target.files[0];
            const reader = new FileReader()
            reader.onload = (e) => {
            this.imageSrc = e.target.result
          }
            reader.readAsDataURL(this.file);
          }
          else{
            this.file = null;
            this.imageSrc = this.defaultImage;
          }
          },
          submitForm()
          {
            this.loading = true;

            let formData = new FormData();
            
            formData.append('imageFile', this.file);
            formData.append('id', this.profile.id);
            formData.append('firstName', this.firstName);
            formData.append('lastName', this.lastName);
            formData.append('profilePicture', this.profile.profilePicture)
            this.$store.dispatch('users/editUser', {form: formData, id: this.profile.id})
              .then(() => {
                console.log('success');
                this.success = true;
              })
              .catch(e => {
                this.error = true;
                console.log(this.error);
                })
                .finally(() => {
                  this.loading = false;
          });
          }
        }
    }
</script>

<style scoped>
.img-preview {
		height: 100px;
		width: 100px;
		margin-bottom: 5px;
	}

  #editForm {
  /* Components Root Element ID */
  position: relative;
}


</style>
<template>
  <section class="section">
     <v-layout align-center justify-center>
          <v-flex xs12 sm8 md4>
            <v-card class="elevation-12">
              <v-toolbar dark color="primary">
                <v-toolbar-title>Register</v-toolbar-title>
                <v-spacer></v-spacer>
               
              </v-toolbar>
              <v-card-text>
                <v-form>
                  <v-text-field prepend-icon="person" v-model="user.email" label="Email" type="email"></v-text-field>
                  <v-text-field prepend-icon="person" v-model="user.userName" label="UserName" type="userName"></v-text-field>
                  <v-text-field id="password" prepend-icon="lock" v-model="user.password" label="Password" type="password"></v-text-field>
                  <v-text-field id="password" prepend-icon="lock" v-model="user.confirmPassword" label="ConfirmPassword" type="password"></v-text-field>
                  <v-text-field prepend-icon="person" v-model="user.firstName" label="First name" type="text"></v-text-field>
                  <v-text-field prepend-icon="person" v-model="user.lastName" label="Last name" type="text"></v-text-field>
                  
                  <v-text-field prepend-icon="person" v-model="user.age" label="Age" type="number"></v-text-field>
                  <v-text-field prepend-icon="person" v-model="user.location" label="Location" type="text"></v-text-field>
                  
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="primary" type='submit' @click='registerUser'>Signup</v-btn>
              </v-card-actions>
            </v-card>
          </v-flex>
        </v-layout>

  </section>
</template>
<script>
import { accountService } from './../../../services/account.service';

export default {
  name: 'v-registration-form',
  data: function(){  
    return { 
      isBusy: false,
      errors: '',
      user:{email: '',password: '', confirmPassword:'', age: 0, userName:'noname',photo:'https://www.cjoint.com/doc/16_06/FFdlyIDXEEm_username.jpg',
             firstName:'noname',lastName: 'noname',location: ''}
       };
       },
  methods:{
    registerUser(){
      this.isBusy = true;
      accountService.register(this.user)
       .then((result) => {
         this.$router.push('/');
       }).catch((errors) =>  this.errors = errors).finally(() => this.isBusy = false);            
     }
}
}
</script>

<style lang="scss" scoped>
</style>
 
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
                <v-form v-model="valid">
                  <v-text-field  v-model="user.email" :rules="emailRules" label="Email" type="email"></v-text-field>
                  <v-text-field  v-model="user.userName" label="UserName" :rules="nameRules" type="text"></v-text-field>
                  <v-text-field  v-model="user.password" label="Password" :rules="passwordRules" type="password"></v-text-field>
                  <v-text-field  v-model="user.confirmPassword" label="ConfirmPassword" :rules="passwordRules" type="password"></v-text-field>
                  <v-text-field  v-model="user.firstName" label="First name" :rules="nameRules" type="text"></v-text-field>
                  <v-text-field  v-model="user.lastName" label="Last name" :rules="nameRules" type="text"></v-text-field>
                  
                  <v-text-field v-model="user.age" label="Age" :rules="ageRules" type="number"></v-text-field>
                  <v-text-field v-model="user.location" label="Location" type="text"></v-text-field>
                  
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn :disabled="!valid" color="primary" type='submit' @click='registerUser'>Signup</v-btn>
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
      passwordRules: [
                v => !!v || 'Password is required',
                v => v.length >= 6 || 'Passsword must be more than 6 characters',
      ],
      emailRules: [
          v => !!v || 'E-mail is required',
          v => /.+@.+/.test(v) || 'E-mail must be valid',
       ],
       nameRules: [
        v => !!v || 'Name is required',
        v => (v && v.length <= 10) || 'Name must be less than 10 characters',
      ],
      ageRules: [
        v => !!v || 'Age is required',
        v => (v && v >= 18) || 'Age must be more than 18 years',
      ],
      user:{email: '',password: '', confirmPassword:'', age: 0, userName:'noname',photo:'https://www.cjoint.com/doc/16_06/FFdlyIDXEEm_username.jpg',
             firstName:'noname',lastName: 'noname',location: ''},
       };
       },
  methods:{
    registerUser(){
      accountService.register(this.user)
       .then((result) => {
         this.$router.push('/');
       }).catch((errors) =>  this.errors = errors);            
     }
}
}
</script>

<style lang="scss" scoped>
</style>
 
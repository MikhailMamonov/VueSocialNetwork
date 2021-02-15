<template>
    <section class="section">
         <v-layout align-center justify-center>
             <v-flex xs12 sm8 md4>
                 <v-card class="elevation-12">
                     <v-toolbar dark color="primary">
                         <v-toolbar-title>Login form</v-toolbar-title>
                        <v-spacer></v-spacer>
                    </v-toolbar>
                    <v-card-text>
                <v-form v-model="valid">
                  <v-text-field v-model="email" label="Email" :rules="emailRules" type="text"></v-text-field>
                  <v-text-field v-model="password" label="Password" :rules="passwordRules" type="password"></v-text-field>
                </v-form>
              </v-card-text>
               <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn :disabled="!valid" color="primary" @click='logIn'>Login</v-btn>
              </v-card-actions>
                 </v-card>
             </v-flex>
         </v-layout>
        <div class="container has-text-centered">
                    <p class="has-text-grey">
                        <router-link to="/register">Sign Up</router-link>
                    </p>
            </div>
<!--         </div> -->
    </section>
</template>

<script >

export default {
    name: 'v-login-form',
    data: function(){
        return { 
            isBusy: false,
            errors: '',
            password:'',
            valid: true,

            passwordRules: [
                v => !!v || 'Password is required',
                v => v.length >= 6 || 'Passsword must be more than 6 characters',
      ],
            email: '',
            emailRules: [
                v => !!v || 'E-mail is required',
                v => /.+@.+/.test(v) || 'E-mail must be valid',
            ],
       };
    },  
    
methods:{ 
    logIn(){
        this.$store.dispatch('auth/login',{email:this.email,password:this.password}).then(()=>{
            this.$router.push('/').catch((err)=>{console.log(err); this.errors = err;} );
        })
        }
      }
    }
</script>

<style lang="scss" scoped> 
</style>
<template>
<v-card
    class="mx-auto"
    max-width="600"
  >
     <div
              :class="[`text-h2`, active && `mb-1`]"
              class="transition-swing"
            >
            Users List
            </div>
  <v-list dense>
          <v-users-item 
          v-for="(user,i) in users" :key="i"
          :user="user" /> 
      </v-list>
</v-card>
</template>

<script>
import { mapState } from 'vuex';
import vUsersItem from '@/components/users/v-users-item';

export default {
    name: "v-users",
    components: {
    vUsersItem
  },
  data: function () {
    return { 
      selectedItem: 1,
      isModalVisible: false,
       };  
  },
  computed: {
        ...mapState({
            users: state => state.users.users
            })
            },
  methods:{
    showEditModal(index) {
      console.log("editIndex",index);
      console.log("editInput", this.users[index]);
      this.editInput ={ ...this.users[index] };
      this.isModalEditVisible = true;
      },
      showDeleteModal(index) {
      console.log("deleteIndex",index);
      this.deleteInput ={ ...this.users[index] };
      console.log("deleteInput", this.deleteInput);
      this.isModalDeleteVisible = true;
      },

    closeEditModal() {
        this.editInput= {};
        this.isModalEditVisible = false;
      },
      closeDeleteModal() {
        this.deleteInput= {};
        this.isModalDeleteVisible = false;
      }
  },
/*   created(){
       
        this.$store.dispatch('users/getUsers')
            .then(() => {
              console.log('success');
            }).catch(e => console.log('error'));
        
    } */
    }
</script>

<style>

</style>
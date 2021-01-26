<template>
<div>
    <div>Пользователи</div>
        <p>
      <a href="#"><strong>Users List</strong></a>
    </p>
      <div className="row">
        <div className="col">
      <ul class="list-unstyled">
          <v-users-item 
          v-for="user in users" :key="user.id"
          :user="user" /> 
      </ul>
        </div>
      </div>
  <div>
      <a href=""></a>
  </div>
</div>
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
  created(){
       
        this.$store.dispatch('users/getUsers')
            .then(() => {
              console.log('success');
            }).catch(e => console.log('error'));
        
    }
    }
</script>

<style>

</style>
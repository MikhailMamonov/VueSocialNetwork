<template>
<div class="row"> 
<div class="col-sm-3 well text-center">
  <Spinner v-bind:show="isBusy" />
    <div class="well">
            <p><a asp-controller="Users" asp-action="AccountDetails" asp-route-id="@Model.Id"><strong >{{name()}}</strong></a></p>
        </div>
        <div class="well">
            <p><a href="#"><strong>Interests</strong></a></p>
            <p>
                {{profile.interests}}
            </p>
        </div>
        <div class="well">
            <posts-list :posts="profile.posts"  />
            <!-- Кнопка запуска модального окна -->
<button class="btn btn-primary" type="button" @click="showModal">  Добавить Пост</button>
<add-post v-show="isModalVisible" @close="closeModal" ></add-post>
        </div>
</div>
 </div>
</template>

<script >
import Spinner from '@/components/Spinner.vue'; 
import { mapGetters } from 'vuex';
import { dashboardService } from '../../services/dashboard.service';
import PostsList from '../../components/Posts/PostsList.vue';
import AddPost from '../../components/Posts/AddPost.vue';

export default {
    name: 'Profile',
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
  computed: mapGetters({
    profile: 'authentication/user'
  }),

  components: {
    Spinner, PostsList, AddPost
  },

   created() {
     this.isBusy = true;
     
  }
}
</script>
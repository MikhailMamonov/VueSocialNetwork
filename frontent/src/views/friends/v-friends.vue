<template>
<div class="container-fluid">
  <div class="row">
    <h2>Friend Requests</h2>
    <div class="col">
      show all
    </div>
  </div>
  <div class="row">
    <h2>Friends</h2>
    <div class="col">
      <ul>
      <li>bob</li>
      <li>eliz</li>
      <li>lol</li>
      <li>mikka</li>
      <li>pavel</li>
    </ul>
    </div>
  </div>
</div>
</template>

<script>
import { mapState } from 'vuex';
import { postsService } from '../../services/posts.service.js';



export default {
    name: "Posts",
    props:['userId'],
    
  data: function () {
    return { 
      isModalVisible: false,
       };  
  },
  computed: {
        ...mapState({
            posts: state => state.posts.posts
            })
            },
  methods:{
    showModal() {
        this.isModalVisible = true;
      },
      closeModal() {
        this.isModalVisible = false;
      }
  },

    }
</script>

<style>

</style>
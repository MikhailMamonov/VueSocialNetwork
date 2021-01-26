<template>
<div>
      <p>
      <a href="#"><strong>Posts List</strong></a>
    </p>
    <button class="btn btn-primary" type="button" @click="showModal">  Добавить Пост</button>
    <v-add-post v-show="isModalVisible" @close="closeModal" />
  <div className="row">
    <div className="col">
      <ul class="list-unstyled">
        <v-posts-item 
        v-for="(post,index) in posts" :key="post.id"
        :post="post" :index="index"/>
      </ul>
    </div>
  </div>
</div>
</template>

<script>
import { mapState, mapGetters } from 'vuex';
import { postsService } from '../../services/posts.service.js';
import vPostsItem from '@/components/posts/v-posts-item';
import vAddPost from '@/components/posts/v-add-post.vue';

export default {
    name: "v-posts",
    components: {
    vPostsItem, vAddPost
  },
  data: function () {
    return { 
      isModalVisible: false,
       };  
  },
  computed: {
        ...mapGetters({
        posts: 'posts/getPosts'
      })},
  methods:{
    showModal() {
        this.isModalVisible = true;
      },
      closeModal() {
        this.isModalVisible = false;
      }
  },
  mounted(){
        
        this.$store.dispatch('posts/getPosts')
            .then(() => {
              console.log('success');
            })
            .catch(e => console.log('error'));
        
    }
    }
</script>

<style>

</style>
<template>
<v-card
    max-width="900"
    class="mx-auto"
  >
    <div
              :class="[`text-h2`, active && `mb-1`]"
              class="transition-swing"
            >
            Posts List
            </div>
      <v-list three-line>
         <v-posts-item 
        v-for="(post,index) in posts" :key="post.id"
        :post="post" :index="index"/>
    </v-list>
    <v-btn @click="showModal">  Добавить Пост</v-btn>
    <v-add-post v-show="isModalVisible" @close="closeModal" />
  
</v-card>
</template>

<script>
import { mapState, mapGetters } from 'vuex';

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
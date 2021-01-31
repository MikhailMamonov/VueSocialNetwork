<template>    
        <v-list-item
          :key="post.id"
        >
          <v-list-item-avatar>
            <v-img :src="post.imageSrc"></v-img>
          </v-list-item-avatar>

          <v-list-item-content>
            <v-list-item-title v-html="post.title"></v-list-item-title>
            <v-list-item-subtitle v-html="post.text"></v-list-item-subtitle>
          </v-list-item-content>
          <v-list-item-action>
         <!-- Модальное окно редактирования -->
          <v-dialog
      v-model="isModalEditVisible"
      persistent
      max-width="600px"
    >
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          color="primary"
          dark
          v-bind="attrs"
          v-on="on"
        >
          <v-icon color="grey lighten-1">mdi-pencil</v-icon>
        </v-btn>
      </template>
      <v-edit-post v-show="isModalEditVisible" @close="closeEditModal" :post="post" /> 
    </v-dialog>


        </v-list-item-action>
        <v-list-item-action>
          <v-btn icon @click="showDeleteModal(index)">
            <v-icon color="grey lighten-1">mdi-trash-can-outline</v-icon>
          </v-btn>
          <v-delete-post v-show="isModalDeleteVisible" @close="closeDeleteModal" :post="post" /> 
          </v-list-item-action>
          <v-list-item-action>
           <v-btn icon @click="showDeleteModal(index)">
            <v-icon color="grey lighten-1">mdi-thumb-up</v-icon>
          </v-btn>
          </v-list-item-action>
        </v-list-item>

</template>

<script>
import vEditPost from './v-edit-post';
import vDeletePost from './v-delete-post';

export default {
  name: "v-posts-item",
  props: ["post", "index", "posts"],
  data: function () {
    return { 
      isModalEditVisible: false,
      isModalDeleteVisible: false,
      dialog: false
      };
       }, 
    components: {
      vEditPost,
      vDeletePost
  },


  methods:{
   

    closeEditModal() {
        this.editInput= {};
        this.isModalEditVisible = false;
      },
      closeDeleteModal() {
        this.deleteInput= {};
        this.isModalDeleteVisible = false;
      }
  }
};
</script>


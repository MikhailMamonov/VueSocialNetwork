<template>
<v-card>
  <v-card>
        <v-tabs
          v-model="currentItem"
          fixed-tabs
          slider-color="white"
          background-color="red lighten-2"
          dark
        >
         <v-tab
            v-for="item in items"
            :key="item"
            :href="'#tab-' + item"
          >
            {{ item }}
          </v-tab>
        </v-tabs>
  </v-card>
      <v-tabs-items v-model="currentItem">
      <v-tab-item
        v-for="item in items"
        :key="item"
        :value="'tab-' + item"
      >
        <v-card flat>
          <v-card-text>
            <h2>{{ item }}</h2>
          </v-card-text>
          <v-friend-list :tab="item"></v-friend-list>
                  </v-card>
      </v-tab-item>
    </v-tabs-items>
</v-card>
</template>

<script>

import { mapGetters } from 'vuex';
import { mapState } from 'vuex';
import vFriendList from './v-friend-list'

export default {
  name: "v-friend-list-tabs",
  components: {vFriendList},
  data: function () {
    return { 
      
      tabs: null,
      currentItem: 'tab-Web',
      items: [
        'Friends', 'Friends online', 'Sended Requests', 'Received requests',
      ],
      isModalEditVisible: false,
      isModalDeleteVisible: false,
      editInput: { },
      deleteInput: { }
      };
       },
  computed:{ 
    ...mapGetters({
      currentUser: 'users/currentUser'
  })
  }, 
  created(){
    
            
  },

  methods:{
    showEditModal(index) {
      console.log("editIndex",index);
      console.log("editInput", this.Friends[index]);
      this.editInput ={ ...this.Friends[index] };
      this.isModalEditVisible = true;
      },
      showDeleteModal(index) {
      console.log("deleteIndex",index);
      this.deleteInput ={ ...this.Friends[index] };
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
  }
};
</script>

<style>
.custom-btn {
    width: 78px !important;
}

.btn-secondary {
	display: block;
    text-align: center;
    background: #ed2553;
    border-radius: 3px;
    box-shadow: 0 10px 20px -8px rgb(240, 75, 113);
    padding: 10px 17px;
    font-size: 18px;
    cursor: pointer;
    border: none;
    outline: none;
    color: #ffffff;
    text-decoration: none;
    -webkit-transition: 0.3s ease;
    transition: 0.3s ease;
}
 .btn-secondary:hover {
	transform: translateY(-3px);
}
 .btn-secondary .fa {
	margin-right: 5px;
}
.animate-like {
	animation-name: likeAnimation;
	animation-iteration-count: 1;
	animation-fill-mode: forwards;
	animation-duration: 0.65s;
}

.custom-text-area{
  word-wrap: break-word;
}

@keyframes likeAnimation {
  0%   { transform: scale(30); }
  100% { transform: scale(1); }
}
</style>
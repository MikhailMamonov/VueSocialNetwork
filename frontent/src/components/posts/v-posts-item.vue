<template>    
        <li>
          <div class="container">
            <div class="row" >
              <div class="col"></div>
              <div class="col"></div>
                <div class="col-md-auto" align="right">
                   <a href="#modal" @click="edit(index)" class="btn waves-effect waves-light yellow darken-2">
            </a>
                    <button class="btn btn-primary custom-btn" type="button" @click="showEditModal(index)"><i class="cil-brush"></i></button>
                    
                    <v-edit-post v-show="isModalEditVisible" @close="closeEditModal" :post="editInput" />
                    <button class="btn btn-danger custom-btn" type="button" @click="showDeleteModal(index)"><i class="cil-x"></i></button>  
                    <v-delete-post v-show="isModalDeleteVisible" @close="closeDeleteModal" :post="deleteInput" />               
                    <button class="btn btn-info custom-btn">
                      <i class="cil-heart"></i>
                    </button>
             
                </div>
            </div>
          <div class="row">
              <div class="col bg-light">
              </div>
              <div class="col-md-auto">
                <img
                  :src="post.imageSrc"
                  width="200"
                  height="200"
                  className="card-img-top rounded-circle"
                />
            </div>
            <div class="col bg-light">
              </div>
          </div>
            <div class="row">
              <div class="col">
              <div class="col-md-auto bg-warning">
                <p class="custom-text-area">{{ post.text }}</p>
              </div>
              <div class="col" >
          </div>
            </div>
            </div>
          </div>
        </li>
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
      editInput: { },
      deleteInput: { }
      };
       }, 
    components: {
     vEditPost,vDeletePost
  },


  methods:{
    showEditModal(index) {
      console.log("editIndex",index);
      console.log("editInput", this.posts[index]);
      this.editInput ={ ...this.posts[index] };
      this.isModalEditVisible = true;
      },
      showDeleteModal(index) {
      console.log("deleteIndex",index);
      this.deleteInput ={ ...this.posts[index] };
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
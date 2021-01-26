<template>
  <div className="row">

    <p>
      <a href="#"><strong>Friends List</strong></a>
    </p>
    
    <div className="col">
      <ul class="list-unstyled">
        <li v-for="(friend,index) in friends" :key="friend.id">
          <div class="container">
            <div class="row" >
              <div class="col"></div>
              <div class="col"></div>
                <div class="col-md-auto" align="right">
                   <a href="#modal" @click="edit(index)" class="btn waves-effect waves-light yellow darken-2">
            </a>
                    <button class="btn btn-primary custom-btn" type="button" @click="showEditModal(index)"><i class="cil-brush"></i></button>
                    
                    <edit-Friend v-show="isModalEditVisible" @close="closeEditModal" :Friend="editInput" ></edit-Friend>
                    <button class="btn btn-danger custom-btn" type="button" @click="showDeleteModal(index)"><i class="cil-x"></i></button>  
                    <delete-Friend v-show="isModalDeleteVisible" @close="closeDeleteModal" :Friend="deleteInput" ></delete-Friend>                       
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
                  :src="friend.imageSrc"
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
                <p class="custom-text-area">{{ friend.text }}</p>
              </div>
              <div class="col" >
          </div>
            </div>
            </div>
          </div>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
import EditFriend from './EditFriend';
import DeleteFriend from './DeleteFriend';

export default {
  name: "v-friends-list",
  props: ["friends"],
  data: function () {
    return { 
      isModalEditVisible: false,
      isModalDeleteVisible: false,
      editInput: { },
      deleteInput: { }
      };
       }, 
    components: {
     EditFriend,DeleteFriend
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
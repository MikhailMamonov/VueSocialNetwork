<template>
<transition name="modal-fade">
 <div class="modal-backdrop">
    <div class="modal">
       <header class="modal-header">
        <slot name="header">
         Add Post
          <button
            type="button"
            class="btn-close"
            @click="close"
          >
            x
          </button>
        </slot>
      </header>
<section class="modal-body">
      <slot name="body">
          <p>
    <label for="text">Text</label>
    <input
      v-model="itemText"
      type="text"
    >
  </p>
  <p>
      <label for="photo">photo</label>
      <input @change="uploadImage($event)" type="file" name="photo" accept="image/*">
<img :src="imageSrc" class="image">
  </p>
      </slot>
</section>
 <footer class="modal-footer">
      <slot name="footer">
          <button type="button" class="btn btn-secondary" @click="close">Close</button>
        <button type="button" class="btn btn-primary" @click="addPost">Add Post</button>
      </slot>
 </footer>
    </div>
  </div>
</transition>
</template>
<script>
export default {
    name: "AddPost",
    data () {
        return {
            visible: false,
            file:null,
            imageSrc: '',
            itemText: '',
            itemLikes:'',
            itemDate:'',
            newPost: {
                text: '',
                photo: ''
            }
        }
    },
    methods: {
        addPost () {
            console.log("imageSrc",this.imageSrc);
            this.newPost.text = this.itemText;
            this.newPost.photo = this.imageSrc;
            console.log("New Post",this.newPost);
            this.$store.dispatch('posts/addPost', this.newPost);
            this.close();
        },
        close() {
        this.$emit('close');
      },
      uploadImage(event){
          this.file = event.target.files[0];
          this.encodeImage(this.file);
  },
  encodeImage (input) {
      if (input) {
        const reader = new FileReader()
        reader.onload = (e) => {
          this.imageSrc = e.target.result
        }
        reader.readAsDataURL(input);
      }
    }
    }
    }
</script>

<style>
  .modal-backdrop {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(0, 0, 0, 0.3);
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .modal {
    background: #FFFFFF;
    box-shadow: 2px 2px 20px 1px;
    overflow-x: auto;
    display: flex;
    flex-direction: column;
  }

  .modal-header,
  .modal-footer {
    padding: 15px;
    display: flex;
  }

  .modal-header {
    border-bottom: 1px solid #eeeeee;
    color: #4AAE9B;
    justify-content: space-between;
  }

  .modal-footer {
    border-top: 1px solid #eeeeee;
    justify-content: flex-end;
  }

  .modal-body {
    position: relative;
    padding: 20px 10px;
  }

  .btn-close {
    border: none;
    font-size: 20px;
    padding: 20px;
    cursor: pointer;
    font-weight: bold;
    color: #4AAE9B;
    background: transparent;
  }

  .btn-green {
    color: white;
    background: #4AAE9B;
    border: 1px solid #4AAE9B;
    border-radius: 2px;
  }
</style>

<style>
 .modal-fade-enter,
  .modal-fade-leave-active {
    opacity: 0;
  }

  .modal-fade-enter-active,
  .modal-fade-leave-active {
    transition: opacity .5s ease
  }
</style>
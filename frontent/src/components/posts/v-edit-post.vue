<template>
  <transition name="modal-fade">
    <div class="modal-backdrop">
      <div class="modal">
        <header class="modal-header">
          <slot name="header">
            Edit Post
            <button type="button" class="btn-close" @click="close">x</button>
          </slot>
        </header>
        <section class="modal-body">
          <slot name="body">
            <p>
              <label for="text">Text</label>
              <textarea v-model="post.text" class="form-control"></textarea>
            </p>
            <p>
              <label for="photo">photo</label>
              <img
                :src="post.imageSrc"
                class="image"
                width="200"
                height="200"
              />
              <input
                @change="showPreview"
                type="file"
                id="image-uploader"
                accept="image/*"
                :class="['form-control-file', hasError ? errorClass : '']"
              />
            </p>
          </slot>
        </section>
        <footer class="modal-footer">
          <slot name="footer">
            <button type="button" class="btn btn-secondary" @click="close">
              Close
            </button>
            <button type="button" class="btn btn-primary" @click="editPost">
              Edit Post
            </button>
          </slot>
        </footer>
      </div>
    </div>
  </transition>
</template>
<script>
export default {
  name: "v-edit-post",
  props: ["post"],
  data() {
    return {
      visible: false,
      isEditing: false,
      file: null,
      imageSrc: "",
      hasError: false,
      errorClass: "text-danger",
    };
  },
  mounted() {
    this.cachedPost = Object.assign({}, this.post);
    console.log("CachedPost", this.cachedPost);
  },
  methods: {
    editPost() {
      this.cachedPost = Object.assign({}, this.post);
      this.cachedPost.imageFile = this.file;
      const formData = new FormData();
      for (var key in this.cachedPost) {
        formData.append(key, this.cachedPost[key]);
      }
      
      console.log("Cached Post", this.cachedPost);
      console.log("FormData", formData);
      this.$store
        .dispatch("posts/editPost", {form: formData, id: this.cachedPost.id})
        .then(() => {
          console.log("success");
        })
        .catch((e) => {
          console.error(e);
           });
      this.close();
    },
    close() {
      this.$emit("close");
    },
    showPreview(e) {
      if (e.target.files && e.target.files[0]) {
        this.file = e.target.files[0];
        const reader = new FileReader();
        reader.onload = (e) => {
          this.post.imageSrc = e.target.result;
        };
        reader.readAsDataURL(this.file);
      } else {
        this.file = null;
        this.post.imageSrc = this.defaultImageSrc;
      }
    },
  },
};
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
  background: #ffffff;
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
  color: #4aae9b;
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
  color: #4aae9b;
  background: transparent;
}

.btn-green {
  color: white;
  background: #4aae9b;
  border: 1px solid #4aae9b;
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
  transition: opacity 0.5s ease;
}
</style>
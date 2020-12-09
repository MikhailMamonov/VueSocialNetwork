import { postsService } from '../../services/posts.service';

const state = {   };

const getters = {

}

const actions ={
    addPost ({commit, dispatch} , newPost) {
        return new Promise((resolve, reject) => {
            commit('ADD_POST_REQUEST', newPost);
            postsService.addPost(newPost)
            .subscribe((result) => {
              commit('ADD_POST_SUCCESS', result);
              console.log(result);
              resolve(result);
            },
            (errors) => {
                commit('ADD_POST_ERROR', errors);
              reject(errors);
            });
          });
    }
}

const mutations = {
    ADD_POST_REQUEST(state, post){
        console.log("ADD_POST_REQUEST", post);
    },
    ADD_POST_SUCCESS (state, post) {
        state.posts.push(post);
    },
    ADD_POST_ERROR (state, post) {
        console.log("Errors")
    },

}


export default {
    state,
    getters,
    actions,
    mutations,
};


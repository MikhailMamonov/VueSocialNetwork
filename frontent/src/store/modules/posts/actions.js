import {postsService} from '../../../services/posts.service';

const addPost =  ({commit, dispatch} , newPost) => {
        return postsService.addPost(newPost)
            .then((result) => {
            debugger;
              commit('ADD_POST_SUCCESS', result.data.post);
              console.log(result);
            })
            .catch((e) => {
                debugger;
                console.log(e);
            });
    }

    const editPost =  ({commit, dispatch} ,data) => {
        return postsService.editPost(data.form, data.id)
            .then((result) => {
                debugger;
                commit('EDIT_POST_SUCCESS', result.data.post);
                console.log(result);                
            }).catch((e) => {
                debugger;
                console.log(e);
            });
    };
    const deletePost =  ({commit, dispatch} ,data) => {
        return postsService.deletePost(data.id)
            .then((result) => {
                debugger;
                commit('DELETE_POST_SUCCESS', result.data.id);
                console.log(result);                
            }).catch((e) => {
                debugger;
                console.log(e);
            });
    };
    const getPosts = ({commit, dispatch}) => {
        
        return postsService.getPosts()
            .then((result) => {
                
              
              commit('GET_POSTS_SUCCESS', result.data);
            })
            .catch((errors) => {
                debugger;
                console.log("error",errors);
            });
          
    }

export { addPost, editPost, deletePost, getPosts}
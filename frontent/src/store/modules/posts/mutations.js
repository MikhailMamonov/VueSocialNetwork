const ADD_POST_REQUEST = (state, post) =>{
        console.log("ADD_POST_REQUEST", post);
    };

const ADD_POST_SUCCESS = (state, post) => {
        debugger;
        console.log("ADD_POST_SUCCESS", post);
        state.posts.push(post);
    };

const EDIT_POST_SUCCESS = (state, post) => {
        console.log("before edit Posts", state.posts);
        console.log("edited post", post);
        debugger;
        state.posts = [post,
            ...state.posts.filter(element => element.id !== post.id)            
         ];
        console.log("after edit Posts", state.posts);
    };

const GET_POSTS_SUCCESS = (state, posts) => {
        console.log("httpGet posts",posts);
        
        state.posts = posts;
        console.log("posts after update",state.posts);

    }

const ADD_POST_ERROR = (state, errors) => {
        console.log("ADD_POST_ERROR")
        console.log(errors);
    };
    
const DELETE_POST_SUCCESS = (state,id) => {
        console.log("httpdelete id",id);
        var index = state.posts.findIndex(p => p.id == id);
        console.log("index in array ",index);
        state.posts.splice(index, 1);
        console.log("posts after delete",state.posts);
        debugger;
}



export {
    ADD_POST_REQUEST, 
    ADD_POST_SUCCESS,
    EDIT_POST_SUCCESS,
    GET_POSTS_SUCCESS,
    ADD_POST_ERROR,
    DELETE_POST_SUCCESS

}
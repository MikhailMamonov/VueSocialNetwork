import axios from 'axios';
const url = "http://localhost:5000/api/posts";
export const postsService =  { 
    addPost(post) {
          return axios.post(url+'/Create', post);
    },
    getPosts(){
        
        return axios.get(url+'/GetPosts')
    },
    editPost(form,id){
        let putUrl = url+ '/Edit';
        
        return axios.put(putUrl, form,
            {params: {id: id}})
    },
    deletePost(id){
        let deleteUrl = url+ '/Delete';
        return axios.delete(deleteUrl,
            {params:{id:id}})
    }
}

const getPosts = (postsState) => { 
    
    console.log("getter start");
    console.log("posts", postsState.posts);
    console.log("getter end");
    return postsState.posts;
  };

export {
    getPosts
}

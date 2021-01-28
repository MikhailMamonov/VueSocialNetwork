import { user } from "../auth/getters";

const getFriends = (friendsState) => { 
    
    console.log("getter start");
    console.log("posts", friendsState.friends);
    console.log("getter end");
    return friendsState.friends;
  };

  const isFriend = (friendsState) => userId => 
  { 
    console.log("friends", friendsState.friends);
    let inFriends = friendsState.friends.filter(f => f.id === userId);
      console.log("val", inFriends);
      debugger;
    return typeof inFriends !== 'undefined' && inFriends.length > 0;
   
  };

  const isFriendRequested = (friendsState) => request =>
  {
      console.log("request.senderId",request.senderId);
      console.log("request.receiverId",request.receiverId);
      console.log("friendRequests", friendsState.friendRequests);
      const friendRequests = friendsState.friendRequests.filter(r => r.receiverId ===request.receiverId&& r.senderId===request.senderId);
      
      debugger;
      return typeof friendRequests !== 'undefined' && friendRequests.length > 0;
  }

const getSendedRequests =(state, getters, rootState)=> request=>
{
  debugger;
  const receiversIds = state.friendRequests.reduce(function(filtered, r) {
  if (r.senderId===request.senderId) {
     filtered.push(r.receiverId);
  }
    return filtered;
  }, []); 
  console.log('receiversIds',receiversIds);
 console.log("rootState.users.users",rootState.users.users);  ``
  const receivers = rootState.users.users.reduce((filtered,user)=>{
    if(receiversIds.includes(user.id)){
      filtered.push(user);
    }
    return filtered;
  }, []);

  return receivers;
}

const getReceivedRequests =(state, getters, rootState)=> request=>
{
  debugger
  const sendersIds = state.friendRequests.reduce(function(filtered, r) {
  if (r.receiverId===request.receiverId) {
     filtered.push(r.senderId);
  }
    return filtered;
  }, []); 
  
  console.log('sendersIds',sendersIds);
  console.log("rootState.users.users",rootState.users.users);
   const senders = rootState.users.users.reduce((filtered,user)=>{
    if(sendersIds.includes(user.id)){
      filtered.push(user);
    }
    return filtered;
  }, []);

  return senders;
}

export {
    getFriends,
    isFriend,
    isFriendRequested,
    getSendedRequests,
    getReceivedRequests
}

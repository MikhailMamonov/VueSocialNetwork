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



export {
    getFriends,
    isFriend,
    isFriendRequested
}

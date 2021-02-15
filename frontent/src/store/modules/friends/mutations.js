
const GET_FRIENDS = (state, payload)=>{
    console.log("friends",payload.friends);
    state.friends = payload.friends;
}

const ADD_FRIEND_REQUEST_SUCCESS = (state, payload) => {
    debugger;
    console.log("ADD_FRIEND_REQUEST_SUCCESS", payload);
    state.friendRequests.push({senderId: payload.senderId, receiverId: payload.receiverId});
};

const DELETE_FRIEND_REQUEST = (state,  payload) => {
    debugger;
    console.log("ADD_FRIEND_REQUEST_SUCCESS", payload);
    var index = state.friendRequests.findIndex(p => p.senderId == payload.senderId && p.receiverId== payload.receiverId);
    console.log("index in friendRequests",index);
    state.friendRequests.splice(index, 1);
    console.log("friendRequests after delete",state.friendRequests);

}

const ADD_FRIEND_ERROR = (state, errors) => {
    console.log("ADD_FRIEND_ERROR");
    console.log(errors);
};

const DELETE_FRIEND = (state,friendId) => {
    console.log("httpdelete friendId",friendId);
    var index = state.friends.findIndex(p => p.id == friendId);
    console.log("index in array ",index);
    state.friends.splice(index, 1);
    console.log("friends after delete",state.friends);
    debugger;
}

const SET_FRIEND_REQUESTS = (state, friendRequests)=>{
    state.friendRequests = friendRequests;
}

const ADD_FRIEND = (state, friend)=>{
    state.friends.push(friend);
}



export {
    ADD_FRIEND_REQUEST_SUCCESS,
    ADD_FRIEND_ERROR,
    DELETE_FRIEND,
    DELETE_FRIEND_REQUEST,
    SET_FRIEND_REQUESTS,
    GET_FRIENDS,
    ADD_FRIEND

}
import { friendsService } from "../../../services/friends.service";

const addToFriends = ({ commit, dispatch }, data) => {
  return friendsService
    .addToFriend(data.senderId, data.receiverId)
    .then((result) => {
      debugger;
      commit("ADD_FRIEND_REQUEST_SUCCESS", {
        senderId: data.senderId,
        receiverId: data.receiverId,
      });
      console.log(result);
    })
    .catch((e) => {
      console.log(e);
    });
};

const cancelFriendRequest = ({ commit, dispatch }, data) => {
  return friendsService
    .cancelFriendRequest(data.senderId, data.receiverId)
    .then((result) => {
      debugger;
      commit("DELETE_FRIEND_REQUEST", {
        senderId: data.senderId,
        receiverId: data.receiverId,
      });
      console.log(result);
    })
    .catch((e) => {
      console.log(e);
    });
};

const accept = ({ commit, dispatch, rootState }, data) => {
  return friendsService
    .accept(data.senderId, data.receiverId)
    .then((result) => {
      debugger;
      const friend = rootState.users.users.find(u => u.id ===data.senderId)
      commit("ADD_FRIEND", friend);
      commit("DELETE_FRIEND_REQUEST", {
        senderId: data.senderId,
        receiverId: data.receiverId,
      });
      console.log(result);
    })
    .catch((e) => {
      console.log(e);
    });
};

const decline = ({ commit, dispatch }, data) => {
  return friendsService
    .decline(data.senderId, data.receiverId)
    .then((result) => {
      debugger;
      commit("DELETE_FRIEND_REQUEST", {
        senderId: data.senderId,
        receiverId: data.receiverId,
      });
      console.log(result);
    })
    .catch((e) => {
      console.log(e);
    });
};

const deleteFriend = ({ commit, dispatch }, userId) => {
  debugger;
  return friendsService
    .deleteFriend(userId)
    .then((result) => {
      debugger;
      commit("DELETE_FRIEND", userId);
      console.log(result);
    })
    .catch((e) => {
      console.log(e);
    });
};
const getFriends = ({ commit, dispatch }, userId) => {
  console.log(userId)
  return friendsService
    .getFriends(userId)
    .then((result) => {
      commit("GET_FRIENDS", result.data);
    })
    .catch((errors) => {
      console.log("error", errors);
    });
};

const setFriendRequests = ({ commit, dispatch }, friendRequests) => {
  console.log("setFriendRequests", friendRequests);
  commit("SET_FRIEND_REQUESTS", friendRequests);
};

export {
  addToFriends,
  deleteFriend,
  getFriends,
  cancelFriendRequest,
  setFriendRequests,
  accept,
  decline
};

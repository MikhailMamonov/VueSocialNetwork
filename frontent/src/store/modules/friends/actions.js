import {friendsService} from '../../../services/friends.service';

const addToFriends =  ({commit, dispatch} , data) => {
        return friendsService.addToFriend(data.senderId, data.receiverId)
            .then((result) => {
            debugger;
              commit('ADD_FRIEND_REQUEST_SUCCESS', {senderId:data.senderId, receiverId: data.receiverId});
              console.log(result);
            })
            .catch((e) => {

                console.log(e);
            });
    }

    const cancelFriendRequest = ({commit, dispatch}, data) =>{
        return friendsService.cancelFriendRequest(data.senderId, data.receiverId)
            .then((result) => {
            debugger;
              commit('DELETE_FRIEND_REQUEST', {senderId:data.senderId, receiverId: data.receiverId});
              console.log(result);
            })
            .catch((e) => {

                console.log(e);
            });
    }

    const deleteFriend =  ({commit, dispatch} ,data) => {
        return friendsService.deletefriend(data.id)
            .then((result) => {
                debugger;
                commit('DELETE_friend_SUCCESS', result.data.id);
                console.log(result);                
            }).catch((e) => {

                console.log(e);
            });
    };
    const getFriends = ({commit, dispatch}, userId) => {
        
        return friendsService.getFriends(userId)
            .then((result) => {
                
              
              commit('GET_FRIENDS', result.data);
            })
            .catch((errors) => {
                console.log("error",errors);
            });
          
    }

    const setFriendRequests = ({commit, dispatch},friendRequests)=>{
        console.log('setFriendRequests', friendRequests);
        commit('SET_FRIEND_REQUESTS', friendRequests);
    }

export { addToFriends, deleteFriend, getFriends, cancelFriendRequest, setFriendRequests}
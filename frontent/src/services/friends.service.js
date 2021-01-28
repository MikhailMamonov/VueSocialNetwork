import axios from 'axios';
const url = "http://localhost:5000/api/FriendRequests";
export const friendsService =  {
    addToFriend(senderId, receiverId) {
         const postUrl = url + '/AddFriend';
          return axios.post(postUrl,null, {params: {receiverId: receiverId, senderId:senderId}});
    },
    getFriends(userId){
        const getUrl = 'http://localhost:5000/api/Users' + '/GetFriends';
        return axios.get(getUrl, { params: {id: userId} });
    },
    editFriend(form,id){
        let putUrl = url+`/${id}`;
        
        return axios.put(putUrl, form)
    },
    cancelFriendRequest(senderId, receiverId)
    {
        const cancelUrl = url + '/CancelFriendRequest';
          return axios.post(cancelUrl,null, {params: {senderId:senderId, receiverId: receiverId}});
    },
    deleteFriend(id){
        let putUrl = url+`/${id}`;
        
        return axios.delete(putUrl)
    }
}

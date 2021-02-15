import axios from "axios";
import { accept } from "../store/modules/friends/actions";
const url = "http://localhost:5000/api/FriendRequests";
export const friendsService = {
  addToFriend(senderId, receiverId) {
    const postUrl = url + "/AddFriend";
    return axios.post(postUrl, null, {
      params: { receiverId: receiverId, senderId: senderId },
    });
  },
  getFriends(userId) {
    const getUrl = "http://localhost:5000/api/Users" + "/GetFriends";
    debugger;
    return axios.get(getUrl, { params: { userId } });
  },
  editFriend(form, id) {
    let putUrl = url + `/${id}`;

    return axios.put(putUrl, form);
  },
  cancelFriendRequest(senderId, receiverId) {
    const cancelUrl = url + "/CancelFriendRequest";
    return axios.post(cancelUrl, null, {
      params: { senderId: senderId, receiverId: receiverId },
    });
  },
  deleteFriend(id) {
    let putUrl = "http://localhost:5000/api/Users/DeleteFriend";
    console.log("userId",id)
    return axios.delete(putUrl, {params:{friendId:id}});
  },
  accept(senderId, receiverId) {
    let acceptUrl = url + "/Accept";
    return axios.post(acceptUrl,null, {params: {senderId, receiverId }});
  },
  decline(senderId, receiverId) {
    let declineUrl = url + "/Decline";
    return axios.post(declineUrl,null, {params: {senderId, receiverId }});
  },
};

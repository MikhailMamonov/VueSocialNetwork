
import * as actions from './actions';
import * as mutations from './mutations';
import * as getters from './getters';



const currentUser=()=> localStorage.getItem("user");
console.log("currentUser in state",currentUser());
const state = { currentUser: currentUser!=null? JSON.parse(currentUser()): {}, status: '', users: {}};

export default {
  namespaced: true,
  state,
  actions,
  mutations,
  getters
};

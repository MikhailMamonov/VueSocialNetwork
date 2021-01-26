import axios from 'axios';
const url = "http://localhost:5000/api/users";
export const usersService =  {
    addUser(user) {
          return axios.post(url, user);
    },
    getUserById(id){
        return axios.get(url+'/GetUserById', { params: {id: id} })
    },
    getUsers(){
        return axios.get(url+'/GetUsers')
    },
    editUser(form,id){
        let editUrl = url + '/Edit';
        return axios.put(editUrl, form,
            {
            params: {id: id},
            }
            )
    },
    deleteUser(id){
        let putUrl = url+`/${id}`;
        
        return axios.delete(putUrl)
    },
}

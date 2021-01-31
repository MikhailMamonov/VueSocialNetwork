const user = localStorage.getItem('user');
console.log(user);
 const state = { token: localStorage.getItem('token') || '',
                 status: '',
                 user: user!=='undefined'? JSON.parse(user): {}
                };

export default state;
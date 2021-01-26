const isAuthenticated = authState => { console.log("isAuthenticated", !!authState.token); return !!authState.token};
const authStatus =  authState => authState.status;
const authToken =  (authState) => authState.token;
const user =  (authState) => {
    const user = localStorage.getItem('user');
    console.log("user from state", authState.user);
    console.log("user from storage", user? JSON.parse(user): {});
    let res = user? JSON.parse(user): {};
    return res};

export {
    isAuthenticated, 
    authStatus,
    authToken,
    user
};
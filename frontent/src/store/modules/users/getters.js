    const currentUser = (userState) => { 
      console.log("getter start");
      console.log("currentUser", userState.currentUser);
      console.log("getter end");

      return userState.currentUser;
    }
    const userById = (userState) => payload => { 
      debugger;
      console.log(payload);
      console.table(userState.users);
      const user = userState.users.find(user => user.id === payload.userId);
      console.log("user by id", user);
      return user;
    };

      export {
        currentUser,
        userById
      }
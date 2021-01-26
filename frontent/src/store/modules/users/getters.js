const currentUser = (userState) => { 
      console.log("getter start");
      console.log("currentUser", userState.currentUser);
      console.log("getter end");
      return userState.currentUser;
    };

      export {
        currentUser
      }
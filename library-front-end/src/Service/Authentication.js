export const getCurrentUser = () => {
    return JSON.parse(sessionStorage.getItem("token"));
  };
  
  export function authHeader() {
    const user = JSON.parse(sessionStorage.getItem("token"));
    if (user && user.id) {
      return { Token: user.id };
    } else {
      return {};
    }
  
  }